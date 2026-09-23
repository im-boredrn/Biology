using Biology.Cell_Requirements;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Biology.Enviroment.CellUnit.Cell_Requirements;

namespace Biology.Enviroment.CellUnit
{
    internal class Cell
    {

        public Traits Traits { get; set; }
        private readonly int ChildrenAmount;

        public enum HungerStatus //1
        {
            LowHunger,
            FineHunger,
            FullHunger
        }

        public enum EnergyStatus
        {
            LowEnergy,
            FineEnergy,
            FullEnergy
        }

        public enum ReproductionStatus
        {
            NoChildren,
            FewChildren,
            ManyChildren
        }
        public enum TemperatureStatus
        {
            Cold,
            Hot,
            Warm
        }

        public enum CurrentState
        {
            SeekingMate,
            SeekingFood,
            Resting,
            Eating
        }

        public CurrentState currentState; 

        public EnergyData Energy { get; set; }
        public Location CellLocation { get; set; }
        public CellPos Pos { get; set; }
        private readonly int FoodLVL;
  
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

        internal void SetState(CurrentState newState)
        {
            currentState = newState;
        }

        public HungerStatus GetHunger()
        {
          if (FoodLVL <= 20)
            {
                return HungerStatus.LowHunger;
            }
          if ( FoodLVL <= 100)
            {
                return HungerStatus.FineHunger;
            }
                return HungerStatus.FullHunger;
            
        }

        public EnergyStatus GetEnergy()
        {
            if (Energy.EnergyLVL <= 20)
            {
                return EnergyStatus.LowEnergy;
            }
            if (Energy.EnergyLVL <= 100)
            {
                return EnergyStatus.FineEnergy;
            }
            return EnergyStatus.FullEnergy;

        }
        public ReproductionStatus GetReproduction()
        {
            if (ChildrenAmount == 0)
            {
                return ReproductionStatus.NoChildren;
            }
            if (ChildrenAmount <= 20)
            {
                return ReproductionStatus.FewChildren;
            }
            return ReproductionStatus.ManyChildren;

        }

        //public TemperatureStatus GetTemperature()
        //{
        //    if (FoodLVL <= 20)
        //    {
        //        return HungerStatus.LowHunger;
        //    }
        //    if (FoodLVL <= 100)
        //    {
        //        return HungerStatus.FineHunger;
        //    }
        //    return HungerStatus.FullHunger;

        //}

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

        private void Scan() // Ignore / not possible with architecture
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
