using System;
using System.Collections.Generic;
using Dapper;

namespace todoApi.Data.Models
{
    [Table ("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public String CategoryName { get; set; }
    }

    public class CategoryRelated : Category
    {
        public IEnumerable<Todo> Todos { get; set; }
    }
}
