using HarmonyLib;
using PeteTimesSix.LIFE.ModCompat.RR_SS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using static HarmonyLib.AccessTools;

namespace PeteTimesSix.ResearchReinvented_SteppingStones.Patches
{
    [HarmonyPatch(typeof(ResearchProjectDef), "ClampInCoordinateLimits")]
    public static class ResearchProjectDef_ClampInCoordinateLimits_Patches
    {
        [HarmonyPrepare]
        public static bool ShouldPatch()
        {
            return !RR_SS.active;
        }

        [HarmonyPrefix]
        public static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(ResearchProjectDef), nameof(ResearchProjectDef.ConfigErrors))]
    public static class ResearchProjectDef_ConfigErrors_Patches
    {
        [HarmonyPrepare]
        public static bool ShouldPatch()
        {
            return !RR_SS.active;
        }

        [HarmonyPostfix]
        public static IEnumerable<string> Postfix(IEnumerable<string> __result)
        {
            foreach(string configError in __result) 
            {
                if(configError != "researchViewX and/or researchViewY not set")
                    yield return configError;
            }
        }

    }
}
