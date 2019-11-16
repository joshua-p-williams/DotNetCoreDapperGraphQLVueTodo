using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace todoApi.Data.Builders
{
    public interface IBuilder<TModel> where TModel : new()
    {
        Bindable<TModel> WhereFromJson(String json);
        Bindable<TModel> Where(JObject json);
    }
}