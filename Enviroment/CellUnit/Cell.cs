using Biology.Cell_Requirements;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Biology.Enviroment.CellUnit
{
    internal class Cell
    {

        public  Traits Traits { get; set; }
        public string ID => "Cell";
        public EnergyData Energy { get; set; }

  
        // if null then no traits are passed down
        public Cell(Traits? traits)
        {

            
            if (traits != null)
            {
                Traits = new(traits.CurrentTraits);

            }
            else
            {
                Traits = new(null);
            }

            Energy = new();

        }

        public struct EnergyData
        {
            public int EnergyLVL { get; set; }
            public int EnergyUsage { get; set; }
        }


        public void SeekFood()
        {
            if (!HasEnergy()) return ;


        }

        public void Move()
        {
            // if you have energy move a chamber.
            if (!HasEnergy()) return;
            // called when you want to seek food or a mate.
        }

        public bool SeekMate()
        {
            if (!HasEnergy()) return false;
            return true;
        }

        private void Reproduce()
        {
            if (SeekMate())
            {
                PassDownTraits.Invoke(Traits);
            }
            // if asexual reproduction available 
            PassDownTraits.Invoke(Traits);
            
        }

        private void Scan()
        {
            // scan chambers depending on perception level.
        }

        internal void AssignLocation()
        {

        }

        internal void DisplayStats()
        {

        }

        public bool HasEnergy()
        {
            return Energy.EnergyLVL >= Energy.EnergyUsage;
        }

        internal event Action<Traits> PassDownTraits;

    }
}
