using MovieAppPro.Models;

namespace MovieAppPro;

public partial class App : Application
{
	public static List<Movie> MovieList;

	public App()
	{
		InitializeComponent();

		MovieList = new List<Movie>();

		MainPage = new AppShell();
	}
}

