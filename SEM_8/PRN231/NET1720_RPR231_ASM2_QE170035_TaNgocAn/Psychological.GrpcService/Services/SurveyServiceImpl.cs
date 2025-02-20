using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Psychological.GrpcService.Models;

namespace Psychological.GrpcService.Services
{
    public class SurveyServiceImpl : SurveyService.SurveyServiceBase
    {
        private readonly SurveyService _surveyService;

        // Constructor nhận vào SurveyService để gọi logic lấy dữ liệu
        public SurveyServiceImpl(SurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        // Triển khai phương thức GetAll
        public override Task<SurveyList> GetAll(Empty request, ServerCallContext context)
        {
            var surveys = _surveyService.GetAll();  // Gọi phương thức từ SurveyService để lấy dữ liệu
            var response = new SurveyList();

            foreach (var survey in surveys)
            {
                response.Surveys.Add(new Survey
                {
                    Id = survey.Id,
                    Description = survey.Description,
                    // Các trường khác của Survey bạn có thể thêm ở đây
                });
            }

            return Task.FromResult(response);
        }
    }
}
