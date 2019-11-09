using System;
using System.Collections.Generic;

namespace todoApi.Contracts
{
    public interface IRepositoryBase<T>
    {
        T GetById(int id);
        IEnumerable<T> FetchAll();
        T Create(T item);
        T Update(T existingItem, T newItem);
        Boolean Delete(T item);
    }
}