namespace FretAPI.Services
{
    public class UsersService
    {
        private readonly ILogger<TuningService> _logger;

        public UsersService(ILogger<TuningService> logger)
        {
            _logger = logger;
        }
    }
}
