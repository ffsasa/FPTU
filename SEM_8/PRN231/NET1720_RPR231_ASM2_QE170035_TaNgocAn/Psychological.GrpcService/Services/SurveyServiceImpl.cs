using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Psychological.GrpcService.Protos;
using Psychological.Service;
using System.Text.Json.Serialization;
using System.Text.Json;
using Psychological.Repository.Models;
using Psychological.Repository;

namespace Psychological.GrpcService.Services
{
    public class SurveyServiceImpl : Protos.SurveyService.SurveyServiceBase
    {
        private readonly ISurveyService _surveyService;
        private readonly ILogger<SurveyServiceImpl> _logger;

        public SurveyServiceImpl(ISurveyService surveyService, ILogger<SurveyServiceImpl> logger)
        {
            _surveyService = surveyService;
            _logger = logger;
        }

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<SurveyList> GetAll(Protos.Empty request, ServerCallContext context)
        {
            // Đợi phương thức GetAll() trả về dữ liệu thực tế (List<Survey>)
            var surveys = await _surveyService.GetAll();

            // Tạo danh sách Survey phù hợp
            var surveyList = new SurveyList();

            foreach (var survey in surveys)
            {
                surveyList.Surveys.Add(new Protos.Survey
                {
                    Id = survey.Id,
                    CategoryId = survey.CategoryId ?? 0,
                    Description = survey.Description,
                    Number = survey.Number ?? 0,
                    PointAverage = (float)(survey.PointAverage ?? 0),
                    VeryGood = survey.Verygood ?? 0,
                    Good = survey.Good ?? 0,
                    Medium = survey.Medium ?? 0,
                    Bad = survey.Bad ?? 0,
                    VeryBad = survey.VeryBad ?? 0,
                    CreateBy = survey.CreateBy ?? 1,
                    CreateAt = Timestamp.FromDateTime((survey.CreateAt ?? DateTime.UtcNow).ToUniversalTime()),
                    UpdateAt = Timestamp.FromDateTime((survey.UpdateAt ?? DateTime.UtcNow).ToUniversalTime())

                });
            }

            return surveyList;
        }

        public override async Task<Protos.Survey> GetById(SurveyIdRequest request, ServerCallContext context)
        {
            var survey = await _surveyService.GetById(request.Id);
            if (survey == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Survey not found"));

            // Chuyển đổi từ model sang Protos.Survey
            var protoSurvey = new Protos.Survey
            {
                Id = survey.Id,
                CategoryId = survey.CategoryId ?? 0,
                Description = survey.Description,
                Number = survey.Number ?? 0,
                PointAverage = (float)(survey.PointAverage ?? 0),
                VeryGood = survey.Verygood ?? 0,
                Good = survey.Good ?? 0,
                Medium = survey.Medium ?? 0,
                Bad = survey.Bad ?? 0,
                VeryBad = survey.VeryBad ?? 0,
                CreateBy = survey.CreateBy ?? 1,
                CreateAt = Timestamp.FromDateTime((survey.CreateAt ?? DateTime.UtcNow).ToUniversalTime()),
                UpdateAt = Timestamp.FromDateTime((survey.UpdateAt ?? DateTime.UtcNow).ToUniversalTime())
            };

            return protoSurvey;
        }


        public override async Task<ActionResult> Add(Protos.Survey request, ServerCallContext context)
        {
            try
            {
                // Chuyển đổi từ Protos.Survey sang Repository.Models.Survey
                var model = new Repository.Models.Survey
                {
                    Id = request.Id,
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    Number = request.Number,
                    PointAverage = request.PointAverage,
                    Verygood = request.VeryGood,
                    Good = request.Good,
                    Medium = request.Medium,
                    Bad = request.Bad,
                    VeryBad = request.VeryBad,
                    CreateBy = request.CreateBy,
                    CreateAt = request.CreateAt.ToDateTime().ToUniversalTime(),
                    UpdateAt = request.UpdateAt.ToDateTime().ToUniversalTime()
                };

                var result = await _surveyService.Create(model);

                if (result > 0)
                    return new ActionResult { Status = 1, Message = "Add Success" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }

            return new ActionResult { Status = -1, Message = "Add Fail" };
        }


        public override async Task<ActionResult> Edit(Protos.Survey request, ServerCallContext context)
        {
            try
            {
                // Chuyển đổi từ Protos.Survey sang Repository.Models.Survey
                var model = new Repository.Models.Survey
                {
                    Id = request.Id,
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    Number = request.Number,
                    PointAverage = request.PointAverage,
                    Verygood = request.VeryGood,
                    Good = request.Good,
                    Medium = request.Medium,
                    Bad = request.Bad,
                    VeryBad = request.VeryBad,
                    CreateBy = request.CreateBy,
                    CreateAt = request.CreateAt.ToDateTime().ToUniversalTime(),
                    UpdateAt = request.UpdateAt.ToDateTime().ToUniversalTime()
                };


                //var json = JsonSerializer.Serialize(request, _jsonOptions);
                //var model = JsonSerializer.Deserialize<Repository.Models.Survey>(json, _jsonOptions);

                var result = await _surveyService.Update(model);
                if (result > 0)
                    return new ActionResult { Status = 1, Message = "Edit Success" };
            }
            catch (Exception ex)
            {
                return new ActionResult { Status = -1, Message = $"Edit Fail: {ex.Message}" };
            }

            return new ActionResult { Status = -1, Message = "Edit Fail" };
        }

        public override async Task<ActionResult> DeleteById(SurveyIdRequest request, ServerCallContext context)
        {
            try
            {
                var result = await _surveyService.Delete(request.Id);
                if (result)
                    return new ActionResult { Status = 1, Message = "Delete Success" };
            }
            catch (Exception ex)
            {
                return new ActionResult { Status = -1, Message = $"Delete Fail: {ex.Message}" };
            }

            return new ActionResult { Status = -1, Message = "Delete Fail" };
        }

        // Async methods can just call their sync counterparts (if logic is same)
        public override Task<SurveyList> GetAllAsync(Protos.Empty request, ServerCallContext context) => GetAll(request, context);
        public override Task<Protos.Survey> GetByIdAsync(SurveyIdRequest request, ServerCallContext context) => GetById(request, context);
        public override Task<ActionResult> AddAsync(Protos.Survey request, ServerCallContext context) => Add(request, context);
        public override Task<ActionResult> EditAsync(Protos.Survey request, ServerCallContext context) => Edit(request, context);
        public override Task<ActionResult> DeleteByIdAsync(SurveyIdRequest request, ServerCallContext context) => DeleteById(request, context);
    }
}
