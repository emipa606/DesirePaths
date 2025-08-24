using Verse;

namespace DesirePathsContinued;

public static class I18n
{
    public static readonly string DesirePaths = "Fluffy.DesirePaths".Translate();

    public static readonly string DrawPaths = "Fluffy.DesirePaths.DrawPaths".Translate();

    public static readonly string IncludeAdjacent = "Fluffy.DesirePaths.Settings.IncludeAdjacent".Translate();

    public static TaggedString PathCreationThreshold(int threshold, int @default)
    {
        return "Fluffy.DesirePaths.Settings.PathCreationThreshold".Translate(threshold, @default);
    }

    public static TaggedString PathDegradeThreshold(int threshold, int @default)
    {
        return "Fluffy.DesirePaths.Settings.PathDegradeThreshold".Translate(threshold, @default);
    }

    public static TaggedString StoneSmoothThreshold(int threshold, int @default)
    {
        return "Fluffy.DesirePaths.Settings.StoneSmoothThreshold".Translate(threshold, @default);
    }

    public static TaggedString PathDegradeFactor(float factor, float @default)
    {
        return "Fluffy.DesirePaths.Settings.PathDegradeFactor".Translate(factor.ToString("P0"),
            @default.ToString("P0"));
    }

    public static TaggedString SnowClearFactor(float factor, float @default)
    {
        return "Fluffy.DesirePaths.Settings.SnowClearFactor".Translate(factor.ToString("P0"), @default.ToString("P0"));
    }

    public static TaggedString AdjacentFactor(float factor, float @default)
    {
        return "Fluffy.DesirePaths.Settings.AdjacentFactor".Translate(factor.ToString("P0"), @default.ToString("P0"));
    }

    public static TaggedString AnimalEffect(float factor, float @default)
    {
        return "Fluffy.DesirePaths.Settings.AnimalEffect".Translate(factor.ToString("P0"), @default.ToString("P0"));
    }
}