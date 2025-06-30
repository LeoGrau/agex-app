namespace Agex.API.Application.Common.Pagination;

public class Pageable<T> where T : class
{
    public long TotalCount { get; set; }
    public long ItemCount { get; set; }
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public IList<T> Items { get; set; } = new List<T>();
}