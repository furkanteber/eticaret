namespace ECommerce.Application.Dtos;

public class CategoryDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public List<ProductDto> Products { get; set; } = new();
}