using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GenericProject.Logging;

namespace GenericProject.BakgroundServices
{
    public class StatPublisherService : BackgroundService
    {
        private readonly ILogger<StatPublisherService> _logger;
        
        public StatPublisherService(
            ILogger<StatPublisherService> logger
        ){
            _logger= logger;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Started stat publisher service");

            try
            {
                _logger.LogInformation("Publishing data");
            }
            catch (OperationCanceledException)
            {
                _logger.OperationCancelledExceptionOccurred();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Unhandled Exception in StatPublisherService");
            }
        }
    }
}