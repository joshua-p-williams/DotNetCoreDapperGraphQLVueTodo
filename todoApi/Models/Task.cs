using System;

namespace todoApi.Models
{
    public class Task
    {
        public int id { get; set; }

        public String item { get; set; }

        public Boolean completed { get; set; }
    }
}
