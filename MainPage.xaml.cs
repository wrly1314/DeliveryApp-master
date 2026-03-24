using Microsoft.Maui.Controls;

namespace DeliveryApp;

public partial class MainPage : ContentPage
{
    private IDispatcherTimer? _locationTimer;
    private double _currentLat = 27.845931;
    private double _currentLon = 112.922089;

    public MainPage()
    {
        InitializeComponent();
        StartLocationRefreshTimer();
    }

    private void StartLocationRefreshTimer()
    {
        _locationTimer = Dispatcher.CreateTimer();
        _locationTimer.Interval = TimeSpan.FromSeconds(3);
        _locationTimer.Tick += UpdateLocation;
        _locationTimer.Start();
    }

    private void UpdateLocation(object? sender, EventArgs e)
    {
        var random = new Random();
        _currentLat = Math.Round(_currentLat + random.NextDouble() * 0.0005 - 0.00025, 6);
        _currentLon = Math.Round(_currentLon + random.NextDouble() * 0.0005 - 0.00025, 6);

        Dispatcher.Dispatch(() =>
        {
            LocationLabel.Text = $"Latitude: {_currentLat}\nLongitude: {_currentLon}";
        });
    }

    private async void OnOrderTapped(object? sender, TappedEventArgs e)
    {
        var orderId = e.Parameter as string;
        if (orderId != null)
        {
            await Navigation.PushAsync(new DeliveryDetailPage(orderId));
        }
    }

    // Detail 按钮点击：跳转到 ProfilePage（第二张图）
    private async void OnDetailClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (_locationTimer?.IsRunning == true)
        {
            _locationTimer.Stop();
            _locationTimer = null;
        }
    }
}