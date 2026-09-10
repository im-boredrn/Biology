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


	internal void FillChamber(object passedinobj)
	{
		currentobj = passedinobj;
	}

	
}
