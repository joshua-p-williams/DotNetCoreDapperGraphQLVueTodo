using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todoApi.Controllers.Base;
using todoApi.Repositories;
using todoApi.Models;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ResourceControllerBase<CategoryController, Category, CategoryRepository>
    {
        public CategoryController(ILogger<CategoryController> logger, CategoryRepository categoryRepository) : base(logger, categoryRepository)
        {
        }
    }
}
