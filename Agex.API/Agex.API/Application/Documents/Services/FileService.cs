using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Application.Documents.Interfaces.Services;
using Agex.API.Domain.Documents.Interfaces.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Agex.API.Application.Documents.Services;

public class FileService(IFileRepository fileRepository, IMapper mapper) : IFileService
{
    public async Task<FileDto?> GetFileAsync(Guid id)
    {
        var file = await fileRepository.GetAsync(id);
        if(file == null)
            throw new KeyNotFoundException($"File with id {id} not found");
        return mapper.Map<FileDto>(file);
    }

    public async Task<Pageable<FileDto>> PageAsync(PageRequest pageRequest)
    {
        return mapper.Map<Pageable<FileDto>>(await fileRepository.PageAsync(pageRequest));
    }

    public async Task<Pageable<FileDto>> PageByDocumentIdAsync(PageRequest pageRequest, Guid documentId)
    {
        return mapper.Map<Pageable<FileDto>>(await fileRepository.PageByDocumentIdAsync(pageRequest, documentId));
    }
}