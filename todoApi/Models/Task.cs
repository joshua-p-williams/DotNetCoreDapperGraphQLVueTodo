using System;

namespace todoApi.Models
{
    public class Task
    {
        public int Id { get; set; }

        public String Item { get; set; }

        public Boolean Completed { get; set; }
    }
}
