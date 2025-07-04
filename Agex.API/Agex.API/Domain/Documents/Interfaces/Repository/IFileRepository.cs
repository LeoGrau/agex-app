

using Agex.API.Application.Common.Pagination;
using Agex.API.Infrastructure.Common.Repository;
using File = Agex.API.Domain.Documents.Entities.File;

namespace Agex.API.Domain.Documents.Interfaces.Repository;

public interface IFileRepository : IBaseRepository<File,Guid>
{
    Task<Pageable<File>> PageAsync(PageRequest request);
    Task<File?> GetFileAsync(Guid id);
    Task<Pageable<File>> PageByDocumentIdAsync(PageRequest request, Guid documentId);
}