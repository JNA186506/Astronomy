using Astronomy.core; 

public class InitSystem {

    public InitSystem() {

        var earthMoons = new List<SpaceObject>();
        var marsMoons = new List<SpaceObject>();
        var jupiterMoons = new List<SpaceObject>();
        var saturnMoons = new List<SpaceObject>();
        var uranusMoons = new List<SpaceObject>();
        var neptuneMoons = new List<SpaceObject>();

        solarSystem = new() {
            new Star("Sun", orbitalRadius: 0, orbitalPeriod: 0, objectRadius: 696_700, rotationalPeriod: 0,
                color: "Yellow"),

            new Planet("Mercury", orbitalRadius: 57_909_000, orbitalPeriod: 88, objectRadius: 2_439,
                rotationalPeriod: 1407, moons: new List<SpaceObject>(), color: "DarkGray"),

            new Planet("Venus", orbitalRadius: 108_940_000, orbitalPeriod: 225, objectRadius: 6_051,
                rotationalPeriod: -116, moons: new List<SpaceObject>(), color: "AntiqueWhite"),

            new Planet("Earth", orbitalRadius: 152_097_597, orbitalPeriod: 365, objectRadius: 6_371,
                rotationalPeriod: 24, moons: earthMoons, color: "DodgerBlue"),

            new Planet("Mars", orbitalRadius: 227_939_100, orbitalPeriod: 687, objectRadius: 3_389,
                rotationalPeriod: 24, moons: marsMoons, color: "OrangeRed"),

            new Planet("Jupiter", orbitalRadius: 778_500_000, orbitalPeriod: 4_332, objectRadius: 69_911,
                rotationalPeriod: 10, moons: jupiterMoons, color: "NavajoWhite"),

            new Planet("Saturn", orbitalRadius: 1_432_000_000, orbitalPeriod: 10_759, objectRadius: 58_232,
                rotationalPeriod: 11, moons: saturnMoons, color: "LightYellow"),

            new Planet("Uranus", orbitalRadius: 2_867_000_000, orbitalPeriod: 30_688, objectRadius: 25_362,
                rotationalPeriod: -17, moons: uranusMoons, color: "LightCyan"),

            new Planet("Neptune", orbitalRadius: 4_515_000_000, orbitalPeriod: 60_195, objectRadius: 24_622,
                rotationalPeriod: 16, moons: neptuneMoons, color: "RoyalBlue"),
        };

        earthMoons.Add(new Moon("The Moon", solarSystem[3], orbitalRadius: 384_399, orbitalPeriod: 27,
            objectRadius: 730, rotationalPeriod: 29, color: "White"));

        marsMoons.Add(new Moon("Phobos", solarSystem[4], orbitalRadius: 90_376, orbitalPeriod: 0.3,
            objectRadius: 11, rotationalPeriod: 0.3, color: "Gray"));
        marsMoons.Add(new Moon("Deimos", solarSystem[4], orbitalRadius: 230_463, orbitalPeriod: 1.3,
            objectRadius: 6, rotationalPeriod: 1.3, color: "DarkGray"));

        jupiterMoons.Add(new Moon("Io", solarSystem[5], orbitalRadius: 421_800, orbitalPeriod: 1.8,
            objectRadius: 1_821, rotationalPeriod: 1.8, color: "Yellow"));
        jupiterMoons.Add(new Moon("Europa", solarSystem[5], orbitalRadius: 671_100, orbitalPeriod: 3.5,
            objectRadius: 1_560, rotationalPeriod: 3.5, color: "Ivory"));
        jupiterMoons.Add(new Moon("Ganymede", solarSystem[5], orbitalRadius: 1_070_400, orbitalPeriod: 7.2,
            objectRadius: 2_634, rotationalPeriod: 7.2, color: "DarkGray"));
        jupiterMoons.Add(new Moon("Callisto", solarSystem[5], orbitalRadius: 1_882_700, orbitalPeriod: 16.7,
            objectRadius: 2_410, rotationalPeriod: 16.7, color: "SlateGray"));

        saturnMoons.Add(new Moon("Titan", solarSystem[6], orbitalRadius: 1_221_870, orbitalPeriod: 15.9,
            objectRadius: 2_574, rotationalPeriod: 15.9, color: "Orange"));
        saturnMoons.Add(new Moon("Enceladus", solarSystem[6], orbitalRadius: 238_020, orbitalPeriod: 1.4,
            objectRadius: 252, rotationalPeriod: 1.4, color: "White"));
        saturnMoons.Add(new Moon("Mimas", solarSystem[6], orbitalRadius: 185_540, orbitalPeriod: 0.9,
            objectRadius: 198, rotationalPeriod: 0.9, color: "LightGray"));
        saturnMoons.Add(new Moon("Rhea", solarSystem[6], orbitalRadius: 527_070, orbitalPeriod: 4.5,
            objectRadius: 764, rotationalPeriod: 4.5, color: "Gainsboro"));

        uranusMoons.Add(new Moon("Titania", solarSystem[7], orbitalRadius: 435_910, orbitalPeriod: 8.7,
            objectRadius: 788, rotationalPeriod: 8.7, color: "LightGray"));
        uranusMoons.Add(new Moon("Oberon", solarSystem[7], orbitalRadius: 583_520, orbitalPeriod: 13.5,
            objectRadius: 761, rotationalPeriod: 13.5, color: "DarkGray"));
        uranusMoons.Add(new Moon("Ariel", solarSystem[7], orbitalRadius: 191_020, orbitalPeriod: 2.5,
            objectRadius: 578, rotationalPeriod: 2.5, color: "White"));
        uranusMoons.Add(new Moon("Umbriel", solarSystem[7], orbitalRadius: 266_300, orbitalPeriod: 4.1,
            objectRadius: 584, rotationalPeriod: 4.1, color: "Gray"));

        neptuneMoons.Add(new Moon("Triton", solarSystem[8], orbitalRadius: 354_759, orbitalPeriod: 5.9,
            objectRadius: 1_353, rotationalPeriod: 5.9, color: "LightCyan"));
        neptuneMoons.Add(new Moon("Proteus", solarSystem[8], orbitalRadius: 117_647, orbitalPeriod: 1.1,
            objectRadius: 210, rotationalPeriod: 1.1, color: "DarkGray"));
    }

    public List<SpaceObject> solarSystem { get; set; }
}