using Astronomy; 

class MainProg {
     public static void Main(string[] args) {
        var solarSystem = new Dictionary<string, SpaceObject>
        {
            ["sun"]     = new Star("sun",     objectRadius: 696_340,  rotationalPeriod: 609.6,   orbitalPeriod: 365.25636, orbitalRadius: 149_598_261),
            ["mercury"] = new Planet("mercury", objectRadius: 2_439.7,  rotationalPeriod: 87.969,  orbitalPeriod: 87.969,    orbitalRadius: 57_909_000),
            ["terra"]   = new Planet("terra",   objectRadius: 6_371.0,  rotationalPeriod: 24.0,    orbitalPeriod: 365.25636, orbitalRadius: 149_598_261),
            ["venus"]   = new Planet("venus",   objectRadius: 6_051.8,  rotationalPeriod: 224.7,   orbitalPeriod: 224.7,     orbitalRadius: 58_205_000),
            ["mars"]    = new Planet("mars",    objectRadius: 3_390.0,  rotationalPeriod: 248.59,  orbitalPeriod: 686.980,   orbitalRadius: 33_900_000),
            ["jupiter"] = new Planet("jupiter", objectRadius: 70_911.0, rotationalPeriod: 11.862,  orbitalPeriod: 4332.588,  orbitalRadius: 71_492_000),
            ["saturn"]  = new Planet("saturn",  objectRadius: 58_232.0, rotationalPeriod: 10.723,  orbitalPeriod: 10759.024, orbitalRadius: 60_268_000),
            ["uranus"]  = new Planet("uranus",  objectRadius: 25_362.0, rotationalPeriod: 17.143,  orbitalPeriod: 30685.000, orbitalRadius: 25_559_000),
            ["neptune"] = new Planet("neptune", objectRadius: 24_622.0, rotationalPeriod: 16.710,  orbitalPeriod: 60190.000, orbitalRadius: 24_764_000),
            ["pluto"]   = new DwarfPlanet("pluto", objectRadius: 1_188.3, rotationalPeriod: 153.3, orbitalPeriod: 90560.000, orbitalRadius: 59_064_000),
        };

       
        var moon = new Moon("moon",(Planet)solarSystem["terra"], objectRadius: 1737.4, rotationalPeriod: 27.3216, orbitalPeriod: 27.3216, orbitalRadius: 384_784);
        
        solarSystem.Add("moon", moon);

        Console.WriteLine("Enter the number of days passed since 0");
        string input = Console.ReadLine();
        if (!double.TryParse(input, out double days)) {
            Console.WriteLine("Invalid input");
            return;
        }
        Console.WriteLine("Enter the name of the object you want to see:");
        string? name = Console.ReadLine();

        SpaceObject? objectFound = null;
        if (name != null) {
            objectFound = solarSystem[name];
        }

        if (objectFound != null) {
            objectFound.Draw();
            objectFound.CalculatePosition(days);
        } else {
            Console.WriteLine("Object not found");
        }

     }
}