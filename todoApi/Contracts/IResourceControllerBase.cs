using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace todoApi.Contracts
{
    public interface IResourceControllerBase<TController, TModel, TRepository>
    {
        [HttpGet]
        Task<IEnumerable<TModel>> GetAll();

        [HttpGet("{id}")]
        Task<TModel> Get(int id);
    }
}