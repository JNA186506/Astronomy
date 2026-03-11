namespace Astronomy.Maui;
using Astronomy.core;

public partial class MainPage : ContentPage {

	private DrawSolarSystem drawSolarSystem = new();

	public MainPage()
	{
		InitializeComponent();

		draw.Drawable = drawSolarSystem;

		IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();

		timer.Interval = TimeSpan.FromMilliseconds(60);
		timer.Tick += Timer_Tick;
		timer.Start();
	}

	private void Timer_Tick(object sender, EventArgs e) {

		drawSolarSystem.Time += 0.5;
		draw.Invalidate();
	}
	
	

}
