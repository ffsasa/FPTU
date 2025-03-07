using GraphQL.Resolvers;
using GraphQL.Types;
using PSPsychological.GraphQL.APIService.GraphQL.GraphQLTypes;
using Psychological.Repository.Models;
using Psychological.Service;

namespace PSPsychological.GraphQL.APIService.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(ISurveyService repository)
        {
            AddField(new FieldType
            {
                Name = "surveys",
                Type = typeof(ListGraphType<SurveyType>),
                Resolver = new AsyncFieldResolver<List<Survey>>(async context => await repository.GetAll())
            });
        }
    }
}
