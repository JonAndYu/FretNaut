namespace FretAPI.Services
{
    public class UserService
    {
        private readonly ILogger<TuningService> _logger;

        public UserService(ILogger<TuningService> logger)
        {
            _logger = logger;
        }
    }
}
