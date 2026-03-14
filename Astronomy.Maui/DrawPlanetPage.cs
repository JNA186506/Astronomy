using System.ComponentModel;
using System.Runtime.CompilerServices;
using Astronomy.core;

namespace Astronomy.Maui;

public class DrawPlanetPage : IDrawable, INotifyPropertyChanged {
    private double _moonTime;
    
    private float _scale = 100f;
    private float _distanceScale = 2000f;
    private const float MaxPlanetSize = 20f;
   
    private bool _hideText;
    public bool HideText {
        get => _hideText;
        set => _hideText = value;
    }

    private Planet _planet;

    public double MoonTime { 
        get => _moonTime;
        set {
            if (_moonTime != value) {
                _moonTime = value;
                OnPropertyChanged();
            } 
        } }  
    public double MoonSpeed { get; set; }

    public float DistanceScale {
        get => _distanceScale;
        set => _distanceScale = value;
    }

    public float Scale {
        get => _scale;
        set => _scale = value;
    }

    public DrawPlanetPage(Planet planet) {
        _planet = planet;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect) {
        var center = GetCanvasCenter(dirtyRect);

        canvas.FillColor = Color.Parse(_planet.Color);
        canvas.FillCircle(center, GetDisplayRadius(_planet));
        DrawLabel(canvas, _planet.Name, center, GetDisplayRadius(_planet));
        
        if (_planet.Moons != null) {
            var planetWorldPosition = _planet.CalculatePosition(MoonTime);
            foreach (var moon in _planet.Moons) {
                Color color = GetBodyColor(moon);

                var moonWorldPosition = moon.CalculatePosition(MoonTime);
                var moonRelativePosition = new Position(
                    moonWorldPosition.X - planetWorldPosition.X,
                    moonWorldPosition.Y - planetWorldPosition.Y);


                var planetDisplayPosition = ToScreenPosition(moonRelativePosition, center);

                DrawSpaceObject(canvas, moon, planetDisplayPosition, center, color);

            }
        }

    }
    
    private Color GetBodyColor(SpaceObject planet) {
        return Color.Parse(planet.Color);
    }

    private PointF GetCanvasCenter(RectF dirtyRect) => dirtyRect.Center;

    private double GetDisplayRadius(SpaceObject spaceObject) {
        return Math.Min(spaceObject.ObjectRadius / Scale, MaxPlanetSize);
    }

    private PointF ToScreenPosition(Position pos, PointF center) {
        return new PointF(
            center.X - (float)(pos.X / _distanceScale),
            center.Y - (float)(pos.Y / DistanceScale));
    }

    private float GetDisplayPath(SpaceObject spaceObject) {
        return (float) spaceObject.OrbitalRadius / DistanceScale;
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
            position.X - 25,
            position.Y + (float)radius + 4,
            55,
            20,
            HorizontalAlignment.Center,
            VerticalAlignment.Top);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}