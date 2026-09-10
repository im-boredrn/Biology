using Microsoft.VisualBasic;
using System;

internal class Chamber
{

	object? currentobj;

	internal Chamber(object? obj)
	{
		currentobj = obj;
		//ChamberContentNames
	}


	internal void FillChamber(object passedinobj) // may be obselete 
	{
		currentobj = passedinobj;
	}

	internal struct ChamberLocation
	{
		internal int X { get; set; }
		internal int Y { get; set; }
	}
}
