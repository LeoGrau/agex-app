using System.Text.Json.Serialization;
using Agex.API.API.Common.ModelBinder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Agex.API.Application.Common.Pagination;

[ModelBinder(BinderType = typeof(SnakeCaseQueryModelBinder))]
public class PageRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchTerm { get; set; } = "";
    
    [BindNever]
    public int Skip => (PageIndex - 1) * PageSize;
} 