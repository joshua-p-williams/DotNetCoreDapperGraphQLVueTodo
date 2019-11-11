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
            Name = "TodoInput";
            Field<NonNullGraphType<StringGraphType>>("details");
            Field<IntGraphType>("categoryId");
            Field<NonNullGraphType<BooleanGraphType>>("completed");
        }
    }
}
