using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todoApi.Controllers;
using todoApi.Data.Repositories;
using todoApi.Data.Models;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ResourceControllerBase<CategoryController, Category, CategoryRepository>
    {
        public CategoryController(ILogger<CategoryController> logger, CategoryRepository repository) : base(logger, repository)
        {
        }
    }
}
