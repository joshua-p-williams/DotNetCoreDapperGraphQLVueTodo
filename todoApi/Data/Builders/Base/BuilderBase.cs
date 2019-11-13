using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace todoApi.Data.Builders
{
    public abstract class BuilderBase : IBuilderBase
    {
        public int getTest()
        {
            return 1;
        }
    }
}