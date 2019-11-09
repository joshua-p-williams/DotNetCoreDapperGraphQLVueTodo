using GraphQL;
using GraphQL.Types;
using todoApi.GraphQL.GraphQLQueries;

namespace todoApi.GraphQL.GraphQLSchema
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
