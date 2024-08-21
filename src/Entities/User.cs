using System.ComponentModel.DataAnnotations;
using CodeCrafters_backend_teamwork.src.Enums;
using Microsoft.EntityFrameworkCore;


namespace CodeCrafters_backend_teamwork.src.Entities;
[Index(nameof(Email), IsUnique = true)]
public class User
{

    [MaxLength(10), Required]
    public string FirstName { get; set; }
    [MaxLength(10), Required]
    public string LastName { get; set; }
    [MaxLength(50), Required]
    public string Password { get; set; }
    [MaxLength(30)]
    [EmailAddress]
    public string Email { get; set; }
    [Key, Required]
    public Guid Id { get; set; }
   [MaxLength(20), Required]
  
    public string PhoneNumber { get; set; }

    public Role Role { get; set; }
}


