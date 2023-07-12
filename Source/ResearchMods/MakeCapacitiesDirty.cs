using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PeteTimesSix.LIFE.ResearchMods
{
    public class MakePlayerCapacitiesDirty : ResearchMod
    {
        public override void Apply()
        {
            var pawns = PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_OfPlayerFaction;
            foreach(Pawn pawn in pawns)
            {
                pawn.health.capacities.Notify_CapacityLevelsDirty();
            }    
        }
    }
}
