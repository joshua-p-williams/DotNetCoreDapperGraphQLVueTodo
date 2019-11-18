using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using todoApi.Data.Models;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using todoApi.Data.Repositories;

namespace todoApi.Data.Repositories
{
    public class DetailsLike : Constraint
    {
        public override Dictionary<String, Object> Bind(Dapper.SqlBuilder builder)
        {
            var parameters = new Dictionary<String, Object>();

            builder.Where("UPPER(Details) like @DetailsLike");
            parameters.Add("DetailsLike", "%" + this.Value.ToString().ToUpper() + "%");

            return parameters;
        }
    }

    public class TodoConstraints : Todo 
    {
        public DetailsLike DetailsLike { get; set; }
    }

    public class TodoRepository : RepositoryBase<Todo, TodoConstraints>
    {
        public TodoRepository(IConfiguration config)  : base (config)
        {
        }
    }
}