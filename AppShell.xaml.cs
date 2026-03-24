namespace DeliveryApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        // 注册路由（如果需要侧边栏导航，保留；不需要可删除）
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
    }
}