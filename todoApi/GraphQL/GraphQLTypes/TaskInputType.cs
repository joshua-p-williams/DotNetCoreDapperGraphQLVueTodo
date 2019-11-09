using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.GraphQL.GraphQLTypes
{
    public class TaskInputType : InputObjectGraphType
    {
        public TaskInputType()
        {
            Name = "taskInput";
            Field<NonNullGraphType<StringGraphType>>("item");
            Field<NonNullGraphType<BooleanGraphType>>("completed");
        }
    }
}
