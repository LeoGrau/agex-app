namespace Agex.API.API.Requests.Documents.Create;

public class CreateFileRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public Guid DocumentId { get; set; }
}