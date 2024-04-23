using Newtonsoft.Json;
using ShoppingList.Models;

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

        if (String.IsNullOrEmpty(App.UserKey))
        {
            Navigation.PushModalAsync(new NavigationPage(lp));
        }
        else
        {
            // Do stuff
            txtInput.Text = App.UserKey;
        }
    }

    void btnLogout_Clicked(System.Object sender, System.EventArgs e)
    {
        // Logout of API
        HttpClient client = new();

        var data = JsonConvert.SerializeObject(new UserAccount(App.UserKey));

        client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/logout"),
            new StringContent(data, System.Text.Encoding.UTF8, "application/json"));

        // Logout of App
        App.UserKey = "";

        OnAppearing1();
    }
}
