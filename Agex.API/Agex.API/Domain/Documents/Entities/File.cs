using Agex.API.Application.Documents.Command.Update;
using Agex.API.Domain.Common.Entities;

namespace Agex.API.Domain.Documents.Entities;

public class File : AuditModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    
    // Relations
    public Guid DocumentId { get; set; }
    public Document Document { get; set; } = null!;

    public void Update(UpdateFileCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Url = command.Url;
    }
}