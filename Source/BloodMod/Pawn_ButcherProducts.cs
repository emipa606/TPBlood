using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace BloodMod;

[HarmonyPatch(typeof(Pawn), "ButcherProducts")]
public static class Pawn_ButcherProducts
{
    public static IEnumerable<Thing> Postfix(IEnumerable<Thing> values, Pawn __instance, float efficiency)
    {
        if (values == null || !values.Any())
        {
            yield break;
        }

        foreach (var value in values)
        {
            yield return value;
        }

        var stackCount =
            GenMath.RoundRandom(__instance.GetStatValue(DefDatabase<StatDef>.GetNamed("BloodAmount")) * efficiency);

        if (stackCount < 1)
        {
            yield break;
        }

        var thing = ThingMaker.MakeThing(DefDatabase<ThingDef>.GetNamed("BloodItem"));
        thing.stackCount = stackCount;
        yield return thing;
    }
}