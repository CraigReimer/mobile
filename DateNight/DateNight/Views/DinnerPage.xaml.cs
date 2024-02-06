namespace DateNight.Views;

public partial class DinnerPage : ContentPage
{
	public DinnerPage()
	{
		InitializeComponent();
		Title = "Out for Dinner";
	}

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        App.calc.DinnerCost = txtDinner.Text;
    }
}
