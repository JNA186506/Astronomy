using Astronomy.core;

namespace Astronomy.Maui;

public class DrawSolarSystem : IDrawable {
    
    private InitSystem planets = new();
    
    public void Draw(ICanvas canvas, RectF dirtyRect) {

        const int scale = 10_000;

        SpaceObject sun = planets.SolarSystem["sun"];
        double sunCircumferanceDisplay = sun.ObjectRadius / scale;

        var middleX = dirtyRect.Right / 2;
        var middleY = dirtyRect.Bottom / 2;
        canvas.FillColor = Colors.Orange;
        canvas.FillCircle(new Point(middleX, middleY), sunCircumferanceDisplay);
        
        
        
    }
}