using Astronomy.core; 

public class InitSystem {

    public InitSystem() {
        SolarSystem = new Dictionary<string, SpaceObject>() {
            {
                "sun",
                new Star("sun", orbitalRadius: 0, orbitalPeriod: 0, objectRadius: 696_700, rotationalPeriod: 0)
            }, {
                "terra",
                new Planet("terra", orbitalRadius: 152_097_597, orbitalPeriod: 365, objectRadius: 6371,
                    rotationalPeriod: 24)
            }
        };
        /*
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
        */

    }
    
    public Dictionary<string, SpaceObject> SolarSystem { get; set; }
     
}