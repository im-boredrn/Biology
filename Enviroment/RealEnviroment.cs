using System;
using System.Collections.Generic;
using System.Text;

namespace Biology.Enviroment
{
    internal class RealEnviroment
    {
        int  MaxRegions { get; set; } = 4;


        public Dictionary<string,Region> ManagedRegions = [];
        public RealEnviroment()
        {
            for (int i = 0; i < MaxRegions; i++)
            {
                string regionName = $"region {i}";

                Region region = new (i * 2, i * 2, i * 2, i);


                ManagedRegions.Add(regionName,region);
            }

            
        }

        public void KickOff()
        {

            foreach (var (regionName, region) in ManagedRegions)
            region.SpawnLife(2);
        }

        public void Tick()
        {
            Console.WriteLine($"MaxRegions : {MaxRegions}");

            foreach (var (regionName, region)in ManagedRegions)
            {
                DisplayRegionInfo(regionName, region);
                SaveRegionInfo();
            }

        }

        public void DisplayRegionInfo(string regionName, Region region)
        {
            
                Console.WriteLine($"{regionName}: {region.CurrentStatus}\n Current Cells :{region.Cells.Count} ");
            


            // Those regions stats
        }

        public void SaveRegionInfo()
        {
            using (var writer = new StreamWriter("regiondata.csv"))
            {
                writer.Write("RegionName,Status");

                foreach (var (regionName, region) in ManagedRegions)
                {
                    writer.WriteLine($"{regionName},{region.CurrentStatus}");

                }


            }

        }

        public void DisplayCellInfo()
        {
            // use reflection
        }
    }
}
