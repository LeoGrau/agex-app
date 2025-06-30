using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Domain.Documents.Entities;
using AutoMapper;

namespace Agex.API.Application.Mappings;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Document, DocumentDto>();
        CreateMap<Pageable<Document>, Pageable<DocumentDto>>();
    }
}