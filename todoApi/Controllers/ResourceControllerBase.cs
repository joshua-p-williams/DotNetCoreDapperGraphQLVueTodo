using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using todoApi.Contracts;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ResourceControllerBase<TController, TModel, TRepository> : Controller, IResourceControllerBase<TController, TModel, TRepository> 
        where TController : class
        where TModel : class
        where TRepository : IRepositoryBase<TModel>
    {
        private readonly ILogger<TController> _logger;
        private readonly TRepository _repository;

        public ResourceControllerBase(ILogger<TController> logger, TRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public virtual IEnumerable<TModel> Get()
        {
            return _repository.FindAll().ToList();
        }
    }
}