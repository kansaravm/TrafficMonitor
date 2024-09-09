using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TrafficMonitor.API.Controllers;
using TrafficMonitor.Common.Models;
using TrafficMonitorAPI.Dtos;
using TrafficMonitoring.BusinessLayer.Services;
using X.PagedList;
using FizzWare.NBuilder;
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

        [Fact]
        public async Task GetAllTrafficData_ShouldReturnOk_WhenDataIsReturned()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var guid3 = Guid.NewGuid();
            
            var responseDtoList = Builder<TrafficDataResponse>.CreateListOfSize(40)
                .TheFirst(10)
                .With(x => x.EagleBotId = guid1)
                .TheNext(6).With(x => x.EagleBotId = guid2)
                .TheRest().With(x => x.EagleBotId = guid3)
                .Build();

            
            var response = Builder<TrafficDataList>.CreateNew()
               .With(x => x.Paging = Builder<Paging>.CreateNew().Build())
           .With(x => x.TrafficDataResponses = responseDtoList.ToList())
           .Build();
            
            
            var trafficDataList = Builder<TrafficData>.CreateListOfSize(40)
               .TheFirst(10)
               .With(x => x.EagleBotId = guid1)
               .TheNext(6).With(x => x.EagleBotId = guid2)
               .TheRest().With(x => x.EagleBotId = guid3)
               .Build();

            var pagedList = new StaticPagedList<TrafficData>(trafficDataList, pageNumber: 1, pageSize: 10, totalItemCount: 40);


            var request = new GetTrafficFilterDto { /* Set properties */ };
            var trafficFilter = new GetTrafficFilter { /* Set properties */ };
            var trafficData = new TrafficData { /* Set properties */ };


            _mapper.Setup(m => m.Map<GetTrafficFilter>(request)).Returns(trafficFilter);
            _trafficService.Setup(s => s.GetTrafficData(trafficFilter)).ReturnsAsync(pagedList);
            _mapper.Setup(m => m.Map<TrafficDataList>(pagedList)).Returns(response);

            
            var result = await _controller.GetAllTrafficData(request);

           
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var listResponse = Assert.IsType<TrafficDataList>(okResult.Value);        
          
        }
    }
}

