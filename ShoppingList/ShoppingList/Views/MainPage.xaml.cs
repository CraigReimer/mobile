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
        lstData.Refreshing += LstData_Refreshing;
    }

    private void LstData_Refreshing(object sender, EventArgs e)
    {
        LoadData();
        lstData.IsRefreshing = false;
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
            LoadData();
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

    async void btnAddData_Clicked(System.Object sender, System.EventArgs e)
    {
        // Add Item
        HttpClient client = new();

        var data = JsonConvert.SerializeObject(new UserData(null, txtInput.Text, App.UserKey));

        await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/data"),
            new StringContent(data, System.Text.Encoding.UTF8, "application/json"));

        txtInput.Text = "";

        LoadData();
    }

    async public void LoadData()
    {
        // Load Items from API
        HttpClient client = new();

        var response = await client.GetAsync(new Uri("https://joewetzel.com/fvtc/account/data/" + App.UserKey));

        var wsData = response.Content.ReadAsStringAsync().Result;

        var data = JsonConvert.DeserializeObject<UserDataCollection>(wsData);

        lstData.ItemsSource = data.UserDataItems;

        txtInput.Focus();
    }

    void DeleteItem_Clicked(System.Object sender, System.EventArgs e)
    {
        var mi = (MenuItem)sender;
        var dataId = mi.CommandParameter.ToString();

        // Delete item from API
        DeleteData(dataId);
    }

    async public void DeleteData(string dataId = null)
    {
        // Delete item(s) from API
        HttpClient client = new();

        var data = JsonConvert.SerializeObject(new UserData(dataId, null, App.UserKey));

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri("https://joewetzel.com/fvtc/account/data"),
            Content = new StringContent(data, System.Text.Encoding.UTF8, "application/json"),
        };

        await client.SendAsync(request);

        LoadData();
    }

    void btnClearList_Clicked(System.Object sender, System.EventArgs e)
    {
        DeleteData();
    }
}
