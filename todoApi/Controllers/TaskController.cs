using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todoApi.Models;
using System.Data.SqlClient;
using Dapper;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<todoApi.Models.Task> Get()
        {
            using (var connection = new SqlConnection("Server=127.0.0.1;Database=todo;User=sa;Password=letmein123;"))
            {
                return connection.Query<todoApi.Models.Task>("select * from todo.dbo.tasks").ToList();                
            }
        }
    }
}
