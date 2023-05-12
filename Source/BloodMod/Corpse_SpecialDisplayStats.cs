using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace BloodMod;

[HarmonyPatch(typeof(Corpse), "SpecialDisplayStats")]
public static class Corpse_SpecialDisplayStats
{
    public static IEnumerable<StatDrawEntry> Postfix(IEnumerable<StatDrawEntry> values, Corpse __instance)
    {
        foreach (var statDrawEntry in values)
        {
            yield return statDrawEntry;
        }

        var named = DefDatabase<StatDef>.GetNamed("BloodAmount");
        var statValue = __instance.InnerPawn.GetStatValue(named);
        yield return new StatDrawEntry(named.category, named, statValue, StatRequest.For(__instance.InnerPawn));
    }
}