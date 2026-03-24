namespace DeliveryApp.Models;

public class DeliveryModel
{
    public int Id { get; set; }
    public string OrderId { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Receiver { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}