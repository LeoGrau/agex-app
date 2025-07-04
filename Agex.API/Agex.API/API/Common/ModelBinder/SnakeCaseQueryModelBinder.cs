using System.Reflection;
using Agex.API.Infrastructure.Common.Extensions.String;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Agex.API.API.Common.ModelBinder;

public class SnakeCaseQueryModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var model = Activator.CreateInstance(bindingContext.ModelType);
        
        foreach (var property in bindingContext.ModelType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            // Transform to snake_case this name property.
            var snakeCaseName = property.Name.ToSnakeCase();
            
            // Getting value from the query but with the snakecase name
            var valueResult = bindingContext.ValueProvider.GetValue(snakeCaseName);
            Console.WriteLine($"{valueResult}");
            
            // If value is not found, continue with the next iteration. ValueResult could have more than one.
            // Access with "Values", with roles, but not in this code.
            if(valueResult == ValueProviderResult.None) continue;
            var value = valueResult.FirstValue;
            if(value == null) continue;
            
            Console.WriteLine(valueResult);
            
            try
            {
                // Transform converted
                var converted = Convert.ChangeType(value, property.PropertyType);
                property.SetValue(model, converted);
                Console.WriteLine(converted.GetType());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        // All is well, here you have the object that I build from the query string.
        // You can use it in your controller now.
        bindingContext.Result = ModelBindingResult.Success(model);
        return Task.CompletedTask;
    }
}