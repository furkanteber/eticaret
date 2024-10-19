using ECommerce.Domain.Entities.Base;

namespace ECommerce.Domain.Entities;

public class BasketItem : BaseEntity
{
    public int Quantity { get; set; }
    
    public Guid BasketId { get; set; }
    public Guid ProductId { get; set; }
    
    public Basket Basket { get; set; }
    public Product Product { get; set; }    
}