namespace ShoppingList.Views;

public partial class MainPage : ContentPage
{
    LoginPage lp = new();

	public MainPage()
	{
		InitializeComponent();
        this.Loaded += MainPage_Loaded;
        lp.Unloaded += Lp_Unloaded;
	}

    private void Lp_Unloaded(object sender, EventArgs e)
    {
        OnAppearing1();
    }

    private void MainPage_Loaded(object sender, EventArgs e)
    {
        OnAppearing1();
    }

    public void OnAppearing1()
    {

        if (String.IsNullOrEmpty(App.SessionKey))
        {
            Navigation.PushModalAsync(new NavigationPage(lp));
        }
        else
        {
            // Do stuff
        }
    }

    void btnLogout_Clicked(System.Object sender, System.EventArgs e)
    {
        App.SessionKey = "";
        // Logout of API
        OnAppearing1();
    }
}
