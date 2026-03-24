namespace DeliveryApp;

public partial class DeliveryDetailPage : ContentPage
{
    public DeliveryDetailPage(string? orderId)
    {
        InitializeComponent();
        // 可根据 orderId 加载对应订单数据
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnShareLocationClicked(object sender, EventArgs e)
    {
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Text = "Current Location: Lat 27.8459, Lon 112.9221",
            Title = "Share Location"
        });
    }
}