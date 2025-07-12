using System.Net.Mime;
using Agex.API.API.Requests.Documents.Create;
using Agex.API.API.Requests.Documents.Update;
using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.Command.Create;
using Agex.API.Application.Documents.Command.Update;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Application.Documents.Interfaces;
using Agex.API.Application.Documents.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Agex.API.API.Controllers.Rest;

[ApiController]
[Route("/api/v0/[controller]")]
[SwaggerTag("Document CRUD")]
[Produces(MediaTypeNames.Application.Json)]
public class DocumentsController(IDocumentService documentService, IMapper mapper) : ControllerBase
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
    
    [SwaggerOperation("Update Document", "Update Document by Id")]
    [HttpPut("{documentId:guid}")]
    public async Task<ActionResult<DocumentDto?>> UpdateDocumentAsync(Guid documentId, UpdateDocumentRequest request)
    {
        var mapped = mapper.Map<UpdateDocumentCommand>(request);
        return Ok(await documentService.UpdateAsync(documentId, mapped));
    }
    
    [SwaggerOperation("Create Document", "Create Document by Id")]
    [HttpPost]
    public async Task<ActionResult<DocumentDto?>> CreateDocumentAsync(CreateDocumentRequest request)
    {
        var mapped = mapper.Map<CreateDocumentCommand>(request);
        return Ok(await documentService.CreateAsync(mapped));
    }
    
    [SwaggerOperation("Create files for a single document", "Create Document by Id")]
    [HttpPost("{documentId:guid}/files")]
    public async Task<ActionResult<DocumentDto?>> CreateFilesOnDocumentAsync(IList<CreateFileRequest> request, Guid documentId)
    {
        var mapped = mapper.Map<CreateDocumentCommand>(request);
        return Ok(await documentService.CreateAsync(mapped));
    }
}