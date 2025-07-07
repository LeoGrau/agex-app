using Agex.API.Application.Common.Pagination;
using Agex.API.Application.Documents.Command.Create;
using Agex.API.Application.Documents.Command.Update;
using Agex.API.Application.Documents.DTOs;
using Agex.API.Application.Documents.Interfaces.Services;
using Agex.API.Domain.Common.Interfaces;
using Agex.API.Domain.Documents.Interfaces.Repository;
using AutoMapper;
using File = Agex.API.Domain.Documents.Entities.File;

namespace Agex.API.Application.Documents.Services;

public class FileService(IFileRepository fileRepository, IUnitOfWork unitOfWork, IMapper mapper) : IFileService
{
    public async Task<FileDto?> GetFileAsync(Guid id)
    {
        var file = await fileRepository.GetAsync(id);
        if (file == null)
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

    public async Task<FileDto> CreateAsync(CreateFileCommand command)
    {
        try
        {
            var file = mapper.Map<File>(command);
            await unitOfWork.BeginTransactionAsync();
            await fileRepository.CreateAsync(file);
            await unitOfWork.CommitTransactionAsync();
            return mapper.Map<FileDto>(file);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<FileDto> UpdateAsync(Guid id, UpdateFileCommand command)
    {
        try
        {
            var existingFile = await fileRepository.GetAsync(id);
            if(existingFile == null)
                throw new KeyNotFoundException($"File with id {id} not found");
            
            await unitOfWork.BeginTransactionAsync();
            existingFile.Update(command);
            await unitOfWork.CommitTransactionAsync();
            
            return mapper.Map<FileDto>(existingFile);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}