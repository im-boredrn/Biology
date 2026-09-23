using System;
using System.Collections.Generic;
using System.Text;

namespace Biology.Enviroment
{
    internal class PositionBoard
    {
        public RealEnviroment RealEnviroment { get; set; }
        public PositionBoard()
        {
            RealEnviroment = new();
        }
    }
}
