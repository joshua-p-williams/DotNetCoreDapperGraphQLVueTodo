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

            builder.Where("UPPER(Details) like @DetailsLike");
            parameters.Add("DetailsLike", "%" + this.Value.ToString().ToUpper() + "%");

            return parameters;
        }
    }

    public class TodoConstraints : Todo 
    {
        public DetailsLike DetailsLike { get; set; }
    }

    public class TodoBuilder : BuilderBase<TodoConstraints>
    {
    }
}