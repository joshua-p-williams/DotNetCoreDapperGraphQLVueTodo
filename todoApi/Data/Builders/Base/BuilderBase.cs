using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Dapper;

namespace todoApi.Data.Builders
{
    public abstract class BuilderBase<TModel> : IBuilder<TModel> where TModel : new()
    {
        protected SqlBuilder _builder = new SqlBuilder();
        public Bindable<TModel> Where(String json)
        {
            return _builder.WhereFromJson<TModel>(json);
        }

        public int getTest()
        {
            return 1;
        }
    }
}