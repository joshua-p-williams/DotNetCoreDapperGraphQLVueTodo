using GraphQL.Types;
using todoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.GraphQL.GraphQLTypes
{
    public class TodoType : ObjectGraphType<Todo>
    {
        public TodoType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the todo object.");
            Field(x => x.Details).Description("Description property from the todo object.");
            Field(x => x.Completed, type: typeof(BooleanGraphType)).Description("Completed property from the todo object.");
        }
    }
}
