using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Application.Documents.Interfaces.Services;
using Agex.API.Domain.Documents.Interfaces.Repository;
using AutoMapper;

namespace Agex.API.Application.Documents.Services;

public class DocumentService(IDocumentRepository documentRepository, IMapper mapper) : IDocumentService
{
    public async Task<DetailedDocumentDto?> GetDocumentAsync(Guid id)
    {
        var document = await documentRepository.GetAsync(id);
        if (document == null)
            throw new KeyNotFoundException($"Document with id {id} not found");
        return mapper.Map<DetailedDocumentDto>(document);
    }

    public async Task<Pageable<DocumentDto>> PageAsync(PageRequest pageRequest)
    {
        return mapper.Map<Pageable<DocumentDto>>(await documentRepository.PageAsync(pageRequest));
    }
}