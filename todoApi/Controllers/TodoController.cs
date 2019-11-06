using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todoApi.Models;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private static readonly string[] Todos = new[]
        {
            "Go to the store", "Do some coding", "Feed the dog", "Change the oil"
        };

        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Todo
            {
                id = rng.Next(500),
                item = Todos[rng.Next(Todos.Length)],
                completed = rng.NextDouble() >= 0.5,
            })
            .ToArray();
        }
    }
}
