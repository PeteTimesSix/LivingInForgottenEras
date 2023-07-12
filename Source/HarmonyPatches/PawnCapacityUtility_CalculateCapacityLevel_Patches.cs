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
    [HarmonyPatch(typeof(PawnCapacityUtility), nameof(PawnCapacityUtility.CalculateCapacityLevel))]
    public static class PawnCapacityUtility_CalculateCapacityLevel_Patches
    {
        [HarmonyPostfix]
        public static void CalculateCapacityLevel_Postfix(ref float __result, HediffSet diffSet, PawnCapacityDef capacity, List<PawnCapacityUtility.CapacityImpactor> impactors = null, bool forTradePrice = false)
        {
            if (Current.ProgramState != ProgramState.Playing) //only modify during game
                return;

            var pawn = diffSet?.pawn;
            if (pawn == null || pawn.Faction == null || !pawn.Faction.IsPlayer)
                return;

            if (capacity == PawnCapacityDefOf.Moving)
            {
                Modify(pawn, ResearchProjectDefOf_Custom.LIFE_Procioception, capacity, ref __result);
            }
            else if (capacity == PawnCapacityDefOf.Eating)
            {
                Modify(pawn, ResearchProjectDefOf_Custom.LIFE_FoodPrep, capacity, ref __result);
            }
            else if(capacity == PawnCapacityDefOf.Manipulation)
            {
                Modify(pawn, ResearchProjectDefOf_Custom.LIFE_ToolUse, capacity, ref __result);
            }
            else if(capacity == PawnCapacityDefOf.Talking)
            {
                Modify(pawn, ResearchProjectDefOf_Custom.LIFE_Speech, capacity, ref __result);
            }
        }

        private static void Modify(Pawn pawn, ResearchProjectDef project, PawnCapacityDef capacity, ref float val)
        {
            if (LIFE_Settings.IsModified(pawn, project))
            {
                var modifier = LIFE_Settings.GetModifier(project);
                val *= modifier;
                if (val < capacity.minValue)
                    val = capacity.minValue;
            }
        }
    }
}
