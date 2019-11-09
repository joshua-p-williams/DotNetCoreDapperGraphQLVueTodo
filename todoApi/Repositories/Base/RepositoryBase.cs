using System;
using System.Collections.Generic;
using todoApi.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace todoApi.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly IConfiguration _config;
        protected String _connectionName;

        public RepositoryBase(IConfiguration config, String connectionName)
        {
            this._config = config;
            this._connectionName = connectionName;
        }

        public abstract T GetById(int id);
        public abstract IEnumerable<T> FetchAll();
        public abstract T Create(T item);
        public abstract T Update(T existingItem, T newItem);
        public abstract Boolean Delete(T item);

        public IEnumerable<T> Get(String query)
        {
            IEnumerable<T> results = null;

            using (var connection = new SqlConnection(_config.GetValue<String>($"ConnectionStrings:{_connectionName}")))
            {
                results = connection.Query<T>(query);
            }

            return results;
        }
    }
}