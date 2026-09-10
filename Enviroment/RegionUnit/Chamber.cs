using Microsoft.VisualBasic;
using System;

internal class Chamber
{

	object? currentobj;

	internal ChamberLocation Location { get; set; }

	internal Chamber(object? obj)
	{
		currentobj = obj;
		//ChamberContentNames
	}


	internal void FillChamber(object passedinobj) // may be obselete 
	{
		currentobj = passedinobj;
	}

	internal struct ChamberLocation(int x,int y)
	{
		internal int X { get; set; } = x;
		internal int Y { get; set; } = y; 


	}
}
