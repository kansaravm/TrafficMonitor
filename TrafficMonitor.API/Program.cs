
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using TrafficMonitor.BusinessLayer.Services;
using TrafficMonitor.Common;
using TrafficMonitoring.BusinessLayer.Services;
using System.Reflection;
using TrafficMonitor.Common.Models.SeedWork;
using Microsoft.Extensions.Options;

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
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "127.0.0.1:6379";
                options.ConfigurationOptions =

                new StackExchange.Redis.ConfigurationOptions()
                {

                    AbortOnConnectFail = true,
                    EndPoints = { options.Configuration }
                };
            });
            builder.Services.AddAutoMapper(typeof(Program));


            // Add services to the container.
            builder.Services.AddScoped<IEagleBotService, EagleBotService>();
            builder.Services.AddScoped<ITrafficDataService, TrafficDataService>();
            builder.Services.AddSingleton<IClock,SystemClock>();
            //builder.Services.AddTransient<IProductService, ProductService>();

          
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
