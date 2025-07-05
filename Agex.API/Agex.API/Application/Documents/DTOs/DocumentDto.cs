using Agex.API.Application.Common.DTOs;

namespace Agex.API.Application.Documents.DTOs;

public class DocumentDto : AuditDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}