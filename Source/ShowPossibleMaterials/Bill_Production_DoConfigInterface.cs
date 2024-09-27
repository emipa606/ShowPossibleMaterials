using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace ShowPossibleMaterials;

[HarmonyPatch(typeof(Bill_Production), "DoConfigInterface")]
public static class Bill_Production_DoConfigInterface
{
    public static void Prefix(Bill_Production __instance, Rect baseRect)
    {
        // Check if the Alt key is pressed and if the mouse is over the baseRect
        if (!Mouse.IsOver(baseRect) || !Event.current.control)
        {
            return;
        }

        if (__instance.recipe.ingredients == null || !__instance.recipe.ingredients.Any())
        {
            return;
        }

        var foundThingDefs = new Dictionary<ThingDef, int>();
        var foundThings = new List<Thing>();
        foreach (var recipeIngredient in __instance.recipe.ingredients)
        {
            if (!recipeIngredient.IsFixedIngredient)
            {
                continue;
            }

            foreach (var possibleIngredient in
                     __instance.Map.listerThings.ThingsMatchingFilter(recipeIngredient.filter))
            {
                if (!recipeIngredient.filter.Allows(possibleIngredient))
                {
                    continue;
                }

                TargetHighlighter.Highlight(possibleIngredient);
                foundThingDefs.TryAdd(possibleIngredient.def, 0);
                foundThingDefs[possibleIngredient.def] += possibleIngredient.stackCount;
                foundThings.Add(possibleIngredient);
            }
        }

        foreach (var possibleIngredient in
                 __instance.Map.listerThings.ThingsMatchingFilter(__instance.ingredientFilter))
        {
            if (!__instance.ingredientFilter.Allows(possibleIngredient))
            {
                continue;
            }

            TargetHighlighter.Highlight(possibleIngredient);
            foundThingDefs.TryAdd(possibleIngredient.def, 0);
            foundThingDefs[possibleIngredient.def] += possibleIngredient.stackCount;
            foundThings.Add(possibleIngredient);
        }

        // If the right mouse button is clicked, marked all items in foundThings
        if (Event.current.button == 1)
        {
            Find.Selector.ClearSelection();
            foreach (var thing in foundThings)
            {
                Find.Selector.Select(thing, false, false);
            }
        }

        if (!foundThingDefs.Any())
        {
            return;
        }

        TooltipHandler.TipRegion(baseRect,
            $"{"SPM.availableOnMap".Translate()}{Environment.NewLine}" +
            $"{foundThingDefs.Select(kvp => $"{kvp.Value}x {kvp.Key.LabelCap}").ToLineList()}{Environment.NewLine}" +
            $"{"SPM.clickToMark".Translate()}");
    }
}