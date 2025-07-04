using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = Agex.API.Domain.Documents.Entities.File;

namespace Agex.API.Infrastructure.Persistence.Seed;

public class FileSeeding : IEntityTypeConfiguration<File>
{
    public void Configure(EntityTypeBuilder<File> builder)
    {
        builder.HasData(new File
        {
            Id = new Guid("c1282375-0518-4f6d-be33-4ecd3dafdbc5"), Name = "File 1", Description = "Test File 1",
            Url = "<insert url 1>", DocumentId = new Guid("c0d82375-0518-4f6d-be33-4ecd3dafdbc5"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("facf6236-1cb4-4ae7-a55e-245b323cd911"), Name = "File 2", Description = "Test File 2",
            Url = "<insert url 2>", DocumentId = new Guid("facf6235-1cb4-4ae7-a55e-245b323cd911"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("b8e44eaf-b250-41d2-a123-30d81328acd5"), Name = "File 3", Description = "Test File 3",
            Url = "<insert url 3>", DocumentId = new Guid("b8e44eae-b250-41d2-a123-30d81328acd5"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("6fa6a739-432e-46bc-87c9-552b8f490e4b"), Name = "File 4", Description = "Test File 4",
            Url = "<insert url 4>", DocumentId = new Guid("6fa6a738-432e-46bc-87c9-552b8f490e4b"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("3b6cadf3-bb28-4632-be0c-b7917e946eec"), Name = "File 5", Description = "Test File 5",
            Url = "<insert url 5>", DocumentId = new Guid("3b6cadf2-bb28-4632-be0c-b7917e946eec"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("c6956363-5485-4714-a122-e52eab0d9418"), Name = "File 6", Description = "Test File 6",
            Url = "<insert url 6>", DocumentId = new Guid("c6956362-5485-4714-a122-e52eab0d9418"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("f1281cb4-557b-4481-a932-ee4e4a92ad9f"), Name = "File 7", Description = "Test File 7",
            Url = "<insert url 7>", DocumentId = new Guid("f1281cb3-557b-4481-a932-ee4e4a92ad9f"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("e1f1303a-024a-47a8-b2e3-140d00378661"), Name = "File 8", Description = "Test File 8",
            Url = "<insert url 8>", DocumentId = new Guid("e1f13039-024a-47a8-b2e3-140d00378661"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("b13bc593-37ec-432c-a359-5365b9562a95"), Name = "File 9", Description = "Test File 9",
            Url = "<insert url 9>", DocumentId = new Guid("b13bc592-37ec-432c-a359-5365b9562a95"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("c5ee0ca6-e8b8-4ce8-9576-98e6247d32bf"), Name = "File 10", Description = "Test File 10",
            Url = "<insert url 10>", DocumentId = new Guid("c5ee0ca5-e8b8-4ce8-9576-98e6247d32bf"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("71579cfa-7f2d-41c4-a740-19834766f2a4"), Name = "File 11", Description = "Test File 11",
            Url = "<insert url 11>", DocumentId = new Guid("71579cf9-7f2d-41c4-a740-19834766f2a4"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("4625a2f2-b227-452e-ac68-1fab9ddd99fa"), Name = "File 12", Description = "Test File 12",
            Url = "<insert url 12>", DocumentId = new Guid("4625a2f1-b227-452e-ac68-1fab9ddd99fa"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("6ba6d729-9852-459e-8d67-0d21f06868d3"), Name = "File 13", Description = "Test File 13",
            Url = "<insert url 13>", DocumentId = new Guid("6ba6d728-9852-459e-8d67-0d21f06868d3"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("ebfce08a-d680-429c-bcb4-be5f83be71a3"), Name = "File 14", Description = "Test File 14",
            Url = "<insert url 14>", DocumentId = new Guid("ebfce089-d680-429c-bcb4-be5f83be71a3"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("ff6f3d0f-6828-486f-9d77-4e9ffcd610fa"), Name = "File 15", Description = "Test File 15",
            Url = "<insert url 15>", DocumentId = new Guid("ff6f3d0e-6828-486f-9d77-4e9ffcd610fa"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("13b8c5c6-40f3-4af5-a097-107b4b627838"), Name = "File 16", Description = "Test File 16",
            Url = "<insert url 16>", DocumentId = new Guid("13b8c5c5-40f3-4af5-a097-107b4b627838"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        }, new File {
            Id = new Guid("14b8c5c6-40f3-4af5-a097-104b4b627838"), Name = "File 16", Description = "Test File 16",
            Url = "<insert url 16>", DocumentId = new Guid("13b8c5c5-40f3-4af5-a097-107b4b627838"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        }, new File {
            Id = new Guid("15b8c5c6-40f3-4af5-a097-104b4b627838"), Name = "File 16", Description = "Test File 16",
            Url = "<insert url 16>", DocumentId = new Guid("13b8c5c5-40f3-4af5-a097-107b4b627838"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        }, new File {
            Id = new Guid("16b8c5c6-40f3-4af5-a097-104b4b627838"), Name = "File 16", Description = "Test File 16",
            Url = "<insert url 16>", DocumentId = new Guid("13b8c5c5-40f3-4af5-a097-107b4b627838"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        }, new File {
            Id = new Guid("17b8c5c6-40f3-4af5-a097-104b4b627838"), Name = "File 16", Description = "Test File 16",
            Url = "<insert url 16>", DocumentId = new Guid("13b8c5c5-40f3-4af5-a097-107b4b627838"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        }, new File {
            Id = new Guid("18b8c5c6-40f3-4af5-a097-104b4b627838"), Name = "File 16", Description = "Test File 16",
            Url = "<insert url 16>", DocumentId = new Guid("13b8c5c5-40f3-4af5-a097-107b4b627838"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        }, new File {
            Id = new Guid("19b8c5c6-40f3-4af5-a097-104b4b627838"), Name = "File 16", Description = "Test File 16",
            Url = "<insert url 16>", DocumentId = new Guid("13b8c5c5-40f3-4af5-a097-107b4b627838"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("cc213602-7e14-4d6a-ba2c-48b23aeee90f"), Name = "File 17", Description = "Test File 17",
            Url = "<insert url 17>", DocumentId = new Guid("cc213601-7e14-4d6a-ba2c-48b23aeee90f"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("6508a13c-9671-474c-b48a-4bc065ccc751"), Name = "File 18", Description = "Test File 18",
            Url = "<insert url 18>", DocumentId = new Guid("6508a13b-9671-474c-b48a-4bc065ccc751"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("48f0a971-5fef-49d2-a6b3-15a6365bce88"), Name = "File 19", Description = "Test File 19",
            Url = "<insert url 19>", DocumentId = new Guid("48f0a970-5fef-49d2-a6b3-15a6365bce88"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        builder.HasData(new File
        {
            Id = new Guid("3f6f3a55-a2c7-4067-bf7a-57c482058cbf"), Name = "File 20", Description = "Test File 20",
            Url = "<insert url 20>", DocumentId = new Guid("3f6f3a54-a2c7-4067-bf7a-57c482058cbf"), CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
        });
        
    }
}