using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Dapper;

namespace todoApi.Data.Builders
{
    public interface IQueryScope
    {
        String QueryScopeName { get; }
        Bindable Build(Constraint constraint);
    }
}