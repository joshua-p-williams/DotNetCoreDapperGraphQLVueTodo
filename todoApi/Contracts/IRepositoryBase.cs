using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace todoApi.Contracts
{
    public interface IRepositoryBase<T>
    {
        T Get(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<T> GetAsync(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<T> GetAll(IDbTransaction transaction = null, int? commandTimeout = null);
        Task<IEnumerable<T>> GetAllAsync(IDbTransaction transaction = null, int? commandTimeout = null);
        T Insert(T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<T> InsertAsync(T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null);
        long Insert(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<int> InsertAsync(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null);
        bool Update(T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<bool> UpdateAsync(T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null);
        bool Update(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<bool> UpdateAsync(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null);
        bool Delete(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<bool> DeleteAsync(T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null);
        bool Delete(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<bool> DeleteAsync(IEnumerable<T> list, IDbTransaction transaction = null, int? commandTimeout = null);
        bool DeleteAll(IDbTransaction transaction = null, int? commandTimeout = null);
        Task<bool> DeleteAllAsync(IDbTransaction transaction = null, int? commandTimeout = null);
    }
}