using System;
using System.Collections.Generic;
using System.Text;

namespace Biology.Enviroment
{
    public class Region
    {

        // Temp
        // Energy Support -- how much this region can support
        int CarryingCapacity { get; set; } = 100;
        int MaxEnergy { get; set; } = 100;
        int EnergyRefreshTime { get; set; } = 4;
        public Status CurrentStatus;// make random

        internal Cell? Cell { get; }
        internal List<Cell> Cells = [];
        public Region (int carryingCapacity, int maxEnergy, int energyRefreshTime, int status)
        {
            CarryingCapacity = carryingCapacity;
            MaxEnergy = maxEnergy;
            EnergyRefreshTime = energyRefreshTime;
            CurrentStatus = Enum.GetValues<Status>().ElementAtOrDefault(status);
            
        }

        public void SpawnLife(int amount)
        {
           for (int i = 0; i < amount; i++)
            {
                Cell cell = new();
                
                Cells.Add(cell);
            }
        }


        public enum Status
        {
            Cold,
            Hot,

        }
    }
}
