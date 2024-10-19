using ECommerce.Domain.Entities.Base;

namespace ECommerce.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    
    public Guid? ImageId { get; set; }
    public string UserId { get; set; } = null!;
    
    public List<Category> Categories { get; set; } = new();
    public User User { get; set; }
    public Image Image { get; set; }
}