
using GraphQL.Server;
using PSPsychological.GraphQL.APIService.GraphQL.GraphQLSchema;
using Psychological.Service;

namespace PSPsychological.GraphQL.APIService
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

            builder.Services.AddScoped<ISurveyService, SurveyService>();
            builder.Services.AddScoped<ISurveyCategoryService, SurveyCategoryService>();
            builder.Services.AddScoped<SurveyUserAccountService>();

            builder.Services.AddScoped<AppSchema>();
            builder.Services.AddGraphQL()
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader()
                .AddSystemTextJson();




            builder.Services.AddControllers()
               .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        

        var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL<AppSchema>();
            });
            app.UseGraphQLPlayground("/ui/playground");

            app.Run();
        }
    }
}
