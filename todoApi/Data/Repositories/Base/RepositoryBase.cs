using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Threading;
using todoApi.Data.Models;

namespace todoApi.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly IConfiguration _config;
        protected String _connectionName;
        protected SqlConnection _connection;

        public RepositoryBase(IConfiguration config)
        {
            this._config = config;
            this._connectionName = ConnectionDetails.GetConnectionName<T>();
            this._connection = new SqlConnection(GetConnectionString());
        }

        protected virtual String GetConnectionString()
        {
            return _config.GetValue<String>($"ConnectionStrings:{_connectionName}");
        }

        public int Delete(object id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SimpleCRUD.Delete<T>(_connection, id, transaction, commandTimeout);
        }

        public int Delete(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return SimpleCRUD.Delete<T>(_connection, entityToDelete, transaction, commandTimeout);
        }

        public Task<int> DeleteAsync(object id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.DeleteAsync<T>(_connection, id, transaction, commandTimeout);
        }

        public Task<int> DeleteAsync(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.DeleteAsync<T>(_connection, entityToDelete, transaction, commandTimeout);
        }

        public int DeleteList(string conditions, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.DeleteList<T>(_connection, conditions, parameters, transaction, commandTimeout);
        }

        public int DeleteList(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.DeleteList<T>(_connection, whereConditions, transaction, commandTimeout);
        }

        public Task<int> DeleteListAsync(string conditions, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.DeleteListAsync<T>(_connection, conditions, parameters, transaction, commandTimeout);
        }

        public Task<int> DeleteListAsync(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.DeleteListAsync<T>(_connection, whereConditions, transaction, commandTimeout);
        }

        public T Get(object id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.Get<T>(_connection, id, transaction, commandTimeout);
        }

        public Task<T> GetAsync(object id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.GetAsync<T>(_connection, id, transaction, commandTimeout);
        }

        public IEnumerable<T> GetList()
        {
			return SimpleCRUD.GetList<T>(_connection);
        }

        public IEnumerable<T> GetList(string conditions, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.GetList<T>(_connection, conditions, parameters, transaction, commandTimeout);
        }

        public IEnumerable<T> GetList(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.GetList<T>(_connection, whereConditions, transaction, commandTimeout);
        }

        public Task<IEnumerable<T>> GetListAsync()
        {
			return SimpleCRUD.GetListAsync<T>(_connection);
        }

        public Task<IEnumerable<T>> GetListAsync(string conditions, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.GetListAsync<T>(_connection, conditions, parameters, transaction, commandTimeout);
        }

        public Task<IEnumerable<T>> GetListAsync(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.GetListAsync<T>(_connection, whereConditions, transaction, commandTimeout);
        }

        public IEnumerable<T> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.GetListPaged<T>(_connection, pageNumber, rowsPerPage, conditions, orderby, parameters, transaction, commandTimeout);
        }

        public Task<IEnumerable<T>> GetListPagedAsync(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.GetListPagedAsync<T>(_connection, pageNumber, rowsPerPage, conditions, orderby, parameters, transaction, commandTimeout);
        }

        public int? Insert<TEntity>(TEntity entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.Insert<TEntity>(_connection, entityToInsert, transaction, commandTimeout);
        }

        public TKey Insert<TKey, TEntity>(TEntity entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.Insert<TKey, TEntity>(_connection, entityToInsert, transaction, commandTimeout);
        }

        public Task<TKey> InsertAsync<TKey, TEntity>(TEntity entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.InsertAsync<TKey, TEntity>(_connection, entityToInsert, transaction, commandTimeout);
        }

        public Task<int?> InsertAsync<TEntity>(TEntity entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.InsertAsync<TEntity>(_connection, entityToInsert, transaction, commandTimeout);
        }

        public int RecordCount(string conditions = "", object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.RecordCount<T>(_connection, conditions, parameters, transaction, commandTimeout);
        }

        public int RecordCount(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.RecordCount<T>(_connection, whereConditions, transaction, commandTimeout);
        }

        public Task<int> RecordCountAsync(string conditions = "", object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.RecordCountAsync<T>(_connection, conditions, parameters, transaction, commandTimeout);
        }

        public Task<int> RecordCountAsync(object whereConditions, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.RecordCountAsync<T>(_connection, whereConditions, transaction, commandTimeout);
        }

        public int Update<TEntity>(TEntity entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
			return SimpleCRUD.Update<TEntity>(_connection, entityToUpdate, transaction, commandTimeout);
        }

        public Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null, CancellationToken? token = null)
        {
			return SimpleCRUD.UpdateAsync<TEntity>(_connection, entityToUpdate, transaction, commandTimeout, token);
        }

    }
}