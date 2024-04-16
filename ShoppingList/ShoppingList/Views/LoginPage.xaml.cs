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

    void btnLogin_Clicked(System.Object sender, System.EventArgs e)
    {
        App.SessionKey = "uhJJgfDTVGb7tv67g";
        Navigation.PopModalAsync();
    }
}
