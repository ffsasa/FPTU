using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Psychological.GrpcService.Models;
using Psychological.GrpcService.Protos;

namespace Psychological.GrpcService.Services
{
    public class SurveyServiceImpl : SurveyService.SurveyServiceBase
    {
        private readonly ILogger<SurveyServiceImpl> _logger;
        private static List<Protos.Survey> _surveys = new List<Protos.Survey>
        {
            new Protos.Survey {
            Id = 1,
            CategoryId = 1,
            Description = "Kiem tra 1",
            Number = 1,
            PointAverage = 1,
            VeryGood = 1,
            Good = 1,
            Medium = 1,
            Bad = 1,
            VeryBad = 1,
            CreateBy = 1,
            CreateAt = DateTime.Now.ToString(),
            UpdateAt = DateTime.Now.ToString()
            },
            new Protos.Survey() {
            Id = 2,
            CategoryId = 1,
            Description = "Kiem tra 2",
            Number = 1,
            PointAverage = 1,
            VeryGood = 1,
            Good = 1,
            Medium = 1,
            Bad = 1,
            VeryBad = 1,
            CreateBy = 1,
            CreateAt = DateTime.Now.ToString(),
            UpdateAt = DateTime.Now.ToString()
            }
        };
            

        public SurveyServiceImpl(ILogger<SurveyServiceImpl> logger)
        {
            _logger = logger;
        }

        public override async Task<SurveyList> GetAll(Protos.Empty request, ServerCallContext context)
        {
            var response = new SurveyList();
            response.Surveys.AddRange(_surveys); 

            return await Task.FromResult(response); 
        }

        public override Task<Protos.Survey> GetById(SurveyIdRequest request, ServerCallContext context)
        {
            var survey = _surveys.FirstOrDefault(s => s.Id == request.Id);
            if (survey == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Survey not found"));
            }
            return Task.FromResult(survey);
        }
    }
}
