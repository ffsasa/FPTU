
using API.SoapService;
using Psychological.Service;
using SoapCore;
using System.Text.Json.Serialization;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSoapCore();
            builder.Services.AddScoped<API.SoapService.ISurveyService, API.SoapService.SurveyService>();
            builder.Services.AddScoped<Psychological.Service.ISurveyService, Psychological.Service.SurveyService>();
            builder.Services.AddScoped<Psychological.Service.ISurveyCategoryService, Psychological.Service.SurveyCategoryService>();
            builder.Services.AddControllers().AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSoapEndpoint<API.SoapService.ISurveyService>("/SurveyService.asmx", new SoapEncoderOptions());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
