using GraphQL;
using GraphQL.Types;
using todoApi.Data.Models;
using todoApi.Data.Repositories;
using todoApi.Data.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.Data.GraphQL.Queries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(TodoRepository todoRepository, CategoryRepository categoryRepository)
        {
            Field<ListGraphType<TodoType>, IEnumerable<Todo>>()
                .Name("Todos")
                .ResolveAsync(context => {
                    return todoRepository.GetListAsync();
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
                    return categoryRepository.GetListAsync();
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
