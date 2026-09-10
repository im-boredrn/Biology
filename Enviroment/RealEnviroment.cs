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
                string regionName = $"region #{i}";

                Region region = new(i * 2, i * 2, i * 2, i, i * 2); // eventually randomize .then with seed or something like settings


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

            foreach (var (regionID, region)in ManagedRegions)
            {
                SaveEnviroment();
            }

        }

        public void DisplayRegionInfo()
        {
            Console.WriteLine($"MaxRegions : {MaxRegions}\n--------------------------------");

            foreach (var ( regionID, region) in ManagedRegions)
            {
                int id = regionID + 1;
                Console.WriteLine($"#{id}: {region.CurrentStatus}\n" +
                    $"Max Chambers :{region.MaxChambers} | Max Capacity {region.CarryingCapacity}\n" +
                    $"--------------------------------");

            }
        }

        public void SaveEnviroment()
        {
            using (var writer = new StreamWriter("regiondata.csv"))
            {
                writer.Write("RegionID,Status");

                foreach (var (regionName, region) in ManagedRegions)
                {
                    writer.WriteLine($"{regionName},{region.CurrentStatus},{region.ManagedChambers.Values}" +
                        $",{region.EnergyRefreshTime}");

                }


            }

        }
    }
}
