using Agex.API.Domain.Documents.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agex.API.Infrastructure.Persistence.Seed;

public class DocumentSeeding : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasData(
            new Document
            {
                Id = new Guid("c0d82375-0518-4f6d-be33-4ecd3dafdbc5"), Name = "Document 1",
                Description = "Test Document 1",
            },
            new Document
            {
                Id = new Guid("facf6235-1cb4-4ae7-a55e-245b323cd911"), Name = "Document 2",
                Description = "Test Document 2",
            },
            new Document
            {
                Id = new Guid("b8e44eae-b250-41d2-a123-30d81328acd5"), Name = "Document 3",
                Description = "Test Document 3",
            },
            new Document
            {
                Id = new Guid("6fa6a738-432e-46bc-87c9-552b8f490e4b"), Name = "Document 4",
                Description = "Test Document 4",
            },
            new Document
            {
                Id = new Guid("3b6cadf2-bb28-4632-be0c-b7917e946eec"), Name = "Document 5",
                Description = "Test Document 5",
            },
            new Document
            {
                Id = new Guid("c6956362-5485-4714-a122-e52eab0d9418"), Name = "Document 6",
                Description = "Test Document 6",
            },
            new Document
            {
                Id = new Guid("f1281cb3-557b-4481-a932-ee4e4a92ad9f"), Name = "Document 7",
                Description = "Test Document 7",
            },
            new Document
            {
                Id = new Guid("3f6f3a54-a2c7-4067-bf7a-57c482058cbf"), Name = "Document 8",
                Description = "Test Document 8",
            },
            new Document
            {
                Id = new Guid("e1f13039-024a-47a8-b2e3-140d00378661"), Name = "Document 9",
                Description = "Test Document 9",
            },
            new Document
            {
                Id = new Guid("b13bc592-37ec-432c-a359-5365b9562a95"), Name = "Document 10",
                Description = "Test Document 10",
            },
            new Document
            {
                Id = new Guid("c5ee0ca5-e8b8-4ce8-9576-98e6247d32bf"), Name = "Document 11",
                Description = "Test Document 11",
            },
            new Document
            {
                Id = new Guid("71579cf9-7f2d-41c4-a740-19834766f2a4"), Name = "Document 12",
                Description = "Test Document 12",
            },
            new Document
            {
                Id = new Guid("4625a2f1-b227-452e-ac68-1fab9ddd99fa"), Name = "Document 13",
                Description = "Test Document 13",
            },
            new Document
            {
                Id = new Guid("6ba6d728-9852-459e-8d67-0d21f06868d3"), Name = "Document 14",
                Description = "Test Document 14",
            },
            new Document
            {
                Id = new Guid("ebfce089-d680-429c-bcb4-be5f83be71a3"), Name = "Document 15",
                Description = "Test Document 15",
            },
            new Document
            {
                Id = new Guid("ff6f3d0e-6828-486f-9d77-4e9ffcd610fa"), Name = "Document 16",
                Description = "Test Document 16",
            },
            new Document
            {
                Id = new Guid("13b8c5c5-40f3-4af5-a097-107b4b627838"), Name = "Document 17",
                Description = "Test Document 17",
            },
            new Document
            {
                Id = new Guid("cc213601-7e14-4d6a-ba2c-48b23aeee90f"), Name = "Document 18",
                Description = "Test Document 18",
            },
            new Document
            {
                Id = new Guid("6508a13b-9671-474c-b48a-4bc065ccc751"), Name = "Document 19",
                Description = "Test Document 19",
            },
            new Document
            {
                Id = new Guid("48f0a970-5fef-49d2-a6b3-15a6365bce88"), Name = "Document 20",
                Description = "Test Document 20",
            }
        );
    }
}