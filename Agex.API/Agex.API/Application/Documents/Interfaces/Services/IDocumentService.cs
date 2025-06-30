using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.DTOs;

namespace Agex.API.Application.Documents.Interfaces.Services;

public interface IDocumentService
{
    Task<DocumentDto?> GetDocumentAsync(Guid id);
    Task<Pageable<DocumentDto>> PageAsync(PageRequest pageRequest, string searchTerm);
} 