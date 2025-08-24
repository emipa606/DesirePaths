using Mlie;
using UnityEngine;
using Verse;

namespace DesirePathsContinued;

public class DesirePaths : Mod
{
    public static string CurrentVersion;

    public DesirePaths(ModContentPack content)
        : base(content)
    {
        Settings = GetSettings<Settings>();
        CurrentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public static Settings Settings { get; private set; }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        GetSettings<Settings>().DoWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return I18n.DesirePaths;
    }
}