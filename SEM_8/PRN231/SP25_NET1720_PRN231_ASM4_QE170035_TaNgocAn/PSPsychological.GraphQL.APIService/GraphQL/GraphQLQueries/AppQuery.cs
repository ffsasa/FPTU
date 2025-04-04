using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using PSPsychological.GraphQL.APIService.GraphQL.GraphQLTypes;
using Psychological.Repository.Models;
using Psychological.Service;

namespace PSPsychological.GraphQL.APIService.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(ISurveyService repository, ISurveyCategoryService categoryService)
        {
            AddField(new FieldType
            {
                Name = "surveys",
                Type = typeof(ListGraphType<SurveyType>),
                Resolver = new AsyncFieldResolver<List<Survey>>(async context => await repository.GetAll())
            });

            AddField(new FieldType
            {
                Name = "categories",
                Type = typeof(ListGraphType<ServeyCategoryType>),
                Resolver = new AsyncFieldResolver<List<ServeyCategory>>(async context => await categoryService.GetAll())
            });

            AddField(new FieldType
            {
                Name = "survey",
                Type = typeof(SurveyType),
                Arguments = new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                Resolver = new AsyncFieldResolver<Survey>(async context =>
                {
                    var id = context.GetArgument<int>("id");
                    return await repository.GetById(id);
                })
            });

            AddField(new FieldType
            {
                Name = "searchSurveys",
                Type = typeof(ListGraphType<SurveyType>),
                Arguments = new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "nameCategory", Description = "Tên khảo sát" },
                new QueryArgument<IntGraphType> { Name = "number", Description = "Số lượng khảo sát" },
                new QueryArgument<IntGraphType> { Name = "verygood", Description = "Số phản hồi rất tốt" }
            ),
                Resolver = new AsyncFieldResolver<List<Survey>>(async context =>
                {
                    var name = context.GetArgument<string>("nameCategory", null);
                    var number = context.GetArgument<int?>("number") ?? 0;
                    var veryGood = context.GetArgument<int?>("verygood") ?? 0;
                    return await repository.SearchAsync(name, number, veryGood);
                })
            });
        }
    }
}
