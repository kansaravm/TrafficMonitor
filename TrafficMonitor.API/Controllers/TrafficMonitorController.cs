using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Net;
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

        /// <summary>
        /// Create a TrafficData record
        /// </summary>
        /// <param name="request">TrafficDataRequestDto</param>
        /// <returns></returns>
        /// <response code="400">Bad request</response>
        /// <response code="500">Unknown Error</response>
        /// <response code="201">Created</response>
        /// <returns>Returns 201 Created</returns>
        [HttpPost]
        [OpenApiOperation("create-traffic-data")]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(string), Description = "No Eagle Bot Found for the given Id.")]
       
        public async Task<IActionResult> CreateTrafficData([FromBody] TrafficDataRequestDto request)
        {
            var bot = await _botService.GetEagleBot(request.EagleBotId);
            if (bot == null) return NotFound("No Eagle Bot Found for the given Id.");                   
          
            await _trafficService.CreateTrafficData(_mapper.Map<TrafficData>(request));
            return Created(string.Empty,null);
        }

        /// <summary>
        /// GetPagedTrafficData
        /// </summary>
        /// <param name="request">GetTrafficFilterDto</param>
        /// <returns>TrafficDataList</returns>
        [HttpGet]
        public async Task<ActionResult<TrafficDataList>> GetAllTrafficData([FromQuery]GetTrafficFilterDto request)
        {
            var trafficData = await _trafficService.GetTrafficData(_mapper.Map<GetTrafficFilter>(request));            
            var response = _mapper.Map<TrafficDataList>(trafficData);
            return Ok(response);

        }
    }
}
