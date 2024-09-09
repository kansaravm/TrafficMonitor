
using EagleBot.API.Database;
using AutoMapper;
using MassTransit;
using Common.Events;


namespace EagleBot.API.Services
{
    public class EagleBotService : IEagleBotService
    {
        private readonly DataContext _context;
        public ILogger<EagleBotService> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public EagleBotService(DataContext context, ILogger<EagleBotService> logger, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }       

        public async Task CreateEagleBot(Models.EagleBot bot)
        {
            await _context.EagleBot.AddAsync(bot);
            await _context.SaveChangesAsync();
            
            await _publishEndpoint.Publish(new EagleBotCreatedEvent{
            Id = bot.Id.Value,            
            Name = bot.Name,    
            Status = bot.Status,
            CreatedOn = bot.CreatedOn
        });

        }
    }


}
