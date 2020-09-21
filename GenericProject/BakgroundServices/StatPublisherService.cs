using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace GenericProject.BakgroundServices
{
    public class StatPublisherService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}