using Grpc.Net.Client;
using Psychological.GrpcService.Protos;
using System;

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
                    Console.WriteLine($" {survey.Id} |  {survey.Description} |  Điểm TB: {survey.PointAverage}");
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
                Console.WriteLine($" {response.Id} |  {response.Description} |  Điểm TB: {response.PointAverage}");
            }
            else
            {
                Console.WriteLine(" ID không hợp lệ!");
            }
        }

        // 🟡 Thêm survey mới
        static void AddSurvey(SurveyService.SurveyServiceClient client)
        {
            Console.Write("\n Nhập ID Survey (Không tự tăng): ");
            int id = int.Parse(Console.ReadLine());

            Console.Write(" Nhập mô tả: ");
            string description = Console.ReadLine();

            Console.Write(" Nhập Category ID: ");
            int categoryId = int.Parse(Console.ReadLine());

            Console.Write(" Nhập PointAverage ID: ");
            int pointAverage = int.Parse(Console.ReadLine());

            var newSurvey = new Survey
            {
                Id = id,
                Description = description,
                CategoryId = categoryId,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                UpdateAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                CreateBy = 1,
                PointAverage = pointAverage,
                Number = 0,
                VeryGood = 0,
                Good = 0,
                Medium = 0,
                Bad = 0,
                VeryBad = 0
            };

            var response = client.Add(newSurvey);
            Console.WriteLine($" {response.Message}");
        }

        // 🟠 Cập nhật survey
        static void EditSurvey(SurveyService.SurveyServiceClient client)
        {
            Console.Write("\n Nhập ID Survey cần cập nhật: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write(" Nhập mô tả mới: ");
            string description = Console.ReadLine();

            Console.Write(" Nhập Category ID mới: ");
            int categoryId = int.Parse(Console.ReadLine());

            var updatedSurvey = new Survey
            {
                Id = id,
                Description = description,
                CategoryId = categoryId,
                UpdateAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            var response = client.Edit(updatedSurvey);
            Console.WriteLine($" {response.Message}");
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
