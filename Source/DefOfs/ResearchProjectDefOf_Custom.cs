using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PeteTimesSix.LIFE.DefOfs
{
    [DefOf]
    public static class ResearchProjectDefOf_Custom
    {
        public static ResearchProjectDef LIFE_ToolUse;
        public static ResearchProjectDef LIFE_Speech;
        public static ResearchProjectDef LIFE_Procioception;
        public static ResearchProjectDef LIFE_FoodPrep;
        public static ResearchProjectDef LIFE_FirstAid;

        static ResearchProjectDefOf_Custom()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ResearchProjectDefOf_Custom));
        }
    }
}
