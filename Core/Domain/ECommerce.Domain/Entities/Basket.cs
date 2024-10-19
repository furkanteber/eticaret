using ECommerce.Domain.Entities.Base;

namespace ECommerce.Domain.Entities;

public class Basket : BaseEntity
{
    public string UserId { get; set; } = null!;
    public User User { get; set; }
    public List<BasketItem> BasketItems { get; set; } = new();
}