using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todoApi.Controllers.Base;
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
