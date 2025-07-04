using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Domain.Documents.Entities;
using AutoMapper;
using File = Agex.API.Domain.Documents.Entities.File;

namespace Agex.API.Application.Mappings;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Document, DocumentDto>();
        CreateMap<Document, DetailedDocumentDto>();
        CreateMap<Pageable<Document>, Pageable<DocumentDto>>();
        CreateMap<Pageable<Document>, Pageable<DetailedDocumentDto>>();
        
        CreateMap<File, FileDto>();
        CreateMap<Pageable<File>, Pageable<FileDto>>();
        
    }
}