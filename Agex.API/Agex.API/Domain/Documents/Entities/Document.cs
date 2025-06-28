using System.ComponentModel.DataAnnotations.Schema;

namespace Agex.API.Domain.Documents.Entities;

[Table("documents")]
public class Document
{
    [Column("id")] public Guid Id { get; set; }
    [Column("name")] public string Name { get; set; } = string.Empty;
    [Column("description")] public string Description { get; set; } = string.Empty;
    [Column("url")] public string Url { get; set; } = string.Empty;
}