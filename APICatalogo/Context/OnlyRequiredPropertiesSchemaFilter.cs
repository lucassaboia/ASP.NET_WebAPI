using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class OnlyRequiredPropertiesSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Required == null || schema.Properties == null)
            return;

        var requiredProps = schema.Required;
        var allProps = schema.Properties.Keys.ToList();

        foreach (var prop in allProps)
        {
            if (!requiredProps.Contains(prop))
                schema.Properties.Remove(prop);
        }
    }
}
