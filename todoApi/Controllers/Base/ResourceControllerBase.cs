using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using todoApi.Data.Repositories;
using todoApi.Data.Builders;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ResourceControllerBase<TController, TModel, TRepository, TBuilder> : Controller, IResourceController<TController, TModel, TRepository, TBuilder> 
        where TController : class
        where TModel : class
        where TRepository : IRepository<TModel>
        where TBuilder : IBuilder<TModel>
    {
        protected readonly ILogger<TController> _logger;

        protected readonly TRepository _repository;

        protected readonly TBuilder _builder;

        public ResourceControllerBase(ILogger<TController> logger, TRepository repository, TBuilder builder)
        {
            _logger = logger;
            _repository = repository;
            _builder = builder;
        }

        [HttpGet]
        public virtual Task<IEnumerable<TModel>> GetList()
        {
            return _repository.GetListAsync();
        }

        [HttpGet("{id}")]
        public Task<TModel> Get(int id) 
        {
            return _repository.GetAsync(id);
        }
    }
}