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
    public class ConstrainableBuilder<TConstraintsModel>
    {
        public List<Constraint> GetConstrainables()
        {
            var output = new List<Constraint>();

            foreach(var prop in typeof(TConstraintsModel).GetProperties()) 
            {
                var typeCode = System.Type.GetTypeCode(prop.PropertyType);
                output.Add( new Constraint(prop.Name, typeCode));
            }

            return output;         
        }

        public List<Constraint> GetConstraints(Hashtable constraints)
        {
            var output = new List<Constraint>();
            var constrainables = this.GetConstrainables();

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

        public List<Constraint> GetConstraints(JObject json)
        {
            var hash = new Hashtable();
            foreach (var item in json) 
            {
                hash.Add(item.Key, item.Value.ToString());
            }

            return this.GetConstraints(hash);
        }

        public List<Constraint> GetConstraintsFromJson(String json)
        {
            var obj = JsonConvert.DeserializeObject<JObject>(json);
            return this.GetConstraints(obj);
        }
    }
}