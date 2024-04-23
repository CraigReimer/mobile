using Newtonsoft.Json;
using ShoppingList.Models;

namespace ShoppingList.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    void btnNewAccount_Clicked(System.Object sender, System.EventArgs e)
    {
		Navigation.PushAsync(new NewAccountPage());
    }

    async void btnLogin_Clicked(System.Object sender, System.EventArgs e)
    {
        // Login on API
        var data = JsonConvert.SerializeObject(
            new UserAccount(txtUsername.Text, txtPass.Text));

        HttpClient client = new();

        var response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/login"),
                     new StringContent(data, System.Text.Encoding.UTF8, "application/json"));
        var SKey = response.Content.ReadAsStringAsync().Result;

        if (String.IsNullOrEmpty(SKey) || SKey.Length > 50)
        {
            // Login error handling
            await DisplayAlert("Error", "Sorry, a login error has occurred.", "OK");
            return;
        }
        else
        {
            // Login to App
            App.UserKey = SKey;

            Navigation.PopModalAsync();
        }

    }
}
