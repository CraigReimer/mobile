using ShoppingList.Views;

namespace ShoppingList;

public partial class App : Application
{
	public static string SessionKey = "";

	public App()
	{
		// User: Elvis
		// Pass: test
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
	}
}
