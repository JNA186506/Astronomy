using System.Collections.ObjectModel;

namespace Astronomy.Maui;
using Astronomy.core;

public partial class MainPage : ContentPage {

	private DrawSolarSystem drawSolarSystem;
	public DrawSolarSystem DrawSolarSystem => drawSolarSystem;
	private IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
	private readonly InitSystem planets = new(); 
	public ObservableCollection<SpaceObject> Planets { get; set; }
	
	private bool isPaused = false;

	public MainPage()
	{
		InitializeComponent();

		Planets = new ObservableCollection<SpaceObject>(planets.solarSystem);
		drawSolarSystem = new DrawSolarSystem();
		BindingContext = this;
		
		draw.Drawable = drawSolarSystem;

		timer.Interval = TimeSpan.FromMilliseconds(60);
		timer.Tick += Timer_Tick;
		timer.Start();

	}

	private void Timer_Tick(object sender, EventArgs e) {
		drawSolarSystem.Time += 0.5 + drawSolarSystem.Speed;
		draw.Invalidate();
	}

	private void ButtonLessSpeed(object? sender, EventArgs e)
	{
		drawSolarSystem.Speed -= 1;
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

	private void ButtonMoreSpeed(object? sender, EventArgs e)
	{
		drawSolarSystem.Speed += 1;
	}
	
	private void ResetSpeed_OnClicked(object? sender, EventArgs e) {
		drawSolarSystem.Speed = 0;
	}

	private void OnPlanetPicked(object? sender, EventArgs eventArgs) {
		if (sender is not Picker picker)
			return;
		
		if (picker.SelectedItem is Planet planet) 
			Navigation.PushAsync(new PlanetPage(planet));
		
	}

	private void HalfTimesZoom_OnClicked(object? sender, EventArgs e) {
		drawSolarSystem.Scale = 2000f;
		drawSolarSystem.DistanceScale = 3_000_000f;
		drawSolarSystem.DistanceScale *= .5f;
		drawSolarSystem.Scale *= .5f;
	}

	private void TwentyTimesZoom_OnClicked(object? sender, EventArgs e) {
		drawSolarSystem.Scale = 2000f;
		drawSolarSystem.DistanceScale = 3_000_000f;
		drawSolarSystem.DistanceScale *= 20f;
		drawSolarSystem.Scale *= 20f;
	}

	private void FiveTimesZoom_OnClicked(object? sender, EventArgs e) {
		drawSolarSystem.Scale = 2000f;
		drawSolarSystem.DistanceScale = 3_000_000f;
		drawSolarSystem.DistanceScale *= 5f;
		drawSolarSystem.Scale *= 5f;
	}

	private void OneTimesZoom_OnClicked(object? sender, EventArgs e) {
		drawSolarSystem.Scale = 2000f;
		drawSolarSystem.DistanceScale = 3_000_000f;

	}

	private void HideText_OnClicked(object? sender, EventArgs e) {
		if (!drawSolarSystem.HideText)
			drawSolarSystem.HideText = true;
		else
			drawSolarSystem.HideText = false;
	}
}
