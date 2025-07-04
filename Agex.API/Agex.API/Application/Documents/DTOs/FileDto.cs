using Agex.API.Application.Common.DTOs;

namespace Agex.API.Application.Documents.DTOs;

public class FileDto : AuditDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}