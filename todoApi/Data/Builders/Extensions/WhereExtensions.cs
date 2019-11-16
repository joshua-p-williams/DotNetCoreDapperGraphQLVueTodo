using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Dapper;
using todoApi.Data.Builders;

namespace todoApi.Data.Builders
{
    public static class WhereExtensions
    {
        public static Bindable<T> Where<T>(this SqlBuilder builder, List<Constraint> constraints)  where T : new()
        {
            var output = new Bindable<T>();

            foreach(var constraint in constraints) 
            {
                //builder.Where($"{constraint.Column} = @{constraint.Column}", new { Id = 2 });

                var prop = output.Parameters.GetType().GetProperty(constraint.Column);
                prop.SetValue(output.Parameters, Convert.ChangeType(constraint.Value, constraint.DataType), null);

                builder.Where($"{constraint.Column} = @{constraint.Column}");
            }

            output.Sql = builder.AddTemplate("/**where**/").RawSql;

            return output;
        }

        public static Bindable<T> Where<T>(this SqlBuilder builder, Hashtable constraints) where T : new()
        {
            return builder.Where<T>(ConstrainableExtensions.GetConstraints<T>(constraints));
        }

        public static Bindable<T> Where<T>(this SqlBuilder builder, JObject json) where T : new()
        {
            return builder.Where<T>(ConstrainableExtensions.GetConstraints<T>(json));
        }

        public static Bindable<T> WhereFromJson<T>(this SqlBuilder builder, String json) where T : new()
        {
            var obj = JsonConvert.DeserializeObject<JObject>(json);
            return builder.Where<T>(obj);
        }

    }
}