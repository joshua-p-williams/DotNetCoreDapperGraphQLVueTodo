using System;
using todoApi.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace todoApi.Data
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<TodoRepository>();
            services.AddScoped<CategoryRepository>();
        }
    }
}