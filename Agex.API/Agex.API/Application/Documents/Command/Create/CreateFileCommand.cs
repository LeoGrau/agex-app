namespace Agex.API.Application.Documents.Command.Create;

public class CreateFileCommand
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public Guid DocumentId { get; set; }
}