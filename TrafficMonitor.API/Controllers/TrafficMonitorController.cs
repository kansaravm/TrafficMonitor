using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrafficMonitor.Common.Models;
using TrafficMonitorAPI.Dtos;
using TrafficMonitoring.BusinessLayer.Services;

namespace TrafficMonitor.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TrafficMonitorController : ControllerBase
    {
        private readonly ITrafficDataService _trafficService;
        private readonly IEagleBotService _botService;
        private readonly IMapper _mapper;

        public TrafficMonitorController(ITrafficDataService trafficService, IEagleBotService botService, IMapper mapper)
        {
            _trafficService = trafficService;
            _botService = botService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrafficData([FromBody] TrafficDataRequest request)
        {
           /* var bot = await _botService.GetEagleBot(request.EagleBotId);
            if (bot == null) return Conflict("No Eagle Bot Found for the given Id.");
                   */
           var mapped = _mapper.Map<TrafficData>(request);
            await _trafficService.CreateTrafficData(mapped);
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<List<TrafficDataResponse>>> GetAllTrafficData()
        {
            var trafficData= await _trafficService.GetTrafficData();
            return Ok(_mapper.Map<List<TrafficDataResponse>>(trafficData));

        }
    }
}
