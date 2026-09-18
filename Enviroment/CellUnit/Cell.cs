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
        public Location CellLocation { get; set; }
  
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

        internal struct Location(int x, int y)
        {
            internal int X { get; set; } = x;
            internal int Y { get; set; } = y;
        }

        public void SeekFood()
        {
            if (!HasEnergy()) return ;
            //Scan for food -- if food found move
            
        }

        public void Move()
        {
            // if you have energy move a chamber.
            if (!HasEnergy()) return;
            
            if (CanMove())
            {
                int x = CellLocation.X;
                int y = CellLocation.Y ;

                CellLocation = new Location(x + 1, y + 1);
            }
            // called when you want to seek food or a mate.
        }

        public bool CanMove()
        {
            if (CellLocation.X <= 4 && CellLocation.Y <= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            // return picked up objects and their pos.
            // Different method : If object is desired i.e. food or mate then move towards it. 
            // if nothing is picked up then move around and keep scanning. Alternating between +x and +y and -x and -y when border is hit.
        }

      

        internal void AssignLocation(int x, int y)
        {
            CellLocation = new Location(x, y);
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
