using Agex.API.Domain.Documents.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agex.API.Infrastructure.Persistence.Seed;

public class DocumentSeeding : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasData(new Document
        {
            Id = Guid.NewGuid(),
            Description = "Test Document",
            Name = "Test Document",
            Url = "https://www.google.com/"
        });
    }
}