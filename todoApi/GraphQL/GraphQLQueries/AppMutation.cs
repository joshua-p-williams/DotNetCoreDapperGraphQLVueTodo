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
        public AppMutation(TodoRepository repository)
        {
            Field<TodoType>(
                "createTodo",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<TodoInputType>> { Name = "todo" }),
                resolve: context =>
                {
                    var todo = context.GetArgument<Todo>("todo");
                    return repository.Create(todo);
                }
            );

            Field<TodoType>(
                "updateTodo",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TodoInputType>> { Name = "todo" }, 
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var newItem = context.GetArgument<Todo>("todo");
                    var id = context.GetArgument<int>("id");

                    var existingItem = repository.GetById(id);
                    if (existingItem == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find todo in db."));
                        return null;
                    }

                    return repository.Update(existingItem, newItem);
                }
            );

            Field<StringGraphType>(
                "deleteTodo",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var todo = repository.GetById(id);
                    if (todo == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find todo in db."));
                        return null;
                    }

                    repository.Delete(todo);
                    return $"The todo with the id: {id} has been successfully deleted from db.";
                }
            );
        }
    }
}
