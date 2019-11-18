using System;
using System.Collections.Generic;
using Dapper;
using todoApi.Data.Models;

namespace todoApi.Data.Builders
{

    public class DetailsLike : Constraint
    {
        public override Dictionary<String, Object> Bind(Dapper.SqlBuilder builder)
        {
            var parameters = new Dictionary<String, Object>();

            builder.Where("UPPER(Details) like @DetailsContains");
            parameters.Add("DetailsContains", "%" + this.Value.ToString().ToUpper() + "%");

            return parameters;
        }
    }

    public class TodoConstraints : Todo 
    {
        public DetailsLike DetailsLike { get { return new DetailsLike(); } }
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