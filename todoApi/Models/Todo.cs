using System;
using Dapper.Contrib.Extensions;

namespace todoApi.Models
{
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
