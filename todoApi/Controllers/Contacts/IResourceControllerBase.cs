using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace todoApi.Controllers
{
    public interface IResourceControllerBase<TController, TModel, TRepository>
    {
        [HttpGet]
        Task<IEnumerable<TModel>> GetList();

        [HttpGet("{id}")]
        Task<TModel> Get(int id);
    }
}