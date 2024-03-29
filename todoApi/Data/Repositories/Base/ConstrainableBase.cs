using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace todoApi.Data.Repositories
{
    public abstract class ConstrainableBase<TConstraintsModel> 
        : IConstrainable 
        where TConstraintsModel : new()
    {
        public List<Constraint> GetConstrainables()
        {
            var output = new List<Constraint>();

            foreach(var prop in typeof(TConstraintsModel).GetProperties()) 
            {
                Boolean nullable = false;
                TypeCode typeCode = System.TypeCode.Empty;

                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    nullable = true;
                    typeCode = System.Type.GetTypeCode(prop.PropertyType.GetGenericArguments()[0]);
                }
                else
                {
                    typeCode = System.Type.GetTypeCode(prop.PropertyType);
                }

                output.Add(new Constraint(prop.Name, typeCode, nullable));
            }

            return output;         
        }

        public List<Constraint> GetConstraints(Hashtable constraints)
        {
            var output = new List<Constraint>();
            var constrainables = this.GetConstrainables();

            if (constraints.Count > 0)
            {
                var instance = new TConstraintsModel();

                foreach(var key in constraints.Keys)
                {
                    var validConstraint = constrainables.GetByColumn(key.ToString());
                    if (validConstraint != null)
                    {
                        Constraint constraint = null;
                        if (validConstraint.DataType == TypeCode.Object)
                        {
                            var customObjType = typeof(TConstraintsModel).GetProperty(validConstraint.Column).PropertyType;
                            var constraintType = typeof(Constraint);
                            var isConstraint = (customObjType.IsSubclassOf(constraintType) || customObjType == constraintType);
                            if (isConstraint) 
                            {
                                constraint = (Constraint)Activator.CreateInstance(customObjType);
                                constraint.DataType = TypeCode.Object;
                                constraint.Value = constraints[key].ToString();
                                constraint.Comparison = validConstraint.Comparison;
                            }
                        }

                        if (constraint == null)
                        {
                            constraint = new Constraint(validConstraint.Column, validConstraint.DataType, validConstraint.Nullable, constraints[key].ToString(), Comparison.Equals);
                        }

                        output.Add(constraint);
                    }
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