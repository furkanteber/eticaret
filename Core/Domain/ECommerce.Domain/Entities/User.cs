using Microsoft.AspNetCore.Identity;

namespace ECommerce.Domain.Entities;

public class User : IdentityUser<string>
{
    public List<Product> Products { get; set; } = new();
    
    public Guid BasketId { get; set; }
    
    public Basket Basket { get; set; }
}