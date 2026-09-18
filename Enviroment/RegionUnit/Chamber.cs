using Microsoft.VisualBasic;
using System;

internal class Chamber
{


	internal ChamberLocation Location { get; set; }

	internal Chamber()
	{
		//ChamberContentNames
	}


	

	internal struct ChamberLocation(int x,int y)
	{
		internal int X { get; set; } = x;
		internal int Y { get; set; } = y; 


	}
}
