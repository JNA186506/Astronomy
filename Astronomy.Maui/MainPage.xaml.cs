namespace Astronomy.Maui;
using Astronomy.core;

public partial class MainPage : ContentPage {

	public MainPage()
	{
		InitializeComponent();

		draw.Drawable = new DrawSolarSystem();
		
		
	}

}
