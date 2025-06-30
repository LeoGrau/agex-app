using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Agex.API.Application.Common.Pagination;

public class PageRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    
    [BindNever]
    public int Skip => (PageIndex - 1) * PageSize;
}