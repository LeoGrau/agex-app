using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.Command.Create;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Application.Documents.Interfaces.Services;
using Agex.API.Application.Documents.Responses;
using Agex.API.Domain.Common.Interfaces;
using Agex.API.Domain.Documents.Entities;
using Agex.API.Domain.Documents.Interfaces.Repository;
using AutoMapper;

namespace Agex.API.Application.Documents.Services;

public class DocumentService(IDocumentRepository documentRepository, IUnitOfWork unitOfWork, IMapper mapper) : IDocumentService
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

    public async Task<DocumentDto> CreateAsync(CreateDocumentCommand command)
    {
        try
        {
            var document = mapper.Map<Document>(command);
            await unitOfWork.BeginTransactionAsync();
            await documentRepository.CreateAsync(document);
            await unitOfWork.CommitTransactionAsync();
            return mapper.Map<DocumentDto>(document);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}