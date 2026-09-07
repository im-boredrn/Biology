using Biology.Enviroment;

RealEnviroment env1 = new();

env1.KickOff();
env1.Tick();
Console.WriteLine("Read Cells?");

char result = Console.ReadKey().KeyChar;

if (result == 'Y' || result == 'y')
{
    Console.WriteLine("\nReading Cells!");


    foreach (var (name, region) in env1.ManagedRegions)
    {
    }
}

