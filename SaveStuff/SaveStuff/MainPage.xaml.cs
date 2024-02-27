namespace SaveStuff;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    void btnSave_Clicked(System.Object sender, System.EventArgs e)
    {
        Preferences.Set("UserName", txtUserName.Text);
    }

    void btnRead_Clicked(System.Object sender, System.EventArgs e)
    {
        txtUserName.Text = Preferences.Get("UserName", "");
    }

    void btnClear_Clicked(System.Object sender, System.EventArgs e)
    {
        txtUserName.Text = string.Empty;
    }
}


