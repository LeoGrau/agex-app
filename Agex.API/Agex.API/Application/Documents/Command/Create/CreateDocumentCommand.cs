namespace Agex.API.Application.Documents.Command.Create;

public class CreateDocumentCommand
{
    public class CreateDocumentFile
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IList<CreateDocumentFile> Files { get; set; } = new List<CreateDocumentFile>(); 
}