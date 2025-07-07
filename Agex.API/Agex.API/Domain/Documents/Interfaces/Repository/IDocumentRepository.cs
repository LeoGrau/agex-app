using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.Command.Create;
using Agex.API.Domain.Documents.Entities;
using Agex.API.Infrastructure.Common.Repository;

namespace Agex.API.Domain.Documents.Interfaces.Repository;

public interface IDocumentRepository : IBaseRepository<Document, Guid>
{
    Task<Pageable<Document>> PageAsync(PageRequest request);
}