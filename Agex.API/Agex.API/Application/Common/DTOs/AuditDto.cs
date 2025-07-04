namespace Agex.API.Application.Common.DTOs;

public class AuditDto
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}