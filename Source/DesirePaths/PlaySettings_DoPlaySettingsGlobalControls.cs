using HarmonyLib;
using RimWorld;
using Verse;

namespace DesirePathsContinued;

[HarmonyPatch(typeof(PlaySettings), nameof(PlaySettings.DoPlaySettingsGlobalControls))]
public static class PlaySettings_DoPlaySettingsGlobalControls
{
    public static void Postfix(WidgetRow row, bool worldView)
    {
        if (!worldView)
        {
            row.ToggleableIcon(ref DesireGrid.DrawPaths, Resources.DrawPathsIcon, I18n.DrawPaths);
        }
    }
}