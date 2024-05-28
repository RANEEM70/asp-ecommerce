using System.ComponentModel.DataAnnotations;

namespace CodeCrafters_backend_teamwork.src.Entities;

public class OrderCheckout
{
    [Key, Required]
    public Guid Id { get; set; }

    [MaxLength(50), Required]
    public string Payment { get; set; }
    [Required]
    public Guid UserId { get; set; }
   [MaxLength(50), Required]
    public string Shipping { get; set; }
    [MaxLength(50), Required]

    public string Status { get; set; }
    [Required]
    public double TotalPrice { get; set; }
    public List<OrderItem> OrderItems { get; set; }

}

