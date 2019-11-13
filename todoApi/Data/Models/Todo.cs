using System;
using Dapper;

namespace todoApi.Data.Models
{
    public interface ITodo
    {
        int Id { get; set; }

        String Details { get; set; }

        Boolean Completed { get; set; }
        
        int? CategoryId { get; set; }
    }

    [ConnectionDetails("DefaultConnection")]
    [Table ("Todos")]
    public class Todo : ITodo
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
