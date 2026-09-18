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
                cell.Value.PassDownTraits += (trait)  =>
                {
                    ReproduceCell(trait);
                };
            }
            
            
        }

        private void ReproduceCell(Traits traits)
        {
            var cell = new Cell(traits);
            int key = Cells.Count ; 

            key += 1;
            Cells.Add(key, cell);

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
                Console.WriteLine($"#{id} , idk ");
            }
        }
    }
}
