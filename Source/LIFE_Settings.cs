using PeteTimesSix.LIFE.DefOfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace PeteTimesSix.LIFE
{
    public class LIFE_Settings: ModSettings
    {
        internal Difficulty difficulty_ToolUse;
        internal Difficulty difficulty_Speech;
        internal Difficulty difficulty_FirstAid;

        internal DifficultyNecessary difficulty_FoodPrep;
        internal DifficultyNecessary difficulty_Procioception;

        public enum Difficulty 
        {
            MANDATORY,
            ROUGH,
            MANAGEABLE,
            FORGIVING,
            MINIMAL,
            DISABLED
        }

        public enum DifficultyNecessary
        {
            ROUGH,
            MANAGEABLE,
            FORGIVING,
            MINIMAL,
            DISABLED
        }

        public override void ExposeData()
        {
            base.ExposeData();
            //Scribe_Values.Look(ref defaultCompactMode, "defaultCompactMode", false);

        }

        public void DoSettingsWindowContents(Rect inRect)
        {

        }

        private static float DifficultyToModifier(Difficulty difficulty)
        {
            switch(difficulty)
            {
                case Difficulty.MANDATORY:
                    return 0f;
                case Difficulty.ROUGH:
                    return 0.05f;
                case Difficulty.MANAGEABLE:
                    return 0.2f;
                case Difficulty.FORGIVING:
                    return 0.5f;
                case Difficulty.MINIMAL:
                    return 0.85f;
                case Difficulty.DISABLED:
                default:
                    return 1f;
            }
        }

        private static float DifficultyToModifier(DifficultyNecessary difficulty)
        {
            switch (difficulty)
            {
                case DifficultyNecessary.ROUGH:
                    return 0.25f;
                case DifficultyNecessary.MANAGEABLE:
                    return 0.5f;
                case DifficultyNecessary.FORGIVING:
                    return 0.75f;
                case DifficultyNecessary.MINIMAL:
                    return 0.9f;
                case DifficultyNecessary.DISABLED:
                default:
                    return 1f;
            }
        }

        public static bool IsModified(Pawn pawn, ResearchProjectDef project)
        {
            if (Current.ProgramState != ProgramState.Playing) //only modify during game
                return false;

            if (pawn == null || pawn.Faction == null || !pawn.Faction.IsPlayer || pawn.NonHumanlikeOrWildMan())
                return false;

            if (project == ResearchProjectDefOf_Custom.LIFE_ToolUse)
            {
                if (ResearchProjectDefOf_Custom.LIFE_ToolUse.IsFinished)
                    return false;
                else
                    return LIFE_Mod.Settings.difficulty_ToolUse != LIFE_Settings.Difficulty.DISABLED;
            }
            else if (project == ResearchProjectDefOf_Custom.LIFE_Speech)
            {
                if (ResearchProjectDefOf_Custom.LIFE_Speech.IsFinished)
                    return false;
                else
                    return LIFE_Mod.Settings.difficulty_Speech != LIFE_Settings.Difficulty.DISABLED;
            }
            else if (project == ResearchProjectDefOf_Custom.LIFE_Procioception)
            {
                if (ResearchProjectDefOf_Custom.LIFE_Procioception.IsFinished)
                    return false;
                else
                    return LIFE_Mod.Settings.difficulty_Procioception != LIFE_Settings.DifficultyNecessary.DISABLED;
            }
            else if (project == ResearchProjectDefOf_Custom.LIFE_FoodPrep)
            {
                if (ResearchProjectDefOf_Custom.LIFE_FoodPrep.IsFinished)
                    return false;
                else
                    return LIFE_Mod.Settings.difficulty_FoodPrep != LIFE_Settings.DifficultyNecessary.DISABLED;
            }
            else if (project == ResearchProjectDefOf_Custom.LIFE_FirstAid)
            {
                if (ResearchProjectDefOf_Custom.LIFE_FirstAid.IsFinished)
                    return false;
                else
                    return LIFE_Mod.Settings.difficulty_FirstAid != LIFE_Settings.Difficulty.DISABLED;
            }

            return false;
        }

        public static float GetModifier(ResearchProjectDef project)
        {
            if (project == ResearchProjectDefOf_Custom.LIFE_ToolUse)
            {
                return LIFE_Settings.DifficultyToModifier(LIFE_Mod.Settings.difficulty_ToolUse);
            }
            else if (project == ResearchProjectDefOf_Custom.LIFE_Speech)
            {
                return LIFE_Settings.DifficultyToModifier(LIFE_Mod.Settings.difficulty_Speech);
            }
            else if (project == ResearchProjectDefOf_Custom.LIFE_Procioception)
            {
                return LIFE_Settings.DifficultyToModifier(LIFE_Mod.Settings.difficulty_Procioception);
            }
            else if (project == ResearchProjectDefOf_Custom.LIFE_FoodPrep)
            {
                return LIFE_Settings.DifficultyToModifier(LIFE_Mod.Settings.difficulty_FoodPrep);
            }
            else if (project == ResearchProjectDefOf_Custom.LIFE_FirstAid)
            {
                return LIFE_Settings.DifficultyToModifier(LIFE_Mod.Settings.difficulty_FirstAid);
            }
            return 1f;
        }
    }
}
