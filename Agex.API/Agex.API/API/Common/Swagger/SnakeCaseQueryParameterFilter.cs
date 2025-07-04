using Agex.API.Infrastructure.Common.Extensions.String;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Agex.API.API.Common.Swagger;

public class SnakeCaseQueryParameterFilter : IParameterFilter
{
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        if (parameter.In == ParameterLocation.Query && context.PropertyInfo != null)
            parameter.Name = parameter.Name.ToSnakeCase();
    }
}