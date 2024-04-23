using System.Text.RegularExpressions;
using Newtonsoft.Json;
using ShoppingList.Models;

namespace ShoppingList.Views;

public partial class NewAccountPage : ContentPage
{
	public NewAccountPage()
	{
		InitializeComponent();
	}

    async void btnCreateAccount_Clicked(System.Object sender, System.EventArgs e)
    {
		// Password match?
		if(txtPass1.Text != txtPass2.Text)
		{
			await DisplayAlert("Error", "Passwords do not match!", "OK");
			return;
		}

		// Valid email?
		var pattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
		Regex rg = new(pattern);

		if (!rg.IsMatch(txtEmail.Text))
		{
			await DisplayAlert("Error", "Invalid email format", "OK");
			return;
		}

		// Username has value?

		// Create Account on API
		var data = JsonConvert.SerializeObject(
            new UserAccount(txtUsername.Text, txtEmail.Text, txtPass1.Text));

		// 'complete', 'user exists', 'email exists'
		HttpClient client = new();
		var response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/createuser"),
                         new StringContent(data, System.Text.Encoding.UTF8, "application/json"));
		var accountStatus = response.Content.ReadAsStringAsync().Result;

		// Error handling
		if(accountStatus == "user exists")
		{
			await DisplayAlert("Error", "Sorry, this username has been taken", "OK");
			return;
		}

        if (accountStatus == "email exists")
        {
            await DisplayAlert("Error", "Sorry, this email address has been used", "OK");
            return;
        }

        if (accountStatus == "complete")
        {
			// Login on API
            response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/login"),
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
		else
		{
            await DisplayAlert("Error", "Sorry, an unknown error has occurred.", "OK");
            return;
        }

        
    }



}
