using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace todoApi.Data.Builders
{
    public static class ConstrainableExtensions
    {
        public static List<Constraint> GetConstrainables<T>()
        {
            var output = new List<Constraint>();

            foreach(var prop in typeof(T).GetProperties()) 
            {
                var typeCode = System.Type.GetTypeCode(prop.PropertyType);
                output.Add( new Constraint(prop.Name, typeCode));
            }

            return output;         
        }

        public static List<Constraint> GetConstraints<T>(this Hashtable constraints)
        {
            var output = new List<Constraint>();
            var constrainables = GetConstrainables<T>();

            foreach(var key in constraints.Keys)
            {
                var validConstraint = constrainables.GetByColumn(key.ToString());
                if (validConstraint != null)
                {
                    var constraint = new Constraint(validConstraint.Column, validConstraint.DataType, constraints[key].ToString(), Comparison.Equals);
                    output.Add(constraint);
                }
            }

            return output;
        }

        public static List<Constraint> GetConstraints<T>(this JObject json)
        {
            var hash = new Hashtable();
            foreach (var item in json) 
            {
                hash.Add(item.Key, item.Value.ToString());
            }

            return hash.GetConstraints<T>();
        }

        public static List<Constraint> GetConstraintsFromJson<T>(String json)
        {
            var obj = JsonConvert.DeserializeObject<JObject>(json);
            return obj.GetConstraints<T>();
        }
    }
}