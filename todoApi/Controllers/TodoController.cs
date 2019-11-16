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

        [HttpGet("test")]
        /*
        public Dapper.SqlBuilder.Template GetTest()
        {
            var j = new todoApi.Data.Builders.TodoBuilder();
            return j.Where("{ 'Id': 2, 'Detailsasdf': 'Change the oil', 'b': 'c' }");
        }
        /**/
        public Task<IEnumerable<Todo>> GetTest()
        {
            var j = new todoApi.Data.Builders.TodoBuilder();
            var x = j.Where("{ 'Id': 2, 'Details': 'Change the oil', 'b': 'c' }");

            return _repository.GetListAsync(x.Sql, x.Parameters);
        }
        /**/

    }
}
