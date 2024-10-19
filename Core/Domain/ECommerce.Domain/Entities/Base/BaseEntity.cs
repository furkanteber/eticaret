namespace ECommerce.Domain.Entities.Base;

public class BaseEntity
{
    public Guid Id { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }
    
}