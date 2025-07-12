namespace Agex.API.Domain.Documents.Operations.Update;

public class UpdateFileData
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public Guid DocumentId { get; set; }
}