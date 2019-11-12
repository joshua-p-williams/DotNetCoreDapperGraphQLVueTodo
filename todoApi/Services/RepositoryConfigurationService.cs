using System;
using todoApi.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace todoApi.Services
{
    public static class RepositoryServiceConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<TodoRepository>();
            services.AddSingleton<CategoryRepository>();
        }
    }
}