using Agex.API.Application.Common.Pagination;
using Agex.API.Domain.Documents.Entities;
using Agex.API.Domain.Documents.Interfaces.Repository;
using Agex.API.Infrastructure.Common.Repository;
using Agex.API.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace Agex.API.Infrastructure.Persistence.Repositories;

public class DocumentRepository(AppDbContext appDbContext)
    : BaseRepository<Document, Guid>(appDbContext), IDocumentRepository
{
    public async override Task<Document?> GetAsync(Guid id)
    {
        return await DbSet.Where(document => document.Id == id)
            .Include(document => document.Files)
            .FirstOrDefaultAsync();
    }

    public async Task<Pageable<Document>> PageAsync(PageRequest request)
    {
        // All query
        var query = DbSet.Where(document =>
                document.Name.Contains(request.SearchTerm!) || document.Description.Contains(request.SearchTerm!) ||
                document.Url.Contains(request.SearchTerm!) || document.Id.ToString().Contains(request.SearchTerm!))
            .AsQueryable();

        var totalCount = await query.CountAsync();

        // Items on page
        var items = query.Skip(request.Skip).Take(request.PageSize);
        var result = items.ToList();
        var totalItems = result.Count;

        return new Pageable<Document>
        {
            Items = result,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ItemCount = totalItems,
            TotalCount = totalCount
        };
    }
}