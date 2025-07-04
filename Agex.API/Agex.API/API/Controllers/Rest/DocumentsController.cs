using System.Net.Mime;
using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Application.Documents.Interfaces;
using Agex.API.Application.Documents.Interfaces.Services;
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
    
    [SwaggerOperation("Get Pageable Documents")]
    [HttpGet("page")]
    public async Task<ActionResult<Pageable<DocumentDto>>> PageDocumentsAsync([FromQuery] PageRequest request)
    {
        return Ok(await documentService.PageAsync(request));
    }

}