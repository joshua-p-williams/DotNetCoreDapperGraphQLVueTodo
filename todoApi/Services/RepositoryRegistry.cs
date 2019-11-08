using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using todoApi.Repositories;

namespace todoApi.Services
{
    public static class RepositoryRegistry
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton(typeof(ITaskRepository), typeof(TaskRepository));
        }
    }
}