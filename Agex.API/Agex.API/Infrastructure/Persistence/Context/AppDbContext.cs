using Agex.API.Domain.Documents.Entities;
using Agex.API.Infrastructure.Common.Extensions;
using Agex.API.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using File = Agex.API.Domain.Documents.Entities.File;

namespace Agex.API.Infrastructure.Persistence.Context;

public class AppDbContext(DbContextOptions options, IWebHostEnvironment environment) : DbContext(options)
{
    public DbSet<Document> Documents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Documents
        modelBuilder.Entity<Document>().ToTable("Documents");
        modelBuilder.Entity<Document>().HasKey(d => d.Id);
        modelBuilder.Entity<Document>().Property(d => d.Id).ValueGeneratedOnAdd();

        // Files
        modelBuilder.Entity<File>().ToTable("Files");
        modelBuilder.Entity<File>().HasKey(f => f.Id);
        modelBuilder.Entity<File>().Property(f => f.Id).ValueGeneratedOnAdd();

        modelBuilder.ConvertAllToSnakeCase();

        modelBuilder
            .ApplyConfiguration(new DocumentSeeding())
            .ApplyConfiguration(new FileSeeding());
    }
}