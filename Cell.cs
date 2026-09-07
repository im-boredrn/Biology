using Biology.Cell_Requirements;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Biology
{
    internal class Cell
    {



        public OffSpring OffSpring { get; set; }
        public Traits Traits { get; set; }

        public EnergyData Energy { get; set; }
    
        public Cell()
        {
            OffSpring = new();
            Traits = new();
            Energy = new();

        }

        public struct EnergyData
        {
            public int EnergyLVL { get; set; }
            public int EnergyUsage { get; set; }
        }


        public bool SeekFood()
        {
            if (!HasEnergy()) return false;


        }

        public bool SeekMate()
        {

        }

        public void Reproduce()
        {
            if (SeekMate())
            {
                OffSpring.CreateOffspring();
            }
        }

        public void DisplayStats()
        {

        }

        public bool HasEnergy()
        {
            return Energy.EnergyLVL >= Energy.EnergyUsage;
        }

    }
}
