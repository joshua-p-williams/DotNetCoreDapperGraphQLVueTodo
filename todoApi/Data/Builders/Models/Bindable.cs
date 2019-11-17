using System;
using System.Collections.Generic;

namespace todoApi.Data.Builders
{
    public class Bindable
    {
        public String Sql { get; set; }
        public Dictionary<String, Object> Parameters { get; set; }

        public Bindable()
        {
            this.Parameters = new Dictionary<String, Object>();
        }

        public static Bindable GetBindable(String sql, Dictionary<String, Object> parameters)
        {
            var output = new Bindable();

            output.Sql = sql;
            output.Parameters = parameters;
            
            return output;
        }

    }
}