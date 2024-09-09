using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TrafficMonitor.API.Controllers;
using TrafficMonitor.Common.Models;
using TrafficMonitorAPI.Dtos;
using TrafficMonitoring.BusinessLayer.Services;

namespace TrafficMonitor.UnitTests.Controllers
{
    public class TrafficMonitorControllerTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ITrafficDataService> _trafficService;
        private readonly Mock<IEagleBotService> _botService;
        private readonly TrafficMonitorController _controller;

        public TrafficMonitorControllerTests()
        {
            _botService =new Mock<IEagleBotService> ();
            _mapper = new Mock<IMapper> ();
            _trafficService = new Mock<ITrafficDataService> ();
            _controller= new TrafficMonitorController(_trafficService.Object ,_botService.Object,_mapper.Object);
        }      

        [Fact]
        public async Task CreateShouldReturnNotFoundWhenBotNotFound()
        {
            var request= new TrafficDataRequestDto() { EagleBotId = Guid.NewGuid() };
            _botService.Setup(s => s.GetEagleBot(request.EagleBotId)).ReturnsAsync((EagleBot?)null);

            var result = await _controller.CreateTrafficData(request);

            var actionResult = Assert.IsType<NotFoundObjectResult>(result);

            Assert.Equal("No Eagle Bot Found for the given Id.",actionResult.Value);
        }

        [Fact]
        public async Task CreateShouldCallCreateDataWhenBotIsFound()
        {
            var request = new TrafficDataRequestDto() { EagleBotId = Guid.NewGuid() };
            var bot = new EagleBot { Id = request.EagleBotId };
            var response= 
            _botService.Setup(s => s.GetEagleBot(request.EagleBotId)).ReturnsAsync(bot);
           
            var result = await _controller.CreateTrafficData(request);

            var actionResult = Assert.IsType<CreatedResult>(result);

            Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
        }
    }
}
