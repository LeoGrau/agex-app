
using Agex.API.Domain.Documents.Entities;
using Agex.API.Domain.Documents.Interfaces.Repository;
using Agex.API.Infrastructure.Common.Repository;
using Agex.API.Infrastructure.Persistence.Context;


namespace Agex.API.Infrastructure.Persistence.Repositories;

public class DocumentRepository(AppDbContext appDbContext) : BaseRepository<Document, Guid>(appDbContext), IDocumentRepository;