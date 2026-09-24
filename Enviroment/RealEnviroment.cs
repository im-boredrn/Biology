using Biology.Enviroment.CellUnit;
using Biology.Enviroment.RegionUnit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biology.Enviroment
{
    internal class RealEnviroment
    {
        //Pos movers and world alterers need to be here
        // Cell shouldn't be able to alter above it.
        int  MaxRegions { get; set; } = 4;
        internal CellManager CellManager { get; }

        public Dictionary<int,Region> ManagedRegions = [];
        public RealEnviroment()
        {
            if (ManagedRegions.Count == 0)
            {
                PopulateWorld();
            }
            CellManager = new();

            
        }

        private void PopulateWorld()
        {

            for (int i = 0; i < MaxRegions; i++)
            {

                Region region = new(i * 2, i * 2, i * 2, i, i * 2); // eventually randomize .then with seed or something like settings

                int quad = i ;
                region.Quadrant = new Region.RegionQuadrant(quad) ; // Treat each quadrant as a coordinate plane. Somehow.

                ManagedRegions.Add(i, region);
            }


        }

        public void KickOff()
        {
         
        }

        public void Tick()
        {
            CellManager.Cycle();
          

        }

        private void ProximityTracker() // Reads Current Pos of EVERY object in the world.
        {
            // if two objects are one chamber away then they are touching.
        }

        private void CollisionTracker()
        {
          if (ManagedRegions.Get) // Omg get their positions in an array.

                    // Get Cell positions in an array and cross match.
        }

        public void DisplayRegionInfo()
        {
            Console.WriteLine($"MaxRegions : {MaxRegions}\n--------------------------------");

            foreach (var ( regionID, region) in ManagedRegions)
            {
                int id = regionID + 1;
                Console.WriteLine($"#{id}: {region.CurrentStatus}\n" +
                    $"Max Chambers :{region.MaxChambers} | Max Capacity {region.CarryingCapacity}\n" +
                    $"Quadrant : {id }\n" +
                    $"--------------------------------");

            }
        }

        public void SaveEnviroment()
        {
            using (var writer = new StreamWriter("enviromentdata.csv"))
            {
                writer.Write("RegionID,Status,ManagedChambers,EnergyRefreshTime,MC,Quadrant\n");

                foreach (var (regionID, region) in ManagedRegions)
                {
                    int id = regionID + 1;

                    writer.WriteLine($"{id},{region.CurrentStatus},{region.ManagedChambers.Count}" +
                        $",{region.EnergyRefreshTime},{region.CarryingCapacity},{id}");

                    region.SaveChambers();

                }

            }

        }

        public void LoadEnviroment()
        {
            using (var reader = new StreamReader("enviromentdata.csv"))
            {

            }
        }
    }
}
