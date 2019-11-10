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
        public AppQuery(TaskRepository repository)
        {
            Field<ListGraphType<TaskType>>(
               "tasks",
               resolve: context => repository.FetchAll()
            );

            Field<TaskType>(
                "task",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    int id;
                    if (!int.TryParse(context.GetArgument<string>("id"), out id))
                    {
                        context.Errors.Add(new ExecutionError("Wrong value for id"));
                        return null;
                    }

                    return repository.GetById(id);
                }
            );
        }
    }
}