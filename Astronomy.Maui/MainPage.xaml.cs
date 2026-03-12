namespace Astronomy.Maui;
using Astronomy.core;

public partial class MainPage : ContentPage {

	private DrawSolarSystem drawSolarSystem = new();
	private IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
	private bool isPaused = false;

	public MainPage()
	{
		InitializeComponent();

		draw.Drawable = drawSolarSystem;

		timer.Interval = TimeSpan.FromMilliseconds(60);
		timer.Tick += Timer_Tick;
		timer.Start();

	}

	private void Timer_Tick(object sender, EventArgs e) {
		drawSolarSystem.Time += 0.5;
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
		drawSolarSystem.Speed += 2;
	}
}
