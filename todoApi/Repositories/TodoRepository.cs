using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using todoApi.Repositories.Base;
using todoApi.Repositories;
using todoApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace todoApi.Repositories
{
    public class TodoRepository : RepositoryBase<Todo>
    {
        public TodoRepository(IConfiguration config) 
        : base(
            config, 
            "DefaultConnection"
        )
        {
        }

        public IEnumerable<Todo> GetByCategoryId(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) 
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return this.GetAll().Where( i => i.CategoryId == id);
            }
        }

    }
}