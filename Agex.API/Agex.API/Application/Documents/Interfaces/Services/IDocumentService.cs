using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.Command.Create;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Application.Documents.Responses;

namespace Agex.API.Application.Documents.Interfaces.Services;

public interface IDocumentService
{
    Task<DetailedDocumentDto?> GetDocumentAsync(Guid id);
    Task<Pageable<DocumentDto>> PageAsync(PageRequest pageRequest);
    Task<DocumentDto> CreateAsync(CreateDocumentCommand command);
    
} 