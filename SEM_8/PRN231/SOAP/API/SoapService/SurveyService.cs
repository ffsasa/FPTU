using API.SoapModels;
using System.ServiceModel;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.SoapService
{
    [ServiceContract]
    public interface ISurveyService
    {
        [OperationContract]
        Task<List<API.SoapModels.Survey>> GetAll();
        [OperationContract]
        Task<API.SoapModels.Survey> GetById(int id);
        [OperationContract]
        Task<int> Create(API.SoapModels.Survey survey);
        [OperationContract]
        Task<int> Update(API.SoapModels.Survey survey);
        [OperationContract]
        Task<bool> Delete(int id);
        [OperationContract]
        Task<List<API.SoapModels.Survey>> SearchAsync(string Name, int Number, int Verygood);
    }

    public class SurveyService : ISurveyService
    {
        private readonly Psychological.Service.ISurveyService _surveyService;
        private readonly Psychological.Service.ISurveyCategoryService _surveyCategoryService;

        public SurveyService(Psychological.Service.ISurveyService surveyService, Psychological.Service.ISurveyCategoryService surveyCategoryService)
        {
            _surveyService = surveyService;
            _surveyCategoryService = surveyCategoryService;
        }

        // Chuyển đổi từ API.SoapModels.Survey sang Psychological.Repository.Models.Survey
        private Psychological.Repository.Models.Survey ConvertToRepositorySurvey(API.SoapModels.Survey survey)
        {
            return new Psychological.Repository.Models.Survey
            {
                Id = survey.Id,
                CategoryId = survey.CategoryId,
                Description = survey.Description,
                Number = survey.Number,
                PointAverage = survey.PointAverage,
                Verygood = survey.Verygood,
                Good = survey.Good,
                Medium = survey.Medium,
                Bad = survey.Bad,
                VeryBad = survey.VeryBad,
                CreateBy = survey.CreateBy,
                CreateAt = survey.CreateAt,
                UpdateAt = survey.UpdateAt,
                Category = survey.Category != null ? new Psychological.Repository.Models.ServeyCategory
                {
                    // Nếu Category là null, bạn có thể xử lý sao cho phù hợp
                    // (có thể lấy thông tin category từ Service nếu cần thiết)
                    Id = survey.Category.Id,
                    Name = survey.Category.Name
                } : null
            };
        }

        // Chuyển đổi từ Psychological.Repository.Models.Survey sang API.SoapModels.Survey
        private API.SoapModels.Survey ConvertToApiSurvey(Psychological.Repository.Models.Survey survey)
        {
            return new API.SoapModels.Survey
            {
                Id = survey.Id,
                CategoryId = survey.CategoryId ?? 0,  // Gán 0 nếu CategoryId là null
                Description = survey.Description,
                Number = survey.Number ?? 0,  // Gán 0 nếu Number là null
                PointAverage = survey.PointAverage ?? 0,  // Gán 0 nếu PointAverage là null
                Verygood = survey.Verygood ?? 0,  // Gán 0 nếu Verygood là null
                Good = survey.Good ?? 0,  // Gán 0 nếu Good là null
                Medium = survey.Medium ?? 0,  // Gán 0 nếu Medium là null
                Bad = survey.Bad ?? 0,  // Gán 0 nếu Bad là null
                VeryBad = survey.VeryBad ?? 0,  // Gán 0 nếu VeryBad là null
                CreateBy = survey.CreateBy ?? 0,  // Gán 0 nếu CreateBy là null
                CreateAt = survey.CreateAt ?? DateTime.MinValue,  // Gán DateTime.MinValue nếu CreateAt là null
                UpdateAt = survey.UpdateAt ?? DateTime.MinValue,  // Gán DateTime.MinValue nếu UpdateAt là null
                Category = survey.Category != null ? new API.SoapModels.ServeyCategory
                {
                    Id = survey.Category.Id,
                    Name = survey.Category.Name
                } : null
            };
        }


        public async Task<int> Create(API.SoapModels.Survey survey)
        {
            if (survey == null)
            {
                throw new ArgumentNullException(nameof(survey), "Survey cannot be null");
            }

            // Chuyển đổi từ API.SoapModels.Survey sang Psychological.Repository.Models.Survey
            var repositorySurvey = ConvertToRepositorySurvey(survey);

            // Gọi service thực tế để tạo survey
            var createdId = await _surveyService.Create(repositorySurvey);
            return createdId;
        }

        public async Task<int> Update(API.SoapModels.Survey survey)
        {
            if (survey == null)
            {
                throw new ArgumentNullException(nameof(survey), "Survey cannot be null");
            }

            // Chuyển đổi từ API.SoapModels.Survey sang Psychological.Repository.Models.Survey
            var repositorySurvey = ConvertToRepositorySurvey(survey);

            // Gọi service thực tế để cập nhật survey
            var updatedId = await _surveyService.Update(repositorySurvey);
            return updatedId;
        }

        public async Task<bool> Delete(int id)
        {
            // Gọi service thực tế để xóa survey theo id
            var result = await _surveyService.Delete(id);
            return result;
        }

        public async Task<List<API.SoapModels.Survey>> GetAll()
        {
            var items = await _surveyService.GetAll();
            var options = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
            var itemsString = JsonSerializer.Serialize(items, options);
            var result = JsonSerializer.Deserialize<List<API.SoapModels.Survey>>(itemsString, options);
            return result;
        }

        public async Task<API.SoapModels.Survey> GetById(int id)
        {
            var item = await _surveyService.GetById(id);
            var options = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
            var itemString = JsonSerializer.Serialize(item, options);
            var result = JsonSerializer.Deserialize<API.SoapModels.Survey>(itemString, options);
            return result;
        }

        public async Task<List<API.SoapModels.Survey>> SearchAsync(string Name, int Number, int Verygood)
        {
            var items = await _surveyService.SearchAsync(Name, Number, Verygood);
            var options = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
            var itemsString = JsonSerializer.Serialize(items, options);
            var result = JsonSerializer.Deserialize<List<API.SoapModels.Survey>>(itemsString, options);
            return result;
        }
    }
}
