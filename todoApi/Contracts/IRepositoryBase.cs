using System;
using System.Collections.Generic;

namespace todoApi.Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
    }
}