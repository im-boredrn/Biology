using Biology.Cell_Requirements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biology.Enviroment.RegionUnit
{
    public class Region
    {

        // Temp
        // Energy Support -- how much this region can support
        internal int CarryingCapacity { get; set; } = 100;
        internal int MaxEnergy { get; set; } = 100;
        internal int EnergyRefreshTime { get; set; } = 4;
        public Status CurrentStatus;// make random

        public int MaxChambers; //Def
        internal Dictionary<int, Chamber> ManagedChambers = []; // State
        internal Region (int carryingCapacity, int maxEnergy, int energyRefreshTime, int status, int maxChambers)
        {
            CarryingCapacity = carryingCapacity;
            MaxEnergy = maxEnergy;
            EnergyRefreshTime = energyRefreshTime;
            CurrentStatus = Enum.GetValues<Status>().ElementAtOrDefault(status);
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
            }
        }

        internal void DisplayChamberInfo()
        {

            foreach (var (id, chamber) in ManagedChambers)
            {
                Console.WriteLine($"#{id},{chamber()}\n");
            }
        }

       
        public enum Status
        {
            Cold,
            Hot,

        }
    }
}
