namespace CustomGPS;

public partial class MainPage : ContentPage
{
    GeolocationRequest request;

    public MainPage()
	{
		InitializeComponent();
        Title = "Location Application";
        request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
	}

    async void btnUpdateLocation_Clicked(System.Object sender, System.EventArgs e)
    {
        Location location = await Geolocation.Default.GetLocationAsync(request);

        lblLat.Text = $"Lat: {location.Latitude}";
        lblLong.Text = $"Long: {location.Longitude}";

        IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);

        Placemark placemark = placemarks?.FirstOrDefault();

        if (placemark != null)
        {
            lblAddress.Text = $"{placemark.SubThoroughfare} {placemark.Thoroughfare}";
            lblAddress2.Text = $"{placemark.Locality}, {placemark.AdminArea} {placemark.PostalCode}";
        }

    }
}
