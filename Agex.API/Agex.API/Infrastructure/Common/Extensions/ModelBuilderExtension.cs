using Agex.API.Infrastructure.Common.Extensions.String;
using Microsoft.EntityFrameworkCore;

namespace Agex.API.Infrastructure.Common.Extensions;

public static class ModelBuilderExtension
{
    public static void ConvertAllToSnakeCase(this ModelBuilder modelBuilder)
    {
        foreach (var entity in  modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName().ToSnakeCase());
            
            foreach (var property in entity.GetProperties())
                property.SetColumnName(property.GetColumnName().ToSnakeCase());

            foreach (var key in entity.GetKeys())
                key.SetName(key.GetName().ToSnakeCase());

            foreach (var key in entity.GetForeignKeys())
                key.SetConstraintName(key.GetConstraintName().ToSnakeCase());

            foreach (var index in entity.GetIndexes())
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
        }
    }
}