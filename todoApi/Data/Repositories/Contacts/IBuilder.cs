using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace todoApi.Data.Repositories
{
    public interface IBuilder : IConstrainable 
    {
        Bindable Where(List<Constraint> constraints);
        Bindable Where(Hashtable constraints);
        Bindable Where(JObject json);
        Bindable WhereFromJson(String json);
    }
}