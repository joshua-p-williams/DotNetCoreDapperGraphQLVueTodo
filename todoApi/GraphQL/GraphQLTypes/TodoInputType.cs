using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.GraphQL.GraphQLTypes
{
    public class TodoInputType : InputObjectGraphType
    {
        public TodoInputType()
        {
            Name = "todoInput";
            Field<NonNullGraphType<StringGraphType>>("destails");
            Field<NonNullGraphType<BooleanGraphType>>("completed");
        }
    }
}
