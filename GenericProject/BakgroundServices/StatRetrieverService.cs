using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GenericProject.Logging;

namespace GenericProject.BakgroundServices
{
    public class StatRetrieverService : BackgroundService
    {
        private readonly ILogger<StatRetrieverService> _logger;
        
        public StatRetrieverService(
            ILogger<StatRetrieverService> logger
        ){
            _logger= logger;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Started stat rertiever service");

            try
            {
                _logger.LogInformation("Retriving data");
            }
            catch (OperationCanceledException)
            {
                _logger.OperationCancelledExceptionOccurred();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Unhandled Exception in Stat Retriever Service");
            }
        }
    }
}