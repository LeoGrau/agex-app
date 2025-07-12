using Agex.API.API.Requests.Documents;
using Agex.API.API.Requests.Documents.Create;
using Agex.API.API.Requests.Documents.Update;
using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.Command.Create;
using Agex.API.Application.Documents.Command.Update;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Domain.Documents.Entities;
using Agex.API.Domain.Documents.Operations.Create;
using Agex.API.Domain.Documents.Operations.Update;
using AutoMapper;
using File = Agex.API.Domain.Documents.Entities.File;

namespace Agex.API.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Document, DocumentDto>();
        CreateMap<Document, DetailedDocumentDto>();
        CreateMap<CreateDocumentRequest, CreateDocumentCommand>();
        CreateMap<UpdateDocumentRequest, UpdateDocumentCommand>();
        CreateMap<CreateDocumentCommand, CreateDocumentData>();
        CreateMap<UpdateDocumentCommand, UpdateDocumentData>();
        CreateMap<Pageable<Document>, Pageable<DocumentDto>>();
        CreateMap<Pageable<Document>, Pageable<DetailedDocumentDto>>();
        
        
        CreateMap<File, FileDto>();
        CreateMap<CreateFileRequest, CreateFileCommand>();
        CreateMap<UpdateFileRequest, UpdateFileCommand>();
        CreateMap<CreateFileCommand, CreateFileData>();
        CreateMap<UpdateFileCommand, UpdateFileData>();
        CreateMap<Pageable<File>, Pageable<FileDto>>();
    }
}