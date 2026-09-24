using System;
using System.Collections.Generic;
using System.Text;
using Biology.Cell_Requirements;
namespace Biology.Enviroment.CellUnit
{
    internal class CellManager
    {


        public Dictionary<int, Cell> Cells { get; private set; } = []; // state
        internal CellManager()
        {
            if (Cells.Count == 0)
            {
                CreateCell();
            }

            WireEvents();
        }

        public void WireEvents()
        {
            foreach (var cell in Cells)
            {
                cell.Value.PassDownTraits += (trait) =>
                {
                    ReproduceCell(trait);
                };

                cell.Value.SetState(DecidePriority(cell.Value));
            }


        }

        public void Cycle()
        {
            foreach (var cell in Cells)
            {
               

                cell.Value.SetState(DecidePriority(cell.Value));
            }

        }

        public enum CurrentState
        {
            SeekingMate,
            SeekingFood,
            Resting,
            Eating
        }

        private void ReproduceCell(Traits traits)
        {
            var cell = new Cell(traits);
            int key = Cells.Count ; 

            key += 1;
            Cells.Add(key, cell);

        }

        private static CurrentState DecidePriority( Cell cell)
        {
            
                if (cell.GetHunger() == Cell.HungerStatus.LowHunger)
                {
                    return CurrentState.SeekingFood; 
                }

                if (cell.GetEnergy() == Cell.EnergyStatus.LowEnergy)
                {
                    return CurrentState.Resting; 
                }
            // if hunger is fine and energy is fine then target the lows first



            if (cell.GetReproduction() == Cell.ReproductionStatus.NoChildren)
                {
                    return CurrentState.SeekingMate; 
                }

            return CurrentState.Resting;

            //if (cell.GetEnergy() == Cell.EnergyStatus.FineEnergy)
            //{
            //    return CurrentState.S;
            //}


            //if (cell.GetReproduction() == Cell.ReproductionStatus.NoChildren)
            //{
            //    return CurrentState.SeekingMate;
            //}


        }



        private void CreateCell()
        {
            var cell = new Cell(null);
            int key = Cells.Count;

            key += 1;
            Cells.Add(key, cell);
            Cells[key].AssignLocation(1, 1);

        }

        private void SaveCells()
        {

        }

        internal void DisplayCellsData()
        {
            foreach (var (id, cell) in Cells)
            {
                Console.WriteLine($"#{id} , {cell.GetHunger()}, {cell.GetEnergy()}, {cell.GetReproduction()}");
            }
        }
    }
}
