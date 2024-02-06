namespace DateNight.Views;

public partial class CoffeePage : ContentPage
{
	public CoffeePage()
	{
		InitializeComponent();
		Title = "Going for Coffee";
	}

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
		App.calc.CoffeeCost = txtCoffee.Text;
    }
}
