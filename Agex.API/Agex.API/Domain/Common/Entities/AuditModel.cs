using System.ComponentModel.DataAnnotations.Schema;

namespace Agex.API.Domain.Common.Entities;

public class AuditModel
{
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}