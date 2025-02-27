
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using Psychological.Repository;
using Psychological.Repository.Models;
using Psychological.Service;
using System.Text;
using System.Text.Json.Serialization;

namespace Psychological_APIServices
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

			builder.Services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
				options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
			});

			////JWT Config
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	            .AddJwtBearer(options =>
	            {
		            options.TokenValidationParameters = new TokenValidationParameters
		            {
			            ValidateIssuer = true,
			            ValidateAudience = true,
			            ValidateLifetime = true,
			            ValidateIssuerSigningKey = true,
			            ValidIssuer = builder.Configuration["Jwt:Issuer"],
			            ValidAudience = builder.Configuration["Jwt:Audience"],
			            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
		            };
	            });

			builder.Services.AddSwaggerGen(option =>
			{
				////JWT Config
				option.DescribeAllParametersInCamelCase();
				option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please enter a valid token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "Bearer"
				});
				option.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type=ReferenceType.SecurityScheme,
								Id="Bearer"
							}
						},
						new string[]{}
					}
				});
			});

            static IEdmModel GetEdmModel()
            {
                var odataBuilder = new ODataConventionModelBuilder();
                odataBuilder.EntitySet<ServeyCategory>("ServeyCategories"); // ENTITY
                odataBuilder.EntitySet<Survey>("Survey"); // ENTITY
                return odataBuilder.GetEdmModel();
            }
            builder.Services.AddControllers().AddOData(options =>
            {
                options.Select().Filter().OrderBy().Expand().SetMaxTop(null).Count();
                options.AddRouteComponents("odata", GetEdmModel());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

			app.Run();
        }
    }
}
