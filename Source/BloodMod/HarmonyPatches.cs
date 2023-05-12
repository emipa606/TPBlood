using System.Reflection;
using HarmonyLib;
using Verse;

namespace BloodMod;

[StaticConstructorOnStartup]
internal static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("rimworld.trahspanda.bloodmod").PatchAll(Assembly.GetExecutingAssembly());
    }
}