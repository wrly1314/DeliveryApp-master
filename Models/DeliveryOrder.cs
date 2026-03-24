using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models;

public class DeliveryOrder
{
    [Required]
    public string OrderId { get; set; } = string.Empty;

    [Required]
    public string Type { get; set; } = string.Empty;

    [Required]
    public string Receiver { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    [Required]
    public string Status { get; set; } = string.Empty;

    public DateTime Time { get; set; }
}