using System.Reflection;
using HarmonyLib;
using Verse;

namespace DesirePathsContinued;

[StaticConstructorOnStartup]
public static class Start
{
    static Start()
    {
        new Harmony("Fluffy.DesirePaths").PatchAll(Assembly.GetExecutingAssembly());
    }
}