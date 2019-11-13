using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.Data.GraphQL.Types
{
    public class CategoryInputType : InputObjectGraphType
    {
        public CategoryInputType()
        {
            Name = "CategoryInput";
            Field<NonNullGraphType<StringGraphType>>("categoryName");
        }
    }
}
