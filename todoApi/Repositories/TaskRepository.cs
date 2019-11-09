using System;
using System.Linq;
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

        public override todoApi.Models.Task GetById(int id)
        {
            return Get("Select top 1 * from dbo.tasks").First();
        }

        public override IEnumerable<todoApi.Models.Task> FetchAll()
        {
            return Get("select * from dbo.tasks");
        }

        public override todoApi.Models.Task Create(todoApi.Models.Task item) 
        {
            return null;
        }

        public override todoApi.Models.Task Update(todoApi.Models.Task existingItem, todoApi.Models.Task newItem) 
        {
            return null;
        }

        public override Boolean Delete(todoApi.Models.Task item) 
        {
            return false;
        }
    }
}