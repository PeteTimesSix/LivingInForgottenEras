using PeteTimesSix.LIFE.DefOfs;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PeteTimesSix.LIFE.Stats
{
    public class StatPart_LIFEModifier : StatPart
    {
        public ResearchProjectDef project;

        public override string ExplanationPart(StatRequest req)
        {
            if (!req.HasThing || !(req.Thing is Pawn pawn))
            {
                return null;
            }
            else
            {
                if (LIFE_Settings.IsModified(pawn, project))
                {
                    return $"LIFE_CapacityTip_{project.defName}_NotResearched".Translate() + ": x" + LIFE_Settings.GetModifier(project).ToStringPercent();
                }
            }
            return null;
        }

        public override void TransformValue(StatRequest req, ref float val)
        {
            if (!req.HasThing || !(req.Thing is Pawn pawn))
            {
                return;
            }
            else
            {
                if (LIFE_Settings.IsModified(pawn, project))
                    val *= LIFE_Settings.GetModifier(project);
            }
            
        }
    }
}
