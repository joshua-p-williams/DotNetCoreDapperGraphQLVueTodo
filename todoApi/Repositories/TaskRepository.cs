using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using todoApi.Repositories.Base;
using todoApi.Repositories;

namespace todoApi.Repositories
{
    public class TaskRepository : RepositoryBase<todoApi.Models.Task>
    {
        public TaskRepository(IConfiguration config) : base(config, "DefaultConnection")
        {
        }

        public override IEnumerable<todoApi.Models.Task> FindAll()
        {
            return Get("select * from todo.dbo.tasks");
        }
    }
}