using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Psychological.GrpcService.Protos;
using System;
using Empty = Psychological.GrpcService.Protos.Empty;

namespace Psychological.GrpcClient.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(" Welcome to gRPC Client!");

            using var channel = GrpcChannel.ForAddress("https://localhost:7270");
            var client = new SurveyService.SurveyServiceClient(channel);

            while (true)
            {
                Console.WriteLine("\n Chọn chức năng:");
                Console.WriteLine("1️ Get All Surveys");
                Console.WriteLine("2️ Get Survey By ID");
                Console.WriteLine("3️ Add New Survey");
                Console.WriteLine("4️ Update Survey");
                Console.WriteLine("5️ Delete Survey");
                Console.WriteLine("0️ Exit");
                Console.Write(" Nhập lựa chọn: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GetAllSurveys(client);
                        break;
                    case "2":
                        GetSurveyById(client);
                        break;
                    case "3":
                        AddSurvey(client);
                        break;
                    case "4":
                        EditSurvey(client);
                        break;
                    case "5":
                        DeleteSurvey(client);
                        break;
                    case "0":
                        Console.WriteLine("Exit...");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
                        break;
                }
            }
        }

        // 🟢 Lấy tất cả surveys
        static void GetAllSurveys(SurveyService.SurveyServiceClient client)
        {
            Console.WriteLine("\nDanh sách Surveys:");
            var response = client.GetAll(new Empty());
            if (response.Surveys.Count > 0)
            {
                foreach (var survey in response.Surveys)
                {
                    Console.WriteLine($" {survey.Id} |  {survey.Description} |  Điểm TB: {survey.PointAverage} |  Create At: {survey.CreateAt} |  Update At: {survey.UpdateAt}");
                }
            }
            else
            {
                Console.WriteLine(" Không có survey nào.");
            }
        }

        // 🔵 Lấy survey theo ID
        static void GetSurveyById(SurveyService.SurveyServiceClient client)
        {
            Console.Write("\n Nhập ID Survey: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var response = client.GetById(new SurveyIdRequest { Id = id });
                Console.WriteLine($" {response.Id} |  {response.Description} |  Điểm TB: {response.PointAverage} |  Create At: {response.CreateAt} |  Update At: {response.UpdateAt}");
            }
            else
            {
                Console.WriteLine(" ID không hợp lệ!");
            }
        }

        static void AddSurvey(SurveyService.SurveyServiceClient client)
        {
            try
            {
                Console.Write("\n Nhập ID Survey (Không tự tăng): ");
                int id = int.Parse(Console.ReadLine());

                Console.Write(" Nhập mô tả: ");
                string description = Console.ReadLine();

                Console.Write(" Nhập Category ID: ");
                int? categoryId = int.TryParse(Console.ReadLine(), out var tempCategoryId) ? tempCategoryId : (int?)null;

                Console.Write(" Nhập PointAverage: ");
                double? pointAverage = double.TryParse(Console.ReadLine(), out var tempPointAverage) ? tempPointAverage : (double?)null;

                Console.Write(" Nhập Number: ");
                int? number = int.TryParse(Console.ReadLine(), out var tempNumber) ? tempNumber : (int?)null;

                Console.Write(" Nhập VeryGood: ");
                int? veryGood = int.TryParse(Console.ReadLine(), out var tempVeryGood) ? tempVeryGood : (int?)null;

                Console.Write(" Nhập Good: ");
                int? good = int.TryParse(Console.ReadLine(), out var tempGood) ? tempGood : (int?)null;

                Console.Write(" Nhập Medium: ");
                int? medium = int.TryParse(Console.ReadLine(), out var tempMedium) ? tempMedium : (int?)null;

                Console.Write(" Nhập Bad: ");
                int? bad = int.TryParse(Console.ReadLine(), out var tempBad) ? tempBad : (int?)null;

                Console.Write(" Nhập VeryBad: ");
                int? veryBad = int.TryParse(Console.ReadLine(), out var tempVeryBad) ? tempVeryBad : (int?)null;

                var newSurvey = new Survey
                {
                    Id = id,
                    Description = description,
                    CategoryId = categoryId ?? 0,
                    CreateAt = Timestamp.FromDateTime(DateTime.UtcNow),  
                    UpdateAt = Timestamp.FromDateTime(DateTime.UtcNow), 
                    CreateBy = 1001,
                    PointAverage = (float)(pointAverage ?? 0),
                    Number = number ?? 0,
                    VeryGood = veryGood ?? 0,
                    Good = good ?? 0,
                    Medium = medium ?? 0,
                    Bad = bad ?? 0,
                    VeryBad = veryBad ?? 0
                };

                var response = client.Add(newSurvey);
                Console.WriteLine($" {response.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }


        static void EditSurvey(SurveyService.SurveyServiceClient client)
        {
            try
            {
                Console.Write("\n Nhập ID Survey cần cập nhật: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write(" Nhập mô tả mới: ");
                string description = Console.ReadLine();

                Console.Write(" Nhập Category ID mới: ");
                int categoryId = int.Parse(Console.ReadLine());

                // Cập nhật các giá trị nullable
                Console.Write(" Nhập PointAverage mới (null nếu không cập nhật): ");
                double? pointAverage = double.TryParse(Console.ReadLine(), out var tempPointAverage) ? tempPointAverage : (double?)null;

                Console.Write(" Nhập Number mới (null nếu không cập nhật): ");
                int? number = int.TryParse(Console.ReadLine(), out var tempNumber) ? tempNumber : (int?)null;

                Console.Write(" Nhập VeryGood mới (null nếu không cập nhật): ");
                int? veryGood = int.TryParse(Console.ReadLine(), out var tempVeryGood) ? tempVeryGood : (int?)null;

                Console.Write(" Nhập Good mới (null nếu không cập nhật): ");
                int? good = int.TryParse(Console.ReadLine(), out var tempGood) ? tempGood : (int?)null;

                Console.Write(" Nhập Medium mới (null nếu không cập nhật): ");
                int? medium = int.TryParse(Console.ReadLine(), out var tempMedium) ? tempMedium : (int?)null;

                Console.Write(" Nhập Bad mới (null nếu không cập nhật): ");
                int? bad = int.TryParse(Console.ReadLine(), out var tempBad) ? tempBad : (int?)null;

                Console.Write(" Nhập VeryBad mới (null nếu không cập nhật): ");
                int? veryBad = int.TryParse(Console.ReadLine(), out var tempVeryBad) ? tempVeryBad : (int?)null;

                // Tạo đối tượng Survey mới cho việc cập nhật
                var updatedSurvey = new Survey
                {
                    Id = id,
                    Description = description,
                    CategoryId = categoryId,
                    CreateAt = Timestamp.FromDateTime(DateTime.UtcNow),
                    UpdateAt = Timestamp.FromDateTime(DateTime.UtcNow),
                    CreateBy = 1001,
                    PointAverage = (float)(pointAverage ?? 0),
                    Number = number ?? 0,
                    VeryGood = veryGood ?? 0,
                    Good = good ?? 0,
                    Medium = medium ?? 0,
                    Bad = bad ?? 0,
                    VeryBad = veryBad ?? 0
                };

                var response = client.Edit(updatedSurvey);
                Console.WriteLine($" {response.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }


        // 🔴 Xóa survey
        static void DeleteSurvey(SurveyService.SurveyServiceClient client)
        {
            Console.Write("\n Nhập ID Survey cần xóa: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var response = client.DeleteById(new SurveyIdRequest { Id = id });
                Console.WriteLine($" {response.Message}");
            }
            else
            {
                Console.WriteLine(" ID không hợp lệ!");
            }
        }
    }
}
