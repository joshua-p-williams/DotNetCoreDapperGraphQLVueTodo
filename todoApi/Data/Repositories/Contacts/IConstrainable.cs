using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace todoApi.Data.Repositories
{
    public interface IConstrainable
    {
        List<Constraint> GetConstrainables();
        List<Constraint> GetConstraints(Hashtable constraints);
        List<Constraint> GetConstraints(JObject json);
        List<Constraint> GetConstraintsFromJson(String json);
    }
}