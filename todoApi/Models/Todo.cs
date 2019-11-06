using System;

namespace todoApi.Models
{
    public class Todo
    {
        public int id { get; set; }

        public String item { get; set; }

        public Boolean completed { get; set; }
    }
}
