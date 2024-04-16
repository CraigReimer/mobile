namespace ShoppingList.Views;

public partial class NewAccountPage : ContentPage
{
	public NewAccountPage()
	{
		InitializeComponent();
	}

    void btnCreateAccount_Clicked(System.Object sender, System.EventArgs e)
    {
		// Password match?
		// Valid email?
		// Valid username?
		// Create Account on API
		// Error handling
		// Login on API
		// Error handling
		App.SessionKey = "xfcgvuhbijn";

		Navigation.PopModalAsync();
    }
}
