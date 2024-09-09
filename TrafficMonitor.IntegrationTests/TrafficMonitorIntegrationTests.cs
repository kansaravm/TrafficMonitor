using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using TrafficMonitor.API;
using TrafficMonitorAPI.Dtos;
using FizzWare.NBuilder;
using TrafficMonitor.Common;
using TrafficMonitor.Common.Models;
using Microsoft.Extensions.DependencyInjection;

namespace TrafficMonitor.IntegrationTests
{
    public class TrafficMonitorIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>    {

        private readonly WebApplicationFactory<Program> _factory;       

        public TrafficMonitorIntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;          
        }

        [Fact]
        public async Task CreateData_ReturnsCreatedResult_WhenRequestIsValid()
        {
            // Arrange
            var client = _factory.CreateClient();
            var newId = Guid.NewGuid();
            var newBot = Builder<EagleBot>.CreateNew().With(e => e.Id = newId).Build();

            using (var scope = _factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TrafficMonitorDataContext>();

                // Arrange: Add test data
                await dbContext.EagleBot.AddAsync(newBot);
                await dbContext.SaveChangesAsync();
            }
          
            var request = Builder<CreateTrafficDataRequest>.CreateNew().With(r=>r.EagleBotId= newId).Build();

            var requestContent = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await client.PostAsync("/TrafficMonitor", requestContent);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);

            // Optionally, verify the response content
            var responseBody = await response.Content.ReadAsStringAsync();
           
            Assert.Equal(responseBody,string.Empty);
           
        }

        
    }
}