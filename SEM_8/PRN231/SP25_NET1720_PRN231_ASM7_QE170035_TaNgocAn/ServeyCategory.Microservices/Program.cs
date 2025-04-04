
using MassTransit;
using ServeyCategory.Microservices.Consumer;

namespace ServeyCategory.Microservices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });

            //RabbitMQ-Consumer
            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<SurveyConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    // Configure the receive endpoint
                    cfg.ReceiveEndpoint("surveyQueue", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));
                        ep.ConfigureConsumer<SurveyConsumer>(context);
                    });
                });
            });

            // Add the bus to the service collection
            builder.Services.AddScoped<IPublishEndpoint>(provider => provider.GetRequiredService<IBus>());
            builder.Services.AddScoped<ISendEndpointProvider>(provider => provider.GetRequiredService<IBus>());
            builder.Services.AddScoped<IBus>(provider => provider.GetRequiredService<IBusControl>());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.Run();

        }
    }
}
