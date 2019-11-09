using System;
using System.Collections.Generic;
using todoApi.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace todoApi.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly IConfiguration _config;

        public RepositoryBase(IConfiguration config)
        {
            this._config = config;
        }

        public abstract IEnumerable<T> FindAll();

        public IEnumerable<T> Get(String query)
        {
            IEnumerable<T> results = null;

            using (var connection = new SqlConnection(_config.GetValue<String>("ConnectionStrings:DefaultConnection")))
            {
                results = connection.Query<T>(query);
            }

            return results;
        }
    }
}