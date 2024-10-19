using ECommerce.Domain.Entities.Base;

namespace ECommerce.Domain.Entities;

public class Image : BaseEntity
{
    public string Path { get; set; } = null!;
    public string FileName { get; set; } = null!;
}