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
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(TodoRepository todoRepository, CategoryRepository categoryRepository)
        {
            Field<ListGraphType<TodoType>, IEnumerable<Todo>>()
                .Name("Todos")
                .ResolveAsync(context => {
                    return todoRepository.GetAllAsync();
                });

            Field<TodoType, Todo>()
                .Name("Todo")
                .Argument<NonNullGraphType<IntGraphType>>("id", "Unique identifier")
                .ResolveAsync(context => {
                    int id = context.GetArgument<int>("id");
                    return todoRepository.GetAsync(id);
                });

            Field<ListGraphType<CategoryType>, IEnumerable<Category>>()
                .Name("Categories")
                .ResolveAsync(context => {
                    return categoryRepository.GetAllAsync();
                });

            Field<CategoryType, Category>()
                .Name("Category")
                .Argument<NonNullGraphType<IntGraphType>>("id", "Unique identifier")
                .ResolveAsync(context => {
                    int id = context.GetArgument<int>("id");
                    return categoryRepository.GetAsync(id);
                });

        }
    }
}
