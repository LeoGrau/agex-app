namespace Agex.API.Application.Documents.DTOs;

public class DocumentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
}