using System;
using System.Collections.Generic;
using Dapper;

namespace todoApi.Data.Models
{
    public interface ICategory
    {
        int Id { get; set; }

        String CategoryName { get; set; }
    }

    [Table ("Categories")]
    public class Category : ICategory
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
