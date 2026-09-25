using Biology.Cell_Requirements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace Biology.Enviroment.RegionUnit
{
    public class Region
    {
        internal int CarryingCapacity { get; set; } = 100;
        internal int MaxEnergy { get; set; } = 100;
        internal int EnergyRefreshTime { get; set; } = 4;
        public Status CurrentStatus;// make random
        internal RegionQuadrant Quadrant { get; set; }
        public int MaxChambers = 25; //Def
        internal Dictionary<int, Chamber> ManagedChambers = []; // State
        internal Region (int carryingCapacity, int maxEnergy, int energyRefreshTime, int status)
        {
            CarryingCapacity = carryingCapacity;
            MaxEnergy = maxEnergy;
            EnergyRefreshTime = energyRefreshTime;
            CurrentStatus = Enum.GetValues<Status>().ElementAtOrDefault(status); // Could use this to randomize
            

            if (ManagedChambers.Count == 0)
            {
                PopulateRegion();
            }
           
        }

        private void PopulateRegion() // 1. Create Chambers along width 2. Go up a level and repeat
        {
            double chamberWidth = Math.Sqrt(MaxChambers);
            double chamberHeight = Math.Sqrt(MaxChambers);
            // for each row colomn starts at 0 and goes up.

            for (int row = 0; row < chamberHeight; row++)
            {
                for (int column = 0; column < chamberWidth; column++) // Pop Column
                {
                    var chamber = new Chamber();
                    int key = ManagedChambers.Count; // at the end it should be 5
                    int id = key += 1; // 1 at start
                    ManagedChambers.Add(id, chamber);


                    ManagedChambers[id].X = column;
                    ManagedChambers[id].Y = row;





                    // once I passes sqrt of MaxWidth move up

                } // when the for loop ends that means a column was populated.
                row++;
            }
            

          

        }

        internal void DisplayChamberInfo()
        {

            foreach (var (id, chamber) in ManagedChambers)
            {
                Console.WriteLine($"#{id}, X : {chamber.X}, Y : {chamber.Y}, Region :{this.Quadrant._quadrant}\n");
            }
        }

        internal struct RegionQuadrant(int quadrant)
        {

            internal int _quadrant = quadrant;
            internal int Quadrant
            {
                get => _quadrant;
                set
                {
                    if (value <= 0)
                    {
                        throw new Exception("Quadrant cannot be lower than 1");
                    }
                    _quadrant = value;
                }
            }
        }


        internal void SaveChambers()
        {

            using (var writer = new StreamWriter("regiondata.csv", append: true)) 
            {
                writer.Write("ChamberID,X,Y,Quadrant\n");

                foreach (var (id, chamber) in ManagedChambers)
                {


                    int quad = this.Quadrant._quadrant + 1;
                    
                    writer.WriteLine($"{id},{chamber.X},{chamber.Y}" +
                        $",{quad}");


                }
            }

             
        }

        public enum Status
        {
            Cold,
            Hot,

        }
    }
}
