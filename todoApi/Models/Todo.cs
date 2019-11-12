using System;
using Dapper;

namespace todoApi.Models
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

        public Category Category { get; set; }
    }
}
