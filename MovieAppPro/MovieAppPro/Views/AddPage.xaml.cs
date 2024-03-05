using MovieAppPro.Models;

namespace MovieAppPro.Views;

public partial class AddPage : ContentPage
{
	public AddPage()
	{
		InitializeComponent();
		Title = "Add New Movie";
	}

    void btnAdd_Clicked(System.Object sender, System.EventArgs e)
    {
		var nm = new Movie();
		nm.Title = txtTitle.Text;
		nm.Rating = txtRating.Text;

		App.MovieList.Add(nm);

		// clean-up
		txtTitle.Text = "";
		txtRating.Text = "";
    }
}
