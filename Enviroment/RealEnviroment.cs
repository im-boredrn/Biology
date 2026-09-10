using Biology.Enviroment.CellUnit;
using Biology.Enviroment.RegionUnit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biology.Enviroment
{
    internal class RealEnviroment
    {
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
                region.Quadrant = new Region.RegionQuadrant(quad) ;

                ManagedRegions.Add(i, region);
            }


        }

        public void KickOff()
        {
           foreach (var cell in CellManager.Cells)
            {
                ManagedRegions[1].ManagedChambers[1].FillChamber(cell);
            }
        }

        public void Tick()
        {

          

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
    }
}
