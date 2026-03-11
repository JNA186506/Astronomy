using Astronomy.core;

namespace Astronomy.Maui;

public class DrawSolarSystem : IDrawable {

    private readonly InitSystem planets = new();

    private const float Scale = 1000f;
    private const float DistanceScale = 2_000_000f;
    private const float MinObjectSize = 4f;
    private const float MaxObjectSize = 30f;

    public double Time { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect) {

        var center = GetCanvasCenter(dirtyRect);

        foreach (var planet in planets.solarSystem) {
            Color color = GetBodyColor(planet);
            
            var planetPosition = planet.CalculatePosition(Time);
            
            var planetDisplayPosition = ToScreenPosition(planetPosition, center);
            DrawSpaceObject(canvas, planet, planetDisplayPosition, color);
            
            DrawOrbitalPath(canvas, planet, center);
        }
        
    }


    private static Color GetBodyColor(SpaceObject planet) {
        return Color.Parse(planet.Color);
    }

    private static PointF GetCanvasCenter(RectF dirtyRect) => dirtyRect.Center;

    private static double GetDisplayRadius(SpaceObject spaceObject) {

        if (spaceObject is Star) {
            return Math.Max(spaceObject.OrbitalRadius / Scale, MaxObjectSize);
        }
        return Math.Max(spaceObject.ObjectRadius / Scale, MinObjectSize);
    }

    private static PointF ToScreenPosition(Position pos, PointF center) {
        return new PointF(
            center.X - (float)(pos.X / DistanceScale),
            center.Y - (float)(pos.Y / DistanceScale));
    }

    private static float GetDisplayPath(SpaceObject spaceObject) {
        return (float) spaceObject.OrbitalRadius / DistanceScale;
    }

    private static void DrawOrbitalPath(ICanvas canvas, SpaceObject spaceObject, PointF center) {
        canvas.StrokeColor = Colors.Grey;
        canvas.StrokeSize = 1;
        canvas.DrawCircle(center.X, center.Y, GetDisplayPath(spaceObject));
    }

    private static void DrawSpaceObject(ICanvas canvas, SpaceObject spaceObject, PointF position, Color color) {
        canvas.FillColor = color;
        canvas.FillCircle(position, GetDisplayRadius(spaceObject));
    }
    
    
}