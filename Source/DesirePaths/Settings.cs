using UnityEngine;
using Verse;

namespace DesirePathsContinued;

public class Settings : ModSettings
{
    public float AdjacentFactor = 0.2f;
    public float AnimalEffect = 0.25f;
    public bool IgnoreWet = true;

    public bool IncludeAdjacent = true;
    public int PathCreateThreshold = 120;

    public float PathDegradeFactor = 0.9f;

    public int PathDegradeThreshold = 80;

    public float SnowClearFactor = 0.5f;

    public int StoneSmoothThreshold = 1000;

    public void DoWindowContents(Rect canvas)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(canvas);
        listingStandard.Label(I18n.PathCreationThreshold(PathCreateThreshold, 120));
        PathCreateThreshold = (int)listingStandard.Slider(PathCreateThreshold, 50f, 1000f);
        listingStandard.Gap();
        listingStandard.Label(I18n.PathDegradeThreshold(PathDegradeThreshold, 80));
        PathDegradeThreshold = (int)listingStandard.Slider(PathDegradeThreshold, 0f, PathCreateThreshold - 10);
        listingStandard.Gap();
        listingStandard.Label(I18n.PathDegradeFactor(1f - PathDegradeFactor, 0.1f));
        PathDegradeFactor = listingStandard.Slider(PathDegradeFactor, 0.5f, 0.99f);
        listingStandard.Gap();
        listingStandard.CheckboxLabeled(I18n.IncludeAdjacent, ref IncludeAdjacent);
        if (IncludeAdjacent)
        {
            listingStandard.Label(I18n.AdjacentFactor(AdjacentFactor, 0.2f));
            AdjacentFactor = listingStandard.Slider(AdjacentFactor, 0f, 1f);
        }

        listingStandard.Gap();
        listingStandard.Label(I18n.SnowClearFactor(SnowClearFactor, 0.5f));
        SnowClearFactor = listingStandard.Slider(SnowClearFactor, 0f, 1f);
        listingStandard.Gap();
        listingStandard.Label(I18n.StoneSmoothThreshold(StoneSmoothThreshold, 2500));
        StoneSmoothThreshold = (int)listingStandard.Slider(StoneSmoothThreshold, 100f, 10000f);
        listingStandard.Gap();
        listingStandard.Label(I18n.AnimalEffect(AnimalEffect, 0.25f));
        AnimalEffect = listingStandard.Slider(AnimalEffect, 0f, 1f);
        listingStandard.Gap();
        listingStandard.CheckboxLabeled("Fluffy.DesirePaths.Settings.IgnoreWet".Translate(), ref IgnoreWet);

        listingStandard.GapLine();
        if (listingStandard.ButtonTextLabeled("Fluffy.DesirePaths.Settings.ResetSettings".Translate(),
                "Reset".Translate()))
        {
            PathCreateThreshold = 120;
            PathDegradeThreshold = 80;
            PathDegradeFactor = 0.9f;
            IncludeAdjacent = true;
            IgnoreWet = true;
            SnowClearFactor = 0.5f;
            StoneSmoothThreshold = 2500;
            AnimalEffect = 0.25f;
        }

        if (DesirePaths.CurrentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label(
                "Fluffy.DesirePaths.Settings.CurrentModVersion".Translate(DesirePaths.CurrentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    public override void ExposeData()
    {
        Scribe_Values.Look(ref PathCreateThreshold, "pathCreateThreshold", 120);
        Scribe_Values.Look(ref PathDegradeThreshold, "pathDegradeThreshold", 80);
        Scribe_Values.Look(ref PathDegradeFactor, "pathDegradeFactor", 0.9f);
        Scribe_Values.Look(ref AnimalEffect, "AnimalEffect", 0.25f);
        Scribe_Values.Look(ref SnowClearFactor, "snowClearFactor", 0.5f);
        Scribe_Values.Look(ref StoneSmoothThreshold, "stoneSmoothThreshold", 2500);
    }
}