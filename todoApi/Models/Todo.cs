using System;

namespace todoApi.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public String Details { get; set; }

        public Boolean Completed { get; set; }
    }
}
