namespace BreakTimer;

public partial class MainPage : ContentPage
{
    public int MyTake = 0;
    int MyTicks = 0;
    int MyMinutes = 0;
    IDispatcherTimer MyTimer;
    bool IsTimeUp;

    public MainPage()
	{
		InitializeComponent();
        Title = "Break Timer";
        MyTimer = Dispatcher.CreateTimer();
        MyTimer.Interval = TimeSpan.FromSeconds(1);
        MyTimer.Tick += MyTimer_Tick;
	}

    public void MyTimer_Tick(object sender, EventArgs e)
    {
        if (!IsTimeUp)
        {
            MyTicks++;
            if (MyTicks == 60)
            {
                MyTicks = 0;
                MyMinutes++;

                if ((MyTake - MyMinutes) == 0)
                {
                    IsTimeUp = true;
                    lblDisplay.Text = "Time's Up!!!";
                }
            }
        }
        
    }

    void btnTakeFive_Clicked(System.Object sender, System.EventArgs e)
    {
        MyTake = 5;
    }

    void btnTakeTen_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void btnTakeFifteen_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void btnReset_Clicked(System.Object sender, System.EventArgs e)
    {
        MyTake = 0;
        
    }

}


