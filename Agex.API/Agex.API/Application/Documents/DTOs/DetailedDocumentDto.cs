namespace Agex.API.Application.Documents.DTOs;

public class DetailedDocumentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public IList<FileDto> Files { get; set; } = new List<FileDto>();
}