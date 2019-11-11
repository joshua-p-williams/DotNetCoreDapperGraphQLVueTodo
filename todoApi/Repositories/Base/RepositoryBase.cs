using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using todoApi.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Threading.Tasks;

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

        protected virtual String GetConnectionString()
        {
            return _config.GetValue<String>($"ConnectionStrings:{_connectionName}");
        }

        public virtual T Get(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) 
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return SqlMapperExtensions.Get<T>(connection, id);
            }
        }

        public virtual Task<T> GetAsync(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) 
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return SqlMapperExtensions.GetAsync<T>(connection, id);
            }
        }
        
        public virtual IEnumerable<T> GetAll(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return SqlMapperExtensions.GetAll<T>(connection, transaction, commandTimeout);
            }
        }
        
        public virtual Task<IEnumerable<T>> GetAllAsync(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return SqlMapperExtensions.GetAllAsync<T>(connection, transaction, commandTimeout);
            }
        }

        public virtual T Insert(T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var id = SqlMapperExtensions.Insert<T>(connection, entityToInsert, transaction, commandTimeout);
                return this.Get(id);
            }
        }

        public virtual long Insert(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return SqlMapperExtensions.Insert<IEnumerable<T>>(connection, list, transaction, commandTimeout);
            }
        }

        public virtual bool Update(T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return SqlMapperExtensions.Update<T>(connection, entityToUpdate, transaction, commandTimeout);
            }
        }

        public virtual bool Update(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return SqlMapperExtensions.Update<IEnumerable<T>>(connection, list, transaction, commandTimeout);
            }
        }

        public virtual bool Delete(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return SqlMapperExtensions.Delete<T>(connection, entityToDelete, transaction, commandTimeout);
            }
        }

        public virtual bool Delete(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return SqlMapperExtensions.Delete<IEnumerable<T>>(connection, list, transaction, commandTimeout);
            }
        }

        public virtual bool DeleteAll(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                return SqlMapperExtensions.DeleteAll<T>(connection, transaction, commandTimeout);
            }
        }
    }
}