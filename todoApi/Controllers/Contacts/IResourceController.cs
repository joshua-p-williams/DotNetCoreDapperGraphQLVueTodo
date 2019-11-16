using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace todoApi.Controllers
{
    public interface IResourceController<TController, TModel, TRepository, TBuilder>
    {
        [HttpGet]
        Task<IEnumerable<TModel>> GetList();

        [HttpGet("{id}")]
        Task<TModel> Get(int id);
    }
}