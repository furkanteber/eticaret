using ECommerce.Domain.Entities.Base;

namespace ECommerce.Domain.Entities;

public class Order : BaseEntity
{
    public decimal TotalPrice { get; set; }
    
    public Guid BasketId { get; set; }
    
    public Basket Basket { get; set; }
}