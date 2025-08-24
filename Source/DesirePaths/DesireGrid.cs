using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace DesirePathsContinued;

public class DesireGrid : MapComponent, ICellBoolGiver
{
    public static bool DrawPaths;

    private static readonly Dictionary<ushort, TerrainDef> terrainsByHash =
        DefDatabase<TerrainDef>.AllDefsListForReading.ToDictionary(d => d.shortHash, d => d);

    private readonly CellBoolDrawer pathsDrawer;

    private TerrainDef[] originalTerrain;

    private float[] stoneGrid;
    private float[] walkGrid;

    private float walkMax = float.MaxValue;

    private float walkThreshold = float.MaxValue;

    public DesireGrid(Map map)
        : base(map)
    {
        var numGridCells = map.cellIndices.NumGridCells;
        walkGrid = new float[numGridCells];
        stoneGrid = new float[numGridCells];
        originalTerrain = new TerrainDef[numGridCells];
        for (var i = 0; i < numGridCells; i++)
        {
            walkGrid[i] = 0f;
            stoneGrid[i] = 0f;
        }

        pathsDrawer = new CellBoolDrawer(this, map.Size.x, map.Size.z, 2610, 0.5f);
    }

    public Color Color => GenUI.MouseoverColor;

    public bool GetCellBool(int index)
    {
        return walkGrid[index] > walkThreshold;
    }

    public Color GetCellExtraColor(int index)
    {
        var white = Color.white;
        white.a = Mathf.Clamp01(walkGrid[index] / walkMax);
        return white;
    }

    private static bool isPackable(TerrainDef terrain)
    {
        var modExtension = terrain.GetModExtension<DefModExtension_PackedTerrain>();
        if (modExtension == null)
        {
            if (terrain == TerrainDefOf.PackedDirt)
            {
                return false;
            }

            if (DesirePaths.Settings.IgnoreWet && terrain.driesTo != null)
            {
                return false;
            }

            if (!terrain.canEverTerraform)
            {
                return false;
            }

            return terrain.takeFootprints;
        }

        if (!modExtension.disabled)
        {
            return terrain != modExtension.packedTerrain;
        }

        return false;
    }

    private static TerrainDef packedTerrain(TerrainDef terrain)
    {
        return terrain.GetModExtension<DefModExtension_PackedTerrain>()?.packedTerrain ?? TerrainDefOf.PackedDirt;
    }

    public override void MapComponentTick()
    {
        base.MapComponentTick();
        if (map.IsHashIntervalTick(20))
        {
            doWalkGridTick();
        }

        if (map.IsHashIntervalTick(5000))
        {
            doUpdateTick();
        }

        if (map.IsHashIntervalTick(2500))
        {
            doPathDrawerUpdate();
        }
    }

    public override void MapComponentUpdate()
    {
        if (DrawPaths)
        {
            pathsDrawer.MarkForDraw();
        }

        pathsDrawer.CellBoolDrawerUpdate();
    }

    private void doWalkGridTick()
    {
        foreach (var item in map.mapPawns.AllPawnsSpawned.Where(p => !p.Dead && !p.Downed && p.Awake()))
        {
            var num = 1f;
            var raceProps = item.RaceProps;
            if (raceProps is { Animal: true })
            {
                num *= DesirePaths.Settings.AnimalEffect;
            }

            num *= item.BodySize;
            if (!item.pather.MovingNow)
            {
                num *= 0.1f;
            }

            var num2 = map.cellIndices.CellToIndex(item.Position);
            walkGrid[num2] += num;
            stoneGrid[num2] += num;
            if (DesirePaths.Settings.IncludeAdjacent)
            {
                num *= DesirePaths.Settings.AdjacentFactor;
                foreach (var item2 in GenAdjFast.AdjacentCells8Way(item.Position))
                {
                    if (!item2.InBounds(map))
                    {
                        continue;
                    }

                    num2 = map.cellIndices.CellToIndex(item2);
                    walkGrid[num2] += num;
                    stoneGrid[num2] += num;
                }
            }

            map.snowGrid.AddDepth(item.Position, -0.02f * DesirePaths.Settings.SnowClearFactor * item.BodySize);
        }
    }

    private void doUpdateTick()
    {
        for (var i = 0; i < map.cellIndices.NumGridCells; i++)
        {
            if (walkGrid[i] > DesirePaths.Settings.PathCreateThreshold)
            {
                tryCreatePath(i);
            }

            walkGrid[i] *= DesirePaths.Settings.PathDegradeFactor;
            if (walkGrid[i] < DesirePaths.Settings.PathDegradeThreshold)
            {
                tryRemovePath(i);
            }

            if (stoneGrid[i] > DesirePaths.Settings.StoneSmoothThreshold)
            {
                trySmooth(i);
            }
        }
    }

    private void doPathDrawerUpdate()
    {
        var num = walkGrid.Max();
        walkThreshold = num * 0.05f;
        walkMax = num * 0.8f;
        pathsDrawer.SetDirty();
    }

    private void tryCreatePath(int index)
    {
        var c = map.cellIndices.IndexToCell(index);
        var terrain = c.GetTerrain(map);
        if (!isPackable(terrain))
        {
            return;
        }

        originalTerrain[index] = terrain;
        map.terrainGrid.SetTerrain(c, packedTerrain(terrain));
    }

    private void tryRemovePath(int index)
    {
        if (originalTerrain[index] == null)
        {
            return;
        }

        var c = map.cellIndices.IndexToCell(index);
        if (c.GetTerrain(map) != packedTerrain(originalTerrain[index]))
        {
            return;
        }

        map.terrainGrid.SetTerrain(c, originalTerrain[index]);
        originalTerrain[index] = null;
    }

    private void trySmooth(int index)
    {
        var c = map.cellIndices.IndexToCell(index);
        var terrain = c.GetTerrain(map);
        if (terrain.affordances.Contains(TerrainAffordanceDefOf.SmoothableStone))
        {
            map.terrainGrid.SetTerrain(c, terrain.smoothedTerrain);
        }
    }

    public override void ExposeData()
    {
        base.ExposeData();
        if (Scribe.mode == LoadSaveMode.LoadingVars)
        {
            walkGrid = new float[map.cellIndices.NumGridCells];
            stoneGrid = new float[map.cellIndices.NumGridCells];
            originalTerrain = new TerrainDef[map.cellIndices.NumGridCells];
        }

        MapExposeUtility.ExposeUshort(map,
            cell => (ushort)(walkGrid[map.cellIndices.CellToIndex(cell)] * 100f),
            delegate(IntVec3 cell, ushort val) { walkGrid[map.cellIndices.CellToIndex(cell)] = val / 100f; },
            "walkGrid");
        MapExposeUtility.ExposeUshort(map,
            cell => (ushort)(stoneGrid[map.cellIndices.CellToIndex(cell)] * 100f),
            delegate(IntVec3 cell, ushort val) { stoneGrid[map.cellIndices.CellToIndex(cell)] = val / 100f; },
            "stoneGrid");
        MapExposeUtility.ExposeUshort(map,
            cell => originalTerrain[map.cellIndices.CellToIndex(cell)]?.shortHash ?? 0,
            delegate(IntVec3 cell, ushort val)
            {
                if (val != 0 && terrainsByHash.TryGetValue(val, out var value))
                {
                    originalTerrain[map.cellIndices.CellToIndex(cell)] = value;
                }
            }, "originalTerrain");
    }
}