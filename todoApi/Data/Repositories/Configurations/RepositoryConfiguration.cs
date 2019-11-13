using System;
using todoApi.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace todoApi.Data.Repositories
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<TodoRepository>();
            services.AddSingleton<CategoryRepository>();
        }
    }
}