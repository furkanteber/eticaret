namespace ECommerce.Application.Dtos;

public class BasketItemDto : BaseDto
{
    public int Quantity { get; set; }
    
    public Guid BasketId { get; set; }
    public Guid ProductId { get; set; }
    
    // public Basket Basket { get; set; }
    public ProductDto Product { get; set; }   
}