using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Common.Response;
using Agex.API.Application.Documents.Command.Create;
using Agex.API.Application.Documents.Command.Update;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Application.Documents.Responses;

namespace Agex.API.Application.Documents.Interfaces.Services;

public interface IFileService
{
    Task<FileDto?> GetFileAsync(Guid id);
    Task<Pageable<FileDto>> PageAsync(PageRequest pageRequest);
    Task<Pageable<FileDto>> PageByDocumentIdAsync(PageRequest pageRequest, Guid documentId);
    Task<FileDto> CreateAsync(CreateFileCommand command);
    Task<FileDto> UpdateAsync(Guid id, UpdateFileCommand command);
}