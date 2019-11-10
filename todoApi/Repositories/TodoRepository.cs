using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using todoApi.Repositories.Base;
using todoApi.Repositories;
using todoApi.Models;

namespace todoApi.Repositories
{
    public class TodoRepository : RepositoryBase<Todo>
    {
        public TodoRepository(IConfiguration config) : base(config, "DefaultConnection")
        {
        }

        public override Todo GetById(int id)
        {
            return Get("Select top 1 * from dbo.todos where id = @id", new {id = id}).First();
        }

        public override IEnumerable<Todo> FetchAll()
        {
            return Get("select * from dbo.todos");
        }

        public override Todo Create(Todo item) 
        {
            return null;
        }

        public override Todo Update(Todo existingItem, Todo newItem) 
        {
            return null;
        }

        public override Boolean Delete(Todo item) 
        {
            return false;
        }
    }
}