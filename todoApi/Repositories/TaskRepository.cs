using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace todoApi.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<todoApi.Models.Task> Get();
    }

    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _config;

        public TaskRepository(IConfiguration config)
        {
            this._config = config;
        }

        public IEnumerable<todoApi.Models.Task> Get()
        {
            IEnumerable<todoApi.Models.Task> task = null;

            using (var connection = new SqlConnection(_config.GetValue<String>("ConnectionStrings:DefaultConnection")))
            {
                task = connection.Query<todoApi.Models.Task>("select * from todo.dbo.tasks");
            }

            return task;
        }
    }
}