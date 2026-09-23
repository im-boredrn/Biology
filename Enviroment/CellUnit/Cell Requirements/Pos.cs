using System;
using System.Collections.Generic;
using System.Text;

namespace Biology.Enviroment.CellUnit.Cell_Requirements
{
    internal class CellPos
    {

            internal int X { get; set; }
            internal int Y { get; set; }
        
        public object Pinged()
        {
            return this;
        }

        public void Ping()
        {
            // send out event or something to everything inside Pos + perception.

        }

    }
}
