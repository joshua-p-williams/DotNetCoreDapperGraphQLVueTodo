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
    public class TodoController : ResourceControllerBase<TodoController, Todo, TodoRepository>
    {
        public TodoController(ILogger<TodoController> logger, TodoRepository todoRepository) : base(logger, todoRepository)
        {
        }
    }
}
