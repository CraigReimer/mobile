using DateNight.Models;
namespace DateNight;

public partial class App : Application
{
	public static DateDataCalculator calc;

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		calc = new DateDataCalculator();
	}
}

