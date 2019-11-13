using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using todoApi.Data.Models;

namespace todoApi.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(IConfiguration config) : base (config)
        {
        }
    }
}