using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using PSPsychological.GraphQL.APIService.GraphQL.GraphQLTypes;
using Psychological.Repository.Models;
using Psychological.Service;

namespace PSPsychological.GraphQL.APIService.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(ISurveyService repository)
        {
            // Tạo khảo sát mới
            AddField(new FieldType
            {
                Name = "createSurvey",
                Type = typeof(SurveyType),
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }, 
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "description" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "categoryId" },
                    new QueryArgument<IntGraphType> { Name = "number" },
                    new QueryArgument<FloatGraphType> { Name = "pointAverage" },
                    new QueryArgument<IntGraphType> { Name = "verygood" },
                    new QueryArgument<IntGraphType> { Name = "good" },
                    new QueryArgument<IntGraphType> { Name = "medium" },
                    new QueryArgument<IntGraphType> { Name = "bad" },
                    new QueryArgument<IntGraphType> { Name = "veryBad" }
                ),
                Resolver = new AsyncFieldResolver<Survey>(async context =>
                {
                    var survey = new Survey
                    {
                        Id = context.GetArgument<int>("id"),
                        Description = context.GetArgument<string>("description"),
                        CategoryId = context.GetArgument<int>("categoryId"),
                        Number = context.GetArgument<int?>("number"),
                        PointAverage = context.GetArgument<double?>("pointAverage"),
                        Verygood = context.GetArgument<int?>("verygood"),
                        Good = context.GetArgument<int?>("good"),
                        Medium = context.GetArgument<int?>("medium"),
                        Bad = context.GetArgument<int?>("bad"),
                        VeryBad = context.GetArgument<int?>("veryBad"),
                        CreateAt = DateTime.UtcNow
                    };
                    var id = await repository.Create(survey);
                    survey.Id = id;
                    return survey;
                })
            });

            // Xóa khảo sát
            AddField(new FieldType
            {
                Name = "deleteSurvey",
                Type = typeof(BooleanGraphType),
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                Resolver = new AsyncFieldResolver<bool>(async context =>
                {
                    var id = context.GetArgument<int>("id");
                    return await repository.Delete(id);
                })
            });

            // Cập nhật khảo sát
            AddField(new FieldType
            {
                Name = "updateSurvey",
                Type = typeof(SurveyType),
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "description" },
                    new QueryArgument<IntGraphType> { Name = "categoryId" },
                    new QueryArgument<IntGraphType> { Name = "number" },
                    new QueryArgument<FloatGraphType> { Name = "pointAverage" },
                    new QueryArgument<IntGraphType> { Name = "verygood" },
                    new QueryArgument<IntGraphType> { Name = "good" },
                    new QueryArgument<IntGraphType> { Name = "medium" },
                    new QueryArgument<IntGraphType> { Name = "bad" },
                    new QueryArgument<IntGraphType> { Name = "veryBad" }
                ),
                Resolver = new AsyncFieldResolver<Survey>(async context =>
                {
                    var id = context.GetArgument<int>("id");
                    var survey = await repository.GetById(id);
                    if (survey == null)
                        throw new Exception("Survey không tồn tại!");

                    survey.Description = context.GetArgument<string>("description", survey.Description);
                    survey.CategoryId = context.GetArgument<int?>("categoryId", survey.CategoryId);
                    survey.Number = context.GetArgument<int?>("number", survey.Number);
                    survey.PointAverage = context.GetArgument<double?>("pointAverage", survey.PointAverage);
                    survey.Verygood = context.GetArgument<int?>("verygood", survey.Verygood);
                    survey.Good = context.GetArgument<int?>("good", survey.Good);
                    survey.Medium = context.GetArgument<int?>("medium", survey.Medium);
                    survey.Bad = context.GetArgument<int?>("bad", survey.Bad);
                    survey.VeryBad = context.GetArgument<int?>("veryBad", survey.VeryBad);
                    survey.UpdateAt = DateTime.UtcNow;

                    await repository.Update(survey);
                    return survey;
                })
            });

        }
    }
}
