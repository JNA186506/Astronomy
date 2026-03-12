using Astronomy.core;

namespace Astronomy.Maui;

public class DrawSolarSystem : IDrawable {

    private readonly InitSystem planets = new();

    private const float Scale = 1000f;
    private const float DistanceScale = 2_000_000f;
    private const float MaxObjectSize = 20f;

    public double Time { get; set; }
    public double Speed { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect) {

        var center = GetCanvasCenter(dirtyRect);

        foreach (var planet in planets.solarSystem) {
            Color color = GetBodyColor(planet);

            Time = Speed + Time;
            
            var planetPosition = planet.CalculatePosition(Time);
            
            var planetDisplayPosition = ToScreenPosition(planetPosition, center);
            DrawSpaceObject(canvas, planet, planetDisplayPosition, center, color);
            
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
        return spaceObject.ObjectRadius / Scale;
    }

    private static PointF ToScreenPosition(Position pos, PointF center) {
        return new PointF(
            center.X - (float)(pos.X / DistanceScale),
            center.Y - (float)(pos.Y / DistanceScale));
    }

    private static float GetDisplayPath(SpaceObject spaceObject) {
        return (float) spaceObject.OrbitalRadius / DistanceScale;
    }
    
    private static void DrawSpaceObject(ICanvas canvas, SpaceObject spaceObject, PointF position, PointF center, Color color) {
        canvas.StrokeColor = Colors.Grey;
        canvas.StrokeSize = 1;
        canvas.DrawCircle(center.X, center.Y, GetDisplayPath(spaceObject));
        
        canvas.FillColor = color;
        canvas.FillCircle(position, GetDisplayRadius(spaceObject));
    }
    
    
}