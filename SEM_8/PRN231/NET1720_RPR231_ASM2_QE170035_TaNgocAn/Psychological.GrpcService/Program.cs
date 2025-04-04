using Psychological.GrpcService.Services;
using Psychological.Service;

namespace Psychological.GrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc();
            builder.Services.AddScoped<SurveyServiceImpl>();
            builder.Services.AddScoped<ISurveyService, SurveyService>();
            builder.Services.AddScoped<ISurveyCategoryService, SurveyCategoryService>();
            builder.Services.AddScoped<SurveyUserAccountService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<SurveyServiceImpl>();  // Đăng ký SurveyServiceImpl
            app.MapGrpcService<GreeterService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}