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
        protected SqlConnection _connection;

        public RepositoryBase(IConfiguration config, String connectionName)
        {
            this._config = config;
            this._connectionName = connectionName;
            this._connection = new SqlConnection(GetConnectionString());
        }

        protected virtual String GetConnectionString()
        {
            return _config.GetValue<String>($"ConnectionStrings:{_connectionName}");
        }

        public virtual T Get(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) 
        {
            return SqlMapperExtensions.Get<T>(_connection, id);
        }

        public virtual Task<T> GetAsync(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) 
        {
            return SqlMapperExtensions.GetAsync<T>(_connection, id);
        }
        
        public virtual IEnumerable<T> GetAll(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.GetAll<T>(_connection, transaction, commandTimeout);
        }
        
        public virtual Task<IEnumerable<T>> GetAllAsync(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.GetAllAsync<T>(_connection, transaction, commandTimeout);
        }

        public virtual T Insert(T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var id = SqlMapperExtensions.Insert<T>(_connection, entityToInsert, transaction, commandTimeout);
            return this.Get(id);
        }
        public virtual Task<T> InsertAsync(T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var id = SqlMapperExtensions.Insert<T>(_connection, entityToInsert, transaction, commandTimeout);
            return this.GetAsync(id);
        }

        public virtual long Insert(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.Insert<IEnumerable<T>>(_connection, list, transaction, commandTimeout);
        }

        public virtual Task<int> InsertAsync(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.InsertAsync<IEnumerable<T>>(_connection, list, transaction, commandTimeout);
        }

        public virtual bool Update(T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.Update<T>(_connection, entityToUpdate, transaction, commandTimeout);
        }

        public virtual Task<bool> UpdateAsync(T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.UpdateAsync<T>(_connection, entityToUpdate, transaction, commandTimeout);
        }

        public virtual bool Update(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.Update<IEnumerable<T>>(_connection, list, transaction, commandTimeout);
        }

        public virtual Task<bool> UpdateAsync(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.UpdateAsync<IEnumerable<T>>(_connection, list, transaction, commandTimeout);
        }

        public virtual bool Delete(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.Delete<T>(_connection, entityToDelete, transaction, commandTimeout);
        }

        public virtual Task<bool> DeleteAsync(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.DeleteAsync<T>(_connection, entityToDelete, transaction, commandTimeout);
        }

        public virtual bool Delete(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.Delete<IEnumerable<T>>(_connection, list, transaction, commandTimeout);
        }

        public virtual Task<bool> DeleteAsync(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.DeleteAsync<IEnumerable<T>>(_connection, list, transaction, commandTimeout);
        }

        public virtual bool DeleteAll(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.DeleteAll<T>(_connection, transaction, commandTimeout);
        }

        public virtual Task<bool> DeleteAllAsync(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SqlMapperExtensions.DeleteAllAsync<T>(_connection, transaction, commandTimeout);
        }
    }
}