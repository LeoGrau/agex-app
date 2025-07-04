using Agex.API.Application.Common.Pagination;
using Agex.API.Domain.Documents.Interfaces.Repository;
using Agex.API.Infrastructure.Common.Repository;
using Agex.API.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using File = Agex.API.Domain.Documents.Entities.File;

namespace Agex.API.Infrastructure.Persistence.Repositories;

public class FileRepository(AppDbContext appDbContext) : BaseRepository<File, Guid>(appDbContext), IFileRepository
{
    public async Task<Pageable<File>> PageAsync(PageRequest request)
    {
        var query = DbSet.Where(file => file.Name.Contains(request.SearchTerm!) || file.Description.Contains(request.SearchTerm!)).AsQueryable();
        var totalCount = query.Count();
        var items = query.Skip(request.Skip).Take(request.PageSize);
        var itemCount = await items.CountAsync();
        var result = items.ToList();
        return new Pageable<File>
        {
            Items = result,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ItemCount = itemCount,
            TotalCount = totalCount
        };
    }

    public async Task<File?> GetFileAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<Pageable<File>> PageByDocumentIdAsync(PageRequest request, Guid documentId)
    {
        var query = DbSet.Where(file => file.DocumentId == documentId && (file.Name.Contains(request.SearchTerm!) || file.Description.Contains(request.SearchTerm!))).AsQueryable();
        var totalCount = query.Count();
        var items = query.Skip(request.Skip).Take(request.PageSize);
        var itemCount = await items.CountAsync();
        var result = items.ToList();
        return new Pageable<File>
        {
            Items = result,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ItemCount = itemCount,
            TotalCount = totalCount
        };
    }
}