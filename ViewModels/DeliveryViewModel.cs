using System.Collections.ObjectModel;
using System.Windows.Input;
using DeliveryApp.Models;
using DeliveryApp.Services;
using Microsoft.Maui.Devices.Sensors;

namespace DeliveryApp.ViewModels;

public class DeliveryViewModel : ViewModelBase
{
    private readonly DatabaseService _dbService;
    public ObservableCollection<DeliveryOrder> Orders { get; set; } = new ObservableCollection<DeliveryOrder>();

    private Location? _currentLocation;
    public Location? CurrentLocation
    {
        get => _currentLocation;
        set { _currentLocation = value; OnPropertyChanged(); }
    }

    public ICommand NavigateToDetailCommand { get; }

    public DeliveryViewModel()
    {
        _dbService = new DatabaseService();
        LoadOrders();

        // ✅ 修复：传递 order.OrderId（string），不是 DeliveryOrder
        NavigateToDetailCommand = new Command<DeliveryOrder>(async (order) =>
        {
            if (order == null || string.IsNullOrEmpty(order.OrderId))
                return;

            var window = Application.Current?.Windows[0];
            if (window?.Page is NavigationPage navPage)
            {
                await navPage.PushAsync(new DeliveryDetailPage(order.OrderId));
            }
        });
    }

    public void LoadOrders()
    {
        var orders = _dbService.GetOrders();
        Orders = new ObservableCollection<DeliveryOrder>(orders);
        OnPropertyChanged(nameof(Orders));
    }

    public async Task GetCurrentLocationAsync()
    {
        try
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            CurrentLocation = await Geolocation.GetLocationAsync(request);
        }
        catch (Exception ex)
        {
            CurrentLocation = null;
        }
    }
}