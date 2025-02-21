using Grpc.Net.Client;
using Psychological.GrpcClient.ConsoleApp;
using Psychological.GrpcService.Protos;

namespace Psychological.GrpcClient.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to gRPC Client!");

            using var channel = GrpcChannel.ForAddress("https://localhost:7270");
            var client = new SurveyService.SurveyServiceClient(channel);

            Console.WriteLine("Get All Survey");
            var surveys = client.GetAll(new Empty());
            if (surveys != null && surveys.Surveys.Count > 0)
            {
                foreach (var survey in surveys.Surveys)
                {
                    Console.WriteLine(string.Format("{0} - {1}", survey.Id, survey.Description));
                }
            }
            else
            {
                Console.WriteLine("No survey found");
            }
            Console.WriteLine("\r\nRPCClient.GetById{Id={1}):");
            var sủveyById = client.GetById(new SurveyIdRequest { Id = 1 });
            Console.WriteLine(string.Format("{0} - {1}", sủveyById.Id, sủveyById.Description));



        }
    }
}
