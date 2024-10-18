using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Diagnostics.CodeAnalysis;

namespace NotificacaoColetaApi.Config
{
    [ExcludeFromCodeCoverage]
    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.DeclaringType is null)
                return;

            var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any()
                        || context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            var allowAnonymous = context.MethodInfo.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any();

            if (hasAuthorize && !allowAnonymous)
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer",
                                }
                            }
                        ] = new List<string>()
                    }
                };
            }
        }
    }
}