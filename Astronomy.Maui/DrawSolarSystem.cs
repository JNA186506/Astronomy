using System.ComponentModel;
using System.Runtime.CompilerServices;
using Astronomy.core;

namespace Astronomy.Maui;

public class DrawSolarSystem : IDrawable, INotifyPropertyChanged {

    private double _time;

    private readonly InitSystem planets = new();

    private float _scale = 2000f;
    private float _distanceScale = 3_000_000f;
    private const float MaxObjectSize = 10f;

    private bool _hideText;
    public bool HideText {
        get => _hideText;
        set => _hideText = value;
    }


    public double Time { 
        get => _time;
        set {
            if (_time != value) {
                _time = value;
                OnPropertyChanged();
            }
        }
    }
    public double Speed { get; set; }
    
    public float DistanceScale {
        get => _distanceScale;
        set => _distanceScale = value;
    }

    public float Scale {
        get => _scale;
        set => _scale = value;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect) {

        var center = GetCanvasCenter(dirtyRect);

        foreach (var planet in planets.solarSystem) {
            Color color = GetBodyColor(planet);

            var planetPosition = planet.CalculatePosition(Time);
            
            var planetDisplayPosition = ToScreenPosition(planetPosition, center);

            DrawSpaceObject(canvas, planet, planetDisplayPosition, center, color);
            
        }
        
    }
    private Color GetBodyColor(SpaceObject planet) {
        return Color.Parse(planet.Color);
    }

    private PointF GetCanvasCenter(RectF dirtyRect) => dirtyRect.Center;

    private double GetDisplayRadius(SpaceObject spaceObject) {
        
        if (DistanceScale > 3_000_000 && spaceObject is Star)
            return Math.Min(spaceObject.ObjectRadius / Scale, MaxObjectSize / 10);
        
        return Math.Min(spaceObject.ObjectRadius / Scale, MaxObjectSize);
    }

    private PointF ToScreenPosition(Position pos, PointF center) {
        return new PointF(
            center.X - (float)(pos.X / DistanceScale),
            center.Y - (float)(pos.Y / DistanceScale));
    }

    private float GetDisplayPath(SpaceObject spaceObject) {
        return (float)spaceObject.OrbitalRadius / DistanceScale;
    }
    
    private void DrawSpaceObject(ICanvas canvas, SpaceObject spaceObject, PointF position, PointF center, Color color) {
        double radius = GetDisplayRadius(spaceObject);
        float displayPath = GetDisplayPath(spaceObject);
        
        canvas.StrokeColor = Colors.Grey;
        canvas.StrokeSize = 1;
        canvas.DrawCircle(center.X, center.Y, displayPath);
        
        canvas.FillColor = color;
        canvas.FillCircle(position, radius);
        
        if (!HideText) {
            DrawLabel(canvas, spaceObject.Name, position, radius);
        }
 
    }

    private void DrawLabel(ICanvas canvas, string text, PointF position, double radius) {
        canvas.FontColor = Colors.White;
        canvas.FontSize = 12;
        canvas.DrawString(
            text,
            position.X - 20,
            position.Y + (float)radius + 4,
            60,
            20,
            HorizontalAlignment.Center,
            VerticalAlignment.Top);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    } 

}