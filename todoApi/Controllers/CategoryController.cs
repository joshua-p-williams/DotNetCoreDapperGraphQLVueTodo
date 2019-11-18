using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todoApi.Controllers;
using todoApi.Data.Repositories;
using todoApi.Data.Models;
using todoApi.Data.Builders;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ResourceControllerBase<CategoryController, Category, CategoryRepository, CategoryBuilder>
    {
        public CategoryController(ILogger<CategoryController> logger, CategoryRepository repository, CategoryBuilder builder) : base(logger, repository, builder)
        {
        }
    }
}
