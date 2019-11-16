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
        public CategoryController(ILogger<CategoryController> logger, CategoryRepository categoryRepository, CategoryBuilder categoryBuilder) : base(logger, categoryRepository, categoryBuilder)
        {
        }
    }
}
