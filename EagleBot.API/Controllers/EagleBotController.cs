using AutoMapper;
using EagleBot.API.Dtos;
using EagleBot.API.Services;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;


namespace EagleBot.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EagleBotController : ControllerBase
    {
       
        private readonly IEagleBotService _botService;
        private readonly IMapper _mapper;

        public EagleBotController( IEagleBotService botService, IMapper mapper)
        {
            
            _botService = botService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a EagleBot record
        /// </summary>
        /// <param name="request">CreateEagleBotRequest</param>
        /// <returns></returns>
        /// <response code="400">Bad request</response>
        /// <response code="500">Unknown Error</response>
        /// <response code="201">Created</response>
        /// <returns>Returns 201 Created</returns>
        [HttpPost]
        [OpenApiOperation("create-eagle-bot")]
        
        public async Task<IActionResult> CreateEagleBot([FromBody] CreateEagleBotRequest request)
        {
            await _botService.CreateEagleBot(_mapper.Map<Models.EagleBot>(request));
            return Created(string.Empty, null);
        }
      
    }
}
