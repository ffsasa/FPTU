using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
//using Psychological.GrpcService.Models;
using Psychological.GrpcService.Protos;
using Psychological.Service;
using System.Text.Json.Serialization;
using System.Text.Json;
using Psychological.Repository.Models;

namespace Psychological.GrpcService.Services
{
    public class SurveyServiceImpl : Protos.SurveyService.SurveyServiceBase
    {
        public readonly ISurveyService surveyService;
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

        public override Task<ActionResult> DeleteById(SurveyIdRequest request, ServerCallContext context)
        {
            var item = _surveys.FirstOrDefault(b => b.Id == request.Id);
            if (item != null)
            {
                _surveys.Remove(item);
                return Task.FromResult(new ActionResult() { Status = 1, Message = "Delete success", Data = new SurveyList() { Surveys = { _surveys } } });
            }

            return Task.FromResult(new ActionResult() { Status = -1, Message = "Delete fail" });
        }

        public override Task<ActionResult> Add(Protos.Survey request, ServerCallContext context)
        {
            if (request != null)
            {
                _surveys.Add(request);
                return Task.FromResult(new ActionResult() { Status = 1, Message = "Add success", Data = new SurveyList() { Surveys = { _surveys } } });
            }

            return Task.FromResult(new ActionResult() { Status = -1, Message = "Add fail" });
        }

        public override Task<ActionResult> Edit(Protos.Survey request, ServerCallContext context)
        {
            if (request != null)
            {
                var item = _surveys.FirstOrDefault(b => b.Id == request.Id);
                if (item != null)
                {
                    _surveys.Remove(item);
                    _surveys.Remove(request);

                    return Task.FromResult(new ActionResult() { Status = 1, Message = "Edit success", Data = new SurveyList() { Surveys = { _surveys } } });
                }
            }

            return Task.FromResult(new ActionResult() { Status = -1, Message = "Edit fail" });
        }

        public override async Task<ActionResult> AddAsync(Protos.Survey request, ServerCallContext context)
        {
            try
            {
                if (request != null)
                {
                    var opt = new JsonSerializerOptions()
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles,
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                    };

                    var surveyString = JsonSerializer.Serialize(request, opt);
                    var item = JsonSerializer.Deserialize<Repository.Models.Survey>(surveyString, opt);

                    var result = await surveyService.Create(item);

                    if (result > 0)
                    {
                        return await Task.FromResult(new ActionResult() { Status = 1, Message = "Add Success" });
                    }
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ActionResult() { Status = -4, Message = string.Format("Add Fail. (0)", ex.ToString()) });

            }
            return await Task.FromResult(new ActionResult() { Status = -4, Message = "Add Fail" });
        }

        public override async Task<SurveyList> GetAllAsync(Protos.Empty request, ServerCallContext context)
        {
            try
            {
                var result = new SurveyList();
                var surveyList = await surveyService.GetAll();

                    var surveyString = JsonSerializer.Serialize(request, opt);
                    var item = JsonSerializer.Deserialize<Repository.Models.Survey>(surveyString, opt);

                    var result = await surveyService.Create(item);

                    if (result > 0)
                    {
                        return await Task.FromResult(new ActionResult() { Status = 1, Message = "Add Success" });
                    }
                
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ActionResult() { Status = -4, Message = string.Format("Add Fail. (0)", ex.ToString()) });

            }
            return await Task.FromResult(new ActionResult() { Status = -4, Message = "Add Fail" });
        }
    }
}
