using Agex.API.Application.Documents.Command.Create;
using Agex.API.Domain.Common.Entities;
using Agex.API.Domain.Documents.Operations.Create;
using Agex.API.Domain.Documents.Operations.Update;

namespace Agex.API.Domain.Documents.Entities;

public class Document : AuditModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Relation
    public IList<File> Files { get; set; } = new List<File>();

    public void Update(UpdateDocumentData document)
    {
        Name = document.Name;
        Description = document.Description;
    }

    public void AddNewFiles(IList<CreateFileData> files)
    {
        if (files.Count == 0)
        {
            foreach (var file in files)
                Files.Add(new File { Name = file.Name, Description = file.Description, Url = file.Url });
        }
    }
}