using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.DTOs;

namespace Agex.API.Application.Documents.Interfaces.Services;

public interface IFileService
{
    Task<FileDto?> GetFileAsync(Guid id);
    Task<Pageable<FileDto>> PageAsync(PageRequest pageRequest);
    Task<Pageable<FileDto>> PageByDocumentIdAsync(PageRequest pageRequest, Guid documentId);
}