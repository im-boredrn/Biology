using System;
using System.Collections.Generic;
using System.Text;

namespace Biology.Cell_Requirements
{
    public class OffSpring
    {




        public int ReproductionSuccess;
        public int Mutability;



        public List<Traits.PTraits> PTraits = Enum.GetValues<Traits.PTraits>().Cast<Traits.PTraits>().ToList();
        public List<Traits.PTraits> ActiveTraits = [];

        public OffSpring()
        {
            ReproductionSuccess = 1;
            Mutability = 1;
        }

        public void CreateOffspring()
        {
            new Cell();
        }
        public void GainTrait()
        {
            // if random x * Mutability is above y add trait.
            Random rnd = new();
            int between0And100 = rnd.Next(0, 100);

            if (between0And100 >= 50)
            {
                if (PTraits.Count > 0)
                {
                    int index = rnd.Next(PTraits.Count);
                    ActiveTraits.Add(PTraits[index]);

                }
            }
        }

        public void LoseTrait()
        {

        }
    }
}
