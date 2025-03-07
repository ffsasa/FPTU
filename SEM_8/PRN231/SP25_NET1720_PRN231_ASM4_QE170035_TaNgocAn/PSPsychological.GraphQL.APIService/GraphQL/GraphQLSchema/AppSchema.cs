using GraphQL.Types;
using PSPsychological.GraphQL.APIService.GraphQL.GraphQLQueries;

namespace PSPsychological.GraphQL.APIService.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
        : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
        }
    }
}
