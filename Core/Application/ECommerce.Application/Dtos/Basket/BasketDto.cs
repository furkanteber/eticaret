namespace ECommerce.Application.Dtos.Basket;

public class BasketDto : BaseDto
{
    public string UserId { get; set; } = null!;
    // public UserDto User { get; set; }
    public List<BasketItemDto> BasketItems { get; set; } = new();
}