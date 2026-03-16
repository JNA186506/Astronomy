namespace Astronomy.core;

public struct Position {
    public double X { get; set;}
    public double Y { get; set; }
    
    public Position(double x, double y) {
        X = x;
        Y = y;
    }
    
    public override string ToString() => $"({X}, {Y})";
}

public class SpaceObject {
    public SpaceObject(string name, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0, string color = "") {
        
        Name = name;
        OrbitalRadius = orbitalRadius;
        OrbitalPeriod = orbitalPeriod;
        ObjectRadius = objectRadius;
        RotationalPeriod = rotationalPeriod;
        Color = color;
    }

    public string Name { get; protected set; }
    public double OrbitalRadius { get; protected set; }
    public double OrbitalPeriod { get; protected set; }
    public double ObjectRadius { get; protected set; }
    public double RotationalPeriod { get; protected set; }
    public List<SpaceObject> Moons { get; set; }
    public string Color { get; set; }
 
    public virtual void Draw() {
        Console.WriteLine(Name);
    }

    public virtual Position CalculatePosition(double time) {
        if (time == 0) return new Position(0, 0);
        
        double angle = 2 * Math.PI * (time / OrbitalPeriod);
        double x = OrbitalRadius * Math.Cos(angle);
        double y = OrbitalRadius * Math.Sin(angle);
        
        return new Position(x, y);
    }

}

public class Star : SpaceObject {
    public Star(string name, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0, string color = "") : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, color) {
        
    }

    public override Position CalculatePosition(double time) => new Position(0, 0);
    
    public override void Draw() {
        Console.WriteLine("Star : ");
        base.Draw();
    }
}

public class Planet : SpaceObject {
    private List<SpaceObject>? moons;
    public Planet(string name, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0, List<SpaceObject>? moons = null, string color = "") : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, color) {

        Moons = moons;
    }
    
    public List<SpaceObject>? Moons { get; set; }
    
    public override void Draw() {
        Console.WriteLine("Planet : ");
        base.Draw();
    }
}

public class Moon : SpaceObject {
    private SpaceObject _ParentPlanet;
    
    public Moon(string name, SpaceObject parentPlanet, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0, string color = "") : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, color) {
        
        _ParentPlanet = parentPlanet;
    }

    public SpaceObject ParentPlanet {
        get => _ParentPlanet;
        set => _ParentPlanet = value;
    }

    public override Position CalculatePosition(double time) {
        Position parentPosition = _ParentPlanet.CalculatePosition(time);
        
        if (time == 0) return parentPosition;
        
        double angle = 2 * Math.PI * (time / OrbitalPeriod);
        double x = OrbitalRadius * Math.Cos(angle);
        double y = OrbitalRadius * Math.Sin(angle);
        
        return new Position(parentPosition.X + x, parentPosition.Y + y);
    }

    public override void Draw() {
        Console.WriteLine("Moon : ");
        base.Draw();
    }
}

public class DwarfPlanet : SpaceObject {
    public DwarfPlanet(string name, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0, string color = "") : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, color) {
        
    }
    
    public override void Draw() {
        Console.WriteLine("Dwarf Planet : ");
        base.Draw();
    }
}

public class Asteriod : SpaceObject {
    public Asteriod(string name, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0, string color = "") : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, color) {
        
    }
    
    public override void Draw() {
        Console.WriteLine("Asteriod : ");
        base.Draw();
    }
}

public class AsteriodBelt : SpaceObject {
    private double _InnerRadius;
    private double _OuterRadius;
    
    public AsteriodBelt(string name, double innerRadius, double outerRadius, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0, string color = "") : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, color) {
        
        _InnerRadius = innerRadius;
        _OuterRadius = outerRadius;
    }
    
    public double InnerRadius { get => _InnerRadius; set => _InnerRadius = value; }
    public double OuterRadius { get => _OuterRadius; set => _OuterRadius = value; }
    
    public override void Draw() {
        Console.WriteLine("Asteriod Belt : ");
        Console.WriteLine($"Inner Radius : {_InnerRadius}, Outer Radius : {_OuterRadius}");
        base.Draw();
    }
}

public class Comet : SpaceObject {
    public Comet(string name, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0, string color = "") : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, color) {
        
    }
    
    public override void Draw() {
        Console.WriteLine("Comet : ");
        base.Draw();
    }
}