using HarmonyLib;
using PeteTimesSix.LIFE.DefOfs;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PeteTimesSix.LIFE.HarmonyPatches
{
    [HarmonyPatch(typeof(HealthCardUtility), nameof(HealthCardUtility.GetPawnCapacityTip))]
    public static class HealthCardUtility_GetPawnCapacityTip_Patches
    {
        [HarmonyPatch]
        public static void GetPawnCapacityTip(ref string __result, Pawn pawn, PawnCapacityDef capacity)
        {
            if (Current.ProgramState != ProgramState.Playing) //only modify during game
                return;

            if (pawn.Faction == null || !pawn.Faction.IsPlayer)
                return;

            if (capacity == PawnCapacityDefOf.Moving)
            {
                Modify(pawn, ResearchProjectDefOf_Custom.LIFE_Procioception, capacity, ref __result);
            }
            else if (capacity == PawnCapacityDefOf.Eating)
            {
                Modify(pawn, ResearchProjectDefOf_Custom.LIFE_FoodPrep, capacity, ref __result);
            }
            else if (capacity == PawnCapacityDefOf.Manipulation)
            {
                Modify(pawn, ResearchProjectDefOf_Custom.LIFE_ToolUse, capacity, ref __result);
            }
            else if (capacity == PawnCapacityDefOf.Talking)
            {
                Modify(pawn, ResearchProjectDefOf_Custom.LIFE_Speech, capacity, ref __result);
            }
        }

        public static void Modify(Pawn pawn, ResearchProjectDef project, PawnCapacityDef capacity, ref string val)
        {
            val += "\n" + $"LIFE_CapacityTip_{project.defName}_NotResearched".Translate();
        }
    }
}
