using GraphQL.Types;
using Psychological.Repository.Models;

namespace PSPsychological.GraphQL.APIService.GraphQL.GraphQLTypes
{
    public class SurveyType : ObjectGraphType<Survey>
    {
        public SurveyType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("ID của khảo sát.");
            Field(x => x.CategoryId, nullable: true).Description("ID danh mục khảo sát.");
            Field(x => x.Description, nullable: true).Description("Mô tả khảo sát.");
            Field(x => x.Number, nullable: true).Description("Số lượng khảo sát.");
            Field(x => x.PointAverage, nullable: true).Description("Điểm trung bình.");
            Field(x => x.Verygood, nullable: true).Description("Số lượng phản hồi rất tốt.");
            Field(x => x.Good, nullable: true).Description("Số lượng phản hồi tốt.");
            Field(x => x.Medium, nullable: true).Description("Số lượng phản hồi trung bình.");
            Field(x => x.Bad, nullable: true).Description("Số lượng phản hồi kém.");
            Field(x => x.VeryBad, nullable: true).Description("Số lượng phản hồi rất kém.");
            Field(x => x.CreateBy, nullable: true).Description("Người tạo khảo sát.");
            Field(x => x.CreateAt, nullable: true, type: typeof(DateTimeGraphType)).Description("Thời gian tạo.");
            Field(x => x.UpdateAt, nullable: true, type: typeof(DateTimeGraphType)).Description("Thời gian cập nhật.");

            // Liên kết với Category
            Field<ServeyCategoryType>("category", resolve: context => context.Source.Category);
        }
    }
}
