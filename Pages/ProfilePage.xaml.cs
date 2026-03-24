namespace DeliveryApp;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    // My Orders 按钮：跳转回 MainPage（第一张图）
    private async void OnMyOrdersClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    // Log Out 按钮：弹出英文确认框（第三张图）
    private async void OnLogOutClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert(
            "Confirm",
            "Are you sure you want to log out?",
            "OK",
            "Cancel"
        );

        if (confirm)
        {
            await DisplayAlert("Logged Out", "You have successfully logged out", "OK");
            // 如需回到登录页，可替换为：await Navigation.PopToRootAsync();
        }
    }
}