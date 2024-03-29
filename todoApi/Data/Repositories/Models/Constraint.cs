using System;
using System.Collections.Generic;

namespace todoApi.Data.Repositories
{
    public enum Comparison 
    {
        Equals = 0,
    }

    public static class ConstraintExtensions
    {
        public static Constraint GetByColumn(this List<Constraint> constraints, String column)
        {
            Constraint output = null;

            foreach(var item in constraints)
            {
                if (item.Column.Equals(column, StringComparison.InvariantCultureIgnoreCase))
                {
                    output = item;
                    break;
                }
            }

            return output;
        }    
    }

    public class Constraint
    {
        public String Column { get; set; }
        public Object Value { get; set; }
        public TypeCode DataType { get; set; }
        public Boolean Nullable { get; set; }
        public Comparison Comparison { get; set; }


        public Constraint()
        {
            this.Comparison = Comparison.Equals;
        }

        public Constraint(String column, TypeCode dataType, Boolean nullable = false, Object value = null, Comparison comparison = Comparison.Equals)
        {
            this.Column = column;
            this.DataType = dataType;
            this.Nullable = nullable;
            this.Value = value;
            this.Comparison = comparison;
        }

        public virtual Dictionary<String, Object> Bind(Dapper.SqlBuilder builder)
        {
            var parameters = new Dictionary<String, Object>();

            if (this.Comparison == Comparison.Equals) {
                builder.Where($"{this.Column} = @{this.Column}");
            }
            else {
                throw new NotImplementedException("This constraint comparison type is not implemented yet");
            }

            parameters.Add(this.Column, Convert.ChangeType(this.Value, this.DataType));

            return parameters;
        }

    }
}