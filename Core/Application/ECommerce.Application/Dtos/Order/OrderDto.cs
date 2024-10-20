namespace ECommerce.Application.Dtos;

public class OrderDto : BaseDto
{
    public decimal TotalPrice { get; set; }
    
    public Guid BasketId { get; set; }
    
    // public Basket? Basket { get; set; }
}