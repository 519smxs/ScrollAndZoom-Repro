using Microsoft.Extensions.DependencyInjection;

namespace ScrollAndZoom;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var mainPage = new MainPage();

		var window = new Window(mainPage);

		return window;
	}
}