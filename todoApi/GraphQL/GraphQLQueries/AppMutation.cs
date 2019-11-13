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
        public AppMutation(TodoRepository todoRepository, CategoryRepository categoryRepository)
        {
            Field<TodoType, Todo>()
                .Name("createTodo")
                .Argument<NonNullGraphType<TodoInputType>>("todo", "todo input")
                .ResolveAsync(context => {
                    var todo = context.GetArgument<Todo>("todo");
                    var id = todoRepository.Insert(todo);
                    return todoRepository.GetAsync(id.Value);
                });

            Field<TodoType, int>()
                .Name("updateTodo")
                .Argument<NonNullGraphType<TodoInputType>>("todo", "todo input")
                .ResolveAsync(context => {
                    var todo = context.GetArgument<Todo>("todo");
                    return todoRepository.UpdateAsync(todo);
                });

            Field<TodoType, int>()
                .Name("deleteTodo")
                .Argument<NonNullGraphType<TodoInputType>>("todo", "todo input")
                .ResolveAsync(context => {
                    var todo = context.GetArgument<Todo>("todo");
                    return todoRepository.DeleteAsync(todo);
                });
        }
    }
}
