namespace Astronomy;

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
        double objectRadius = 0, double rotationalPeriod = 0) {
        
        Name = name;
        OrbitalRadius = orbitalRadius;
        OrbitalPeriod = orbitalPeriod;
        ObjectRadius = objectRadius;
        RotationalPeriod = rotationalPeriod;
    }

    public string Name { get; protected set; }
    public double OrbitalRadius { get; protected set; }
    public double OrbitalPeriod { get; protected set; }
    public double ObjectRadius { get; protected set; }
    public double RotationalPeriod { get; protected set; }
 
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

    public virtual Position GetPolarPosition(Position position, double scale = 1) {
        double distance = Math.Sqrt(position.X * position.X + position.Y * position.Y) / scale;
        double angle = Math.Atan2(position.Y, position.X);
        
        return new Position(distance, angle);
    }

}

public class Star : SpaceObject {
    public Star(string name, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0) : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod) {
        
    }

    public override Position CalculatePosition(double time) => new Position(0, 0);
    
    public override Position GetPolarPosition(Position position, double scale = 1) => new Position(0, 0);
    
    public override void Draw() {
        Console.WriteLine("Star : ");
        base.Draw();
    }
}

public class Planet : SpaceObject {
    public Planet(string name, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0) : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod) {
        
    }
    
    public override void Draw() {
        Console.WriteLine("Planet : ");
        base.Draw();
    }
}

public class Moon : SpaceObject {
    private SpaceObject _ParentPlanet;
    
    public Moon(string name, Planet parentPlanet, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0) : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod) {
        
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

    public override Position GetPolarPosition(Position position, double scale = 1) {
        Position parentPosition = _ParentPlanet.GetPolarPosition(position, scale);
        
        double dx = position.X - parentPosition.X;
        double dy = position.Y - parentPosition.Y;
        
        double distance = Math.Sqrt(dx * dx + dy * dy) / scale;
        double angle = Math.Atan2(dy, dx);
        
        return new Position(parentPosition.X + distance * Math.Cos(angle), parentPosition.Y + distance * Math.Sin(angle));
    }
    
    public override void Draw() {
        Console.WriteLine("Moon : ");
        base.Draw();
    }
}

public class DwarfPlanet : SpaceObject {
    public DwarfPlanet(string name, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0) : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod) {
        
    }
    
    public override void Draw() {
        Console.WriteLine("Dwarf Planet : ");
        base.Draw();
    }
}

public class Asteriod : SpaceObject {
    public Asteriod(string name, double orbitalRadius = 0, double orbitalPeriod = 0, 
        double objectRadius = 0, double rotationalPeriod = 0) : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod) {
        
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
        double objectRadius = 0, double rotationalPeriod = 0) : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod) {
        
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
        double objectRadius = 0, double rotationalPeriod = 0) : 
        base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod) {
        
    }
    
    public override void Draw() {
        Console.WriteLine("Comet : ");
        base.Draw();
    }
}