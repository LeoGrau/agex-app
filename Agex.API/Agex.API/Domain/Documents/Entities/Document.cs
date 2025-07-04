using System.ComponentModel.DataAnnotations.Schema;
using Agex.API.Domain.Common.Entities;

namespace Agex.API.Domain.Documents.Entities;

[Table("documents")]
public class Document : AuditModel
{
    [Column("id")] public Guid Id { get; set; }
    [Column("name")] public string Name { get; set; } = string.Empty;
    [Column("description")] public string Description { get; set; } = string.Empty;
    [Column("url")] public string Url { get; set; } = string.Empty;
    
    // Relation
    public IList<File> Files { get; set; } = new List<File>();
}