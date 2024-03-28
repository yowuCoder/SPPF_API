using Microsoft.EntityFrameworkCore;
using SPPF_API.Models.COTIOT;
using System.Net.NetworkInformation;

namespace SPPF_API.Background
{
    public class ConnectionState:BackgroundService
    {
        private readonly ILogger<ConnectionState> _logger;
        private readonly IServiceProvider _services;
        private readonly CotiotContext _context;
        

        public ConnectionState(ILogger<ConnectionState> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;
            var scope = _services.CreateScope();
            _context = scope.ServiceProvider.GetRequiredService<CotiotContext>();
            //     _context = context;
            //CotiotContext context
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                PingIpTest();
                await Task.Delay(10000, stoppingToken);
            }
        }
   
       private async void PingIpTest()
        {
            Ping myPing = new Ping();
            var connectionStatuses = await  _context.ConnectionStatuses.ToListAsync();
            connectionStatuses.ForEach(connectionStatus =>
            {
                PingReply reply = myPing.Send(connectionStatus.Ip, 1000);
                if (reply.Status == IPStatus.Success)
                {
                    connectionStatus.Status = true;
                    connectionStatus.UpdatedAt = DateTime.Now;
                }
                else
                {
                    connectionStatus.Status = false;
                    connectionStatus.UpdatedAt = DateTime.Now;
                }
            });

            await _context.SaveChangesAsync();
        }
    }
}
