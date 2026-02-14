using System.Reflection;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace ShowPossibleMaterials;

[HarmonyPatch]
public static class TabBillsDrawer_DrawBillPreview
{
    public static bool Prepare()
    {
        return ModLister.GetActiveModWithIdentifier("Andromeda.NiceBillTab", true) != null;
    }

    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("NiceBillTab.TabBillsDrawer:DrawBillPreview");
    }

    public static void Prefix(Bill bill, Rect recipePreviewRect)
    {
        Bill_Production_DoConfigInterface.AddIngredientLocations(bill, recipePreviewRect);
    }
}