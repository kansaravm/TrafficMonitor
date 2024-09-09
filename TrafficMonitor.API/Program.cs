
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using TrafficMonitor.BusinessLayer.Services;
using TrafficMonitor.Common;
using TrafficMonitoring.BusinessLayer.Services;
using System.Reflection;
using TrafficMonitor.Common.Models.SeedWork;
using TrafficMonitor.Infrastructure.Services;
using TrafficMonitor.Infrastructure.Abstractions;
using TrafficMonitor.Common.Extensions;
using TrafficMonitor.Infrastructure.OptionClass;
using MassTransit;
using TrafficMonitor.Infrastructure.Abstractions.EventBus;
using TrafficMonitor.API.Consumers;


namespace TrafficMonitor.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
         
           
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; 
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // Convert enums to strings
            }); 

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

        });

            builder.Services.AddDbContext<TrafficMonitorDataContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.Configure<MessageBrokerSettings>(builder.Configuration.GetSection("MessageBroker"));
            builder.Services.AddSingleton(o=>o.GetRequiredService<MessageBrokerSettings>());
            
            builder.Services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.AddConsumer<EagleBotCreatedConsumer>();
                busConfigurator.AddConsumer<TrafficStatusConsumer>();
                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    MessageBrokerSettings settings = context.GetRequiredService<MessageBrokerSettings>();
                    configurator.Host(new Uri(settings.Host), h =>
                    {
                        h.Username(settings.UserName);
                        h.Password(settings.Password);
                    });
                    configurator.ConfigureEndpoints(context);
                });
            });
            builder.Services.AddTransient<IEventBus,EventBus>();

            builder.Services.AddAutoMapper(typeof(Program));


            // Add services to the container.
            builder.Services.AddScoped<ITrafficDataService, TrafficDataService>();
            builder.Services.AddSingleton<IClock,SystemClock>();
            builder.Services.AddSingleton<ICacheService, CacheService>();
            builder.Services.AddDistributedMemoryCache();         
          
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.ApplyMigrations();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
