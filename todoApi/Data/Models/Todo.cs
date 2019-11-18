using System;
using Dapper;

namespace todoApi.Data.Models
{
    [ConnectionDetails("DefaultConnection")]
    [Table ("Todos")]
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        public String Details { get; set; }

        public Boolean Completed { get; set; }
        
        public int? CategoryId { get; set; }
    }

    public class TodoRelated : Todo
    {
        public Category Category { get; set; }

    }
}
