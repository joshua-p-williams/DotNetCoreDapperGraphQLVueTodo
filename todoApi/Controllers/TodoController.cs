using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todoApi.Controllers;
using todoApi.Data.Repositories;
using todoApi.Data.Models;
using todoApi.Data.Builders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ResourceControllerBase<TodoController, Todo, TodoRepository, TodoBuilder>
    {
        public TodoController(ILogger<TodoController> logger, TodoRepository todoRepository, TodoBuilder todoBuilder) : base(logger, todoRepository, todoBuilder)
        {
        }
    }
}
