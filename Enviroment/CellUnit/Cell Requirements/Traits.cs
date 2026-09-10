using System;
using System.Collections.Generic;
using System.Text;

namespace Biology.Cell_Requirements
{
    internal class Traits( List<Traits.PossibleTraits>? inheritedTraits)
    {
        public List<Traits.PossibleTraits> CurrentTraits = [];
        internal List<Traits.PossibleTraits>? StartingTraits = inheritedTraits;


        public enum PossibleTraits
        {
            Fertile,
            Infertile,
            Fast,
            Slow,
            Efficient,
            Wasteful,
            HeatTolerance,
            HeatWeakness,
            ColdTolerance,
            ColdWeakness,
            LongLived,
            ShortLived,
            
        
        }
    }
}
