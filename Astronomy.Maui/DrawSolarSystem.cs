using Astronomy.core;
using Microsoft.Maui.Graphics;

namespace Astronomy.Maui;

public class DrawSolarSystem : IDrawable {

    private readonly InitSystem planets = new();

    private const float Scale = 10_000f;
    private const float DistanceScale = 1_000_000f;

    public double Time { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect) {

        var center = GetCanvasCenter(dirtyRect);

        foreach (var planet in planets.solarSystem) {
            Color color = GetBodyColor(planet);
            
            var planetPosition = planet.CalculatePosition(Time);
            var planetDisplayPosition = ToScreenPosition(planetPosition, center);
            DrawSpaceObject(canvas, planet, planetDisplayPosition, color);
            
        }
    }


    private static Color GetBodyColor(SpaceObject planet) {
        return Color.Parse(planet.Color);
    }

    private static PointF GetCanvasCenter(RectF dirtyRect) => dirtyRect.Center;

    private static double GetDisplayRadius(SpaceObject spaceObject) {
        return (double) spaceObject.ObjectRadius / Scale;
    }

    private static PointF ToScreenPosition(Position pos, PointF center) {
        return new PointF(
            center.X - (float)(pos.X / DistanceScale),
            center.Y - (float)(pos.Y / DistanceScale));
    }

    private static void DrawSpaceObject(ICanvas canvas, SpaceObject spaceObject, PointF position, Color color) {
        canvas.FillColor = color;
        canvas.FillCircle(position, GetDisplayRadius(spaceObject));
    }
    
    
}