using System;
using todoApi.Data.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace todoApi.Data
{
    public static class BuilderConfiguration
    {
        public static void AddBuilders(this IServiceCollection services)
        {
            services.AddSingleton<TodoBuilder>();
            services.AddSingleton<CategoryBuilder>();
        }
    }
}