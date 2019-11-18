using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todoApi.Controllers;
using todoApi.Data.Repositories;
using todoApi.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ResourceControllerBase<TodoController, Todo, TodoRepository>
    {
        public TodoController(ILogger<TodoController> logger, TodoRepository repository) : base(logger, repository)
        {
        }
    }
}
