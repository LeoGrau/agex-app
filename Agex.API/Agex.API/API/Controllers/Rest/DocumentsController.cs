using System.Net.Mime;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Application.Documents.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Agex.API.API.Controllers.Rest;

[ApiController]
[Route("/api/v0/[controller]")]
[SwaggerTag("Document CRUD")]
[Produces(MediaTypeNames.Application.Json)]
public class DocumentsController(IDocumentService documentService) : ControllerBase
{
    [SwaggerOperation("Get Document", "Get Document by Id")]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DocumentDto?>> GetDocumentAsync(Guid id)
    {
        return Ok(await documentService.GetDocumentAsync(id));
    }
}