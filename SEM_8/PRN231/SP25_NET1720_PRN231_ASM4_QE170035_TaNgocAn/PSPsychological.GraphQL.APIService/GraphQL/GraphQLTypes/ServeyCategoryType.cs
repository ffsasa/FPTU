using GraphQL.Types;
using Psychological.Repository.Models;

namespace PSPsychological.GraphQL.APIService.GraphQL.GraphQLTypes
{
    public class ServeyCategoryType : ObjectGraphType<ServeyCategory>
    {
        public ServeyCategoryType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("ID của danh mục khảo sát.");
            Field(x => x.Name).Description("Tên danh mục khảo sát.");
            Field(x => x.CreateAt, nullable: true, type: typeof(DateTimeGraphType)).Description("Thời gian tạo.");
            Field(x => x.UpdateAt, nullable: true, type: typeof(DateTimeGraphType)).Description("Thời gian cập nhật.");

            // Liên kết với Surveys
            Field<ListGraphType<SurveyType>>("surveys", resolve: context => context.Source.Surveys);
        }
    }
}
