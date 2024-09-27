using System.Reflection;
using HarmonyLib;
using Verse;

namespace ShowPossibleMaterials;

[StaticConstructorOnStartup]
public static class ShowPossibleMaterials
{
    static ShowPossibleMaterials()
    {
        new Harmony("Mlie.ShowPossibleMaterials").PatchAll(Assembly.GetExecutingAssembly());
    }
}