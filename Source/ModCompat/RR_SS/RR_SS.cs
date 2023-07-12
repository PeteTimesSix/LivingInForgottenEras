using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PeteTimesSix.LIFE.ModCompat.RR_SS
{
    [StaticConstructorOnStartup]
    public static class RR_SS
    {
        public static bool active = false;
        static RR_SS()
        {
            active = ModLister.GetActiveModWithIdentifier("PeteTimesSix.ResearchReinvented.SteppingStones") != null;
        }

    }
}
