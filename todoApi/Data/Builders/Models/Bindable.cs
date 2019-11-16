using System;
using System.Collections.Generic;

namespace todoApi.Data.Builders
{
    public class Bindable<T> where T : new()
    {
        public String Sql { get; set; }
        public T Parameters { get; set; }

        public Bindable()
        {
            this.Parameters = new T();
        }

    }
}