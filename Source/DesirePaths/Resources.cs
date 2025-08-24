using UnityEngine;
using Verse;

namespace DesirePathsContinued;

[StaticConstructorOnStartup]
public static class Resources
{
    public static readonly Texture2D DrawPathsIcon;

    static Resources()
    {
        DrawPathsIcon = ContentFinder<Texture2D>.Get("UI/Icons/DrawPaths");
    }
}