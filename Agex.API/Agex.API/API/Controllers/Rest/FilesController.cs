using System.Net.Mime;
using Agex.API.API.Requests.Documents.Create;
using Agex.API.API.Requests.Documents.Update;
using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.Command.Create;
using Agex.API.Application.Documents.Command.Update;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Application.Documents.Interfaces.Services;
using Agex.API.Application.Documents.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Agex.API.API.Controllers.Rest;

[ApiController]
[Route("/api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("CRUD for Files")]
public class FilesController(IFileService fileService, IMapper mapper) : ControllerBase
{
    [HttpGet("{fileId:guid}")]
    [SwaggerOperation("Get File", "Get File by ID")]
    public async Task<ActionResult<FileDto?>> GetFileAsync(Guid fileId)
    {
        return Ok(await fileService.GetFileAsync(fileId));
    }
    
    [HttpGet("page")]
    [SwaggerOperation("Get File", "Get Pageable Files")]
    public async Task<ActionResult<Pageable<FileDto>>> PageFilesAsync([FromQuery] PageRequest request)
    {
        return Ok(await fileService.PageAsync(request));
    }
    
    [HttpGet("document/{documentId:guid}/page")]
    [SwaggerOperation("Get File", "Get Pageable Files by Document ID")]
    public async Task<ActionResult<Pageable<FileDto>>> PageFilesByDocumentIdAsync([FromQuery] PageRequest request, [FromRoute] Guid documentId)
    {
        return Ok(await fileService.PageByDocumentIdAsync(request, documentId));
    }

    [HttpPost]
    [SwaggerOperation("Get File", "Get Pageable Files by Document ID")]
    public async Task<ActionResult<FileResponse>> CreateAsync(CreateFileRequest request)
    {
        var result = await fileService.CreateAsync(mapper.Map<CreateFileCommand>(request));
        return Ok(new FileResponse(result));
    }
    
    [HttpPut("{fileId:guid}")]
    [SwaggerOperation("Get File", "Get Pageable Files by Document ID")]
    public async Task<ActionResult<FileResponse>> UpdateAsync(Guid fileId, UpdateFileRequest request)
    {
        var result = await fileService.UpdateAsync(fileId, mapper.Map<UpdateFileCommand>(request));
        return Ok(new FileResponse(result));
    }
}