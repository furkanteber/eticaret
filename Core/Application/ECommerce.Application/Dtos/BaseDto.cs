namespace ECommerce.Application.Dtos;

public class BaseDto
{
    public Guid Id { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }
}