
using Agex.API.Application.Common.Pagination;
using Agex.API.Domain.Documents.Entities;
using Agex.API.Domain.Documents.Interfaces.Repository;
using Agex.API.Infrastructure.Common.Repository;
using Agex.API.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace Agex.API.Infrastructure.Persistence.Repositories;

public class DocumentRepository(AppDbContext appDbContext) : BaseRepository<Document, Guid>(appDbContext), IDocumentRepository
{
    public async Task<Pageable<Document>> PageAsync(PageRequest request, string searchTerm)
    {
        // All query
        var query = DbSet.AsQueryable();
        var totalItems = await query.CountAsync();
        
        // Items on page
        var items = query.Skip(request.Skip).Take(request.PageSize);
        var result = items.ToList();
        var totalResult = result.Count;
        
        return new Pageable<Document>
        {
            Items = result,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ItemCount = totalItems,
            TotalCount = totalResult
        };
    }
}