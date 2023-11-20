using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Mvc;

namespace programming009.LibraryManagement.WebApi.Extensions
{
    public static class ValidationExtensions
    {
        public static void AddFluentValidaiton(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<Program>();
        }
    }
}
