using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using todoApi.Repositories;

namespace todoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ResourceControllerBase<TaskController, todoApi.Models.Task, TaskRepository>
    {
        public TaskController(ILogger<TaskController> logger, TaskRepository taskRepository) : base(logger, taskRepository)
        {
        }
    }
}
