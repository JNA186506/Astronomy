using System.Collections.ObjectModel;
using System.ComponentModel;
using Astronomy.core;

namespace Astronomy.Maui;

public partial class PlanetPage : ContentPage {
    
    private DrawPlanetPage drawPlanetPage;
    public DrawPlanetPage DrawPlanetPage => drawPlanetPage;
    private IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
    private readonly InitSystem planets = new(); 
    public ObservableCollection<SpaceObject> Planets { get; set; }
	
    private bool isPaused = false;

    public PlanetPage(Planet planet)
    {
        InitializeComponent();

        Planets = new(planets.solarSystem);
        drawPlanetPage = new DrawPlanetPage(planet);
        BindingContext = this;

        draw.Drawable = drawPlanetPage;

        timer.Interval = TimeSpan.FromMilliseconds(60);
        timer.Tick += Timer_Tick;
        timer.Start();

    }

    private void Timer_Tick(object sender, EventArgs e) {
        drawPlanetPage.MoonTime += 0.01 + drawPlanetPage.MoonSpeed;
        draw.Invalidate();
    }

    private void ButtonLessSpeed(object? sender, EventArgs e)
    {
        drawPlanetPage.MoonSpeed -= 0.01;
    }

    private void ButtonPause(object? sender, EventArgs e)
    {
        if (!isPaused)
        {
            timer.Stop();
            isPaused = true;
        }
        else
        {
            timer.Start();
            isPaused = false;
        }
    }

    private void ButtonMoreSpeed(object? sender, EventArgs e) {
        drawPlanetPage.MoonSpeed += 0.01;
    }

    private void OnPlanetPicked(object? sender, EventArgs eventArgs) {
        
        if (sender is not Picker picker)
            return;

        if (picker.SelectedItem is Star)
            Navigation.PopToRootAsync();

        if (picker.SelectedItem is Planet planet)
            Navigation.PushAsync(new PlanetPage(planet));

    }

    private void ResetSpeed_OnClicked(object? sender, EventArgs e) {
        drawPlanetPage.MoonSpeed = 0;
    }
    private void FiveTimesZoom_OnClicked(object? sender, EventArgs e) {
        drawPlanetPage.Scale = 100f;
        drawPlanetPage.DistanceScale = 2000f;
        drawPlanetPage.DistanceScale *= 5f;
        drawPlanetPage.Scale *= 5f;
    }

    private void OneTimesZoom_OnClicked(object? sender, EventArgs e) {
        drawPlanetPage.Scale = 100f;
        drawPlanetPage.DistanceScale = 2000f;

    }

    private void HideText_OnClicked(object? sender, EventArgs e) {
        if (!drawPlanetPage.HideText)
            drawPlanetPage.HideText = true;
        else
            drawPlanetPage.HideText = false;
    }
}