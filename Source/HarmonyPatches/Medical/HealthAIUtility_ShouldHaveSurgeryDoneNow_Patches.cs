using HarmonyLib;
using PeteTimesSix.LIFE.DefOfs;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PeteTimesSix.LIFE.HarmonyPatches.Medical
{
    [HarmonyPatch(typeof(HealthAIUtility), nameof(HealthAIUtility.ShouldHaveSurgeryDoneNow))]
    public static class HealthAIUtility_ShouldHaveSurgeryDoneNow_Patches
    {
        [HarmonyPrefix]
        public static bool ShouldHaveSurgeryDoneNow_Prefix(ref bool __result, Pawn pawn)
        {
            if (LIFE_Mod.Settings.difficulty_FirstAid == LIFE_Settings.Difficulty.MANDATORY && !ResearchProjectDefOf_Custom.LIFE_FirstAid.IsFinished)
            {
                __result = false;
                return false;
            }
            return true;
        }
    }
}
