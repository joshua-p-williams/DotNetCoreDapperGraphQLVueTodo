using GraphQL;
using GraphQL.Types;
using todoApi.Contracts;
using todoApi.Models;
using todoApi.Repositories;
using todoApi.GraphQL.GraphQLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(TaskRepository repository)
        {
            Field<TaskType>(
                "createTask",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<TaskInputType>> { Name = "task" }),
                resolve: context =>
                {
                    var task = context.GetArgument<todoApi.Models.Task>("task");
                    return repository.Create(task);
                }
            );

            Field<TaskType>(
                "updateTask",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TaskInputType>> { Name = "task" }, 
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "taskId" }),
                resolve: context =>
                {
                    var newTask = context.GetArgument<todoApi.Models.Task>("task");
                    var taskId = context.GetArgument<int>("taskId");

                    var existingTask = repository.GetById(taskId);
                    if (existingTask == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find task in db."));
                        return null;
                    }

                    return repository.Update(existingTask, newTask);
                }
            );

            Field<StringGraphType>(
                "deleteTask",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "taskId" }),
                resolve: context =>
                {
                    var taskId = context.GetArgument<int>("taskId");
                    var task = repository.GetById(taskId);
                    if (task == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find task in db."));
                        return null;
                    }

                    repository.Delete(task);
                    return $"The task with the id: {taskId} has been successfully deleted from db.";
                }
            );
        }
    }
}
