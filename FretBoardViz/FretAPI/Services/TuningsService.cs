namespace FretAPI.Services
{
    public class TuningsService
    {
        private readonly ILogger<TuningService> _logger;

        public TuningsService(ILogger<TuningService> logger)
        {
            _logger = logger;
        }
    }
}
