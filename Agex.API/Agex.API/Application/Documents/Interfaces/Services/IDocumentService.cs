using Agex.API.Application.Documents.DTOs;
using Agex.API.Domain.Documents.Entities;

namespace Agex.API.Application.Documents.Interfaces;

public interface IDocumentService
{
    Task<DocumentDto?> GetDocumentAsync(Guid id);
} 