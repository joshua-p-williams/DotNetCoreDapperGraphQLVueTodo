using System;
using System.Collections.Generic;
using Dapper;

namespace todoApi.Models
{
    [Table ("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public String CategoryName { get; set; }

        public IEnumerable<Todo> Todos { get; set; }
    }
}
