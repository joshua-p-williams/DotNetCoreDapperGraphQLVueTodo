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
        public TodoRepository(IConfiguration config) 
        : base(
            config, 
            "DefaultConnection", 
            "dbo.todos"
        )
        {
        }
    }
}