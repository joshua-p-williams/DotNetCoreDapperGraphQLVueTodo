using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace todoApi.Contracts
{
    public interface IResourceControllerBase<TController, TModel, TRepository>
    {
        [HttpGet]
        IEnumerable<TModel> GetAll();
    }
}