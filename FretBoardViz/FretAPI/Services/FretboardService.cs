namespace FretAPI.Services
{
    public class FretboardService
    {
        private readonly ILogger<TuningService> _logger;

        public FretboardService(ILogger<TuningService> logger)
        {
            _logger = logger;
        }


    }
}
