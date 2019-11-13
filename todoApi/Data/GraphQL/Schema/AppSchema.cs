using GraphQL;
using GraphQL.Types;
using todoApi.Data.GraphQL.Queries;
using todoApi.Data.GraphQL.Mutations;

namespace todoApi.Data.GraphQL.Schemas
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver)
            :base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
            Mutation = resolver.Resolve<AppMutation>();
        }
    }
}
