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
                .Resolve(context => {
                    return todoRepository.GetAll();
                });

            Field<TodoType, Todo>()
                .Name("Todo")
                .Argument<NonNullGraphType<IntGraphType>>("id", "Unique identifier")
                .Resolve(context => {
                    int id = context.GetArgument<int>("id");
                    return todoRepository.Get(id);
                });

            Field<ListGraphType<CategoryType>, IEnumerable<Category>>()
                .Name("Categories")
                .Resolve(context => {
                    return categoryRepository.GetAll();
                });

            Field<CategoryType, Category>()
                .Name("Category")
                .Argument<NonNullGraphType<IntGraphType>>("id", "Unique identifier")
                .Resolve(context => {
                    int id = context.GetArgument<int>("id");
                    return categoryRepository.Get(id);
                });

        }
    }
}
