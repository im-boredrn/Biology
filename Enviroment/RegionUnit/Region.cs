using Biology.Cell_Requirements;
using System;
using System.Collections.Generic;
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
        public int MaxChambers; //Def
        internal Dictionary<int, Chamber> ManagedChambers = []; // State
        internal Region (int carryingCapacity, int maxEnergy, int energyRefreshTime, int status, int maxChambers)
        {
            CarryingCapacity = carryingCapacity;
            MaxEnergy = maxEnergy;
            EnergyRefreshTime = energyRefreshTime;
            CurrentStatus = Enum.GetValues<Status>().ElementAtOrDefault(status); // Could use this to randomize
            MaxChambers = maxChambers;
            

            if (ManagedChambers.Count == 0)
            {
                PopulateRegion();
            }
           
        }

        private void PopulateRegion()
        {
            for (int i = 0; i < MaxChambers; i++)
            {
                var chamber = new Chamber(null);
                int key = ManagedChambers.Count;
                int id = key += 1;
                ManagedChambers.Add(id, chamber);

                if (i <= 2)
                {
                    ManagedChambers[id].Location = new Chamber.ChamberLocation(1,i);
                }
                else if (i >= 3)
                {
                    ManagedChambers[id].Location = new Chamber.ChamberLocation(2, i);
                }
            }
        }

        internal void DisplayChamberInfo()
        {

            foreach (var (id, chamber) in ManagedChambers)
            {
                Console.WriteLine($"#{id}, X : {chamber.Location.X}, Y : {chamber.Location.Y}, Region :{this.Quadrant._quadrant}\n");
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

            using (var writer = new StreamWriter("regiondata.csv", append: true)) // overwriting each other
            {
                foreach (var (id, chamber) in ManagedChambers)
                {

                    writer.Write("ChamberID,X,Y,Quadrant\n");

                    int quad = this.Quadrant._quadrant + 1;
                    
                    writer.WriteLine($"{id},{chamber.Location.X},{chamber.Location.Y}" +
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
