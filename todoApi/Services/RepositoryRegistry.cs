using System;
using todoApi.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace todoApi.Services
{
    public static class RepositoryRegistry
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton(typeof(TaskRepository), typeof(TaskRepository));
        }
    }
}