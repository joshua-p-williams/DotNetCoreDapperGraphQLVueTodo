using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using todoApi.Repositories.Base;
using todoApi.Repositories;
using todoApi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace todoApi.Repositories
{
    public class TodoRepository : RepositoryBase<Todo>
    {
        public TodoRepository(IConfiguration config)  : base (config)
        {
        }

        public Task<IEnumerable<Todo>> GetByCategoryId(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) 
        {
            // TODO: Need to implement predicate system
            return this.GetListAsync(new { CategoryId = id });
        }

    }
}