using System;
using System.Collections.Generic;
using Dapper;
using todoApi.Data.Models;

namespace todoApi.Data.Builders
{

    public class TodoConstraints : Todo 
    {
        public FirstCategoryConstraint FirstCategory { get { return new FirstCategoryConstraint(); } }

        public class FirstCategoryConstraint : Constraint
        {
            public override Dictionary<String, Object> Bind(Dapper.SqlBuilder builder)
            {
                var parameters = new Dictionary<String, Object>();

                builder.Where("category = @FirstCategory");
                parameters.Add("FirstCategory", 1);

                return parameters;
            }
        }

    }

    public class TodoBuilder : BuilderBase<TodoConstraints>
    {
        public class ConstrainBy : Todo
        {
            public int ByEvenId;
        }
        
        public override List<IQueryScope> SetQueryContext()
        {
            var output = new List<IQueryScope>();

            //output.Add(new ByEven());

            return output;
        }
    }
}