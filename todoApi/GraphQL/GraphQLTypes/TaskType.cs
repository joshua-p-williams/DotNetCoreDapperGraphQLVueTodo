using GraphQL.Types;
using todoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.GraphQL.GraphQLTypes
{
    public class TaskType : ObjectGraphType<todoApi.Models.Task>
    {
        public TaskType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the task object.");
            Field(x => x.Item).Description("Description property from the task object.");
            Field(x => x.Completed, type: typeof(BooleanGraphType)).Description("Completed property from the task object.");
        }
    }
}
