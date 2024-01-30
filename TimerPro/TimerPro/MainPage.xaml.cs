using TimerPro.Custom;

namespace TimerPro;

public partial class MainPage : ContentPage
{
    TimerLogic timer = new ();
    bool isRunning = false;

    public MainPage()
	{
		InitializeComponent();
		Title = "TimerPro";
	}

    void btnStart_Clicked(System.Object sender, System.EventArgs e)
    {
        btnStart.IsEnabled = false;
        btnStop.IsEnabled = true;
        isRunning = true;

        Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () => {
            if (isRunning)
            {
                timer.SetTickCount();
                lblDisplay.Text = timer.GetFormattedString();
            }
            return isRunning;
        });
    }

    void btnStop_Clicked(System.Object sender, System.EventArgs e)
    {
        btnStop.IsEnabled = false;
        btnStart.IsEnabled = true;
        isRunning = false;
    }

    void btnReset_Clicked(System.Object sender, System.EventArgs e)
    {
        timer.Reset();
        lblDisplay.Text = timer.GetFormattedString();
    }
}

