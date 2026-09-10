using Biology.Enviroment;

RealEnviroment env1 = new();

env1.KickOff();
env1.Tick();
Console.WriteLine("Inspect?");
Console.WriteLine("E for enviroment,R for regions, C for Cells, S to save");

char result = Console.ReadKey().KeyChar;



if (result == 'E' || result == 'e')
{
    Console.WriteLine("\nReading Enviroment!\n");


    env1.DisplayRegionInfo();
}
if (result == 'R' || result == 'r')
{
    Console.WriteLine("\nReading Regions!");


    foreach (var (id, region) in env1.ManagedRegions)
    {
        region.DisplayChamberInfo();
    }
}

if (result == 'C' || result == 'c')
{
    Console.WriteLine("\nReading Cells!");


    foreach (var (cellID, cell) in env1.CellManager.Cells)
    {
    }
}

if (result == 'S' || result == 's')
{
    Console.WriteLine("\n Saving Enviroment!");

    env1.SaveEnviroment();
  
}




