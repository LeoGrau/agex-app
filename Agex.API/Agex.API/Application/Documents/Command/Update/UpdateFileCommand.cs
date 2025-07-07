namespace Agex.API.Application.Documents.Command.Update;

public class UpdateFileCommand
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public Guid DocumentId { get; set; }
}