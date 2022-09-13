using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IHostedSvcExp
{
    public class MyHostedService : IHostedService
    {
        private readonly ILogger<MyHostedService> logger;
        private readonly MyProcessingUnit _procUnit;

        // inject a logger
        public MyHostedService(ILogger<MyHostedService> logger,MyProcessingUnit procUnit)
        {
            this.logger = logger;
            _procUnit = procUnit;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Hosted service starting");

            return Task.Factory.StartNew(async () =>
            {
                // loop until a cancalation is requested
                while (!cancellationToken.IsCancellationRequested)
                {
                    logger.LogInformation("Hosted service executing - {0}", DateTime.Now);
                    try
                    {
                        //var val = await _procUnit.DoProcessAsync(DateTime.Now);
                        var val = _procUnit.DoProcess(DateTime.Now);
                        // wait for 3 seconds
                        /*
                         * This Wait will add up to the processing time required by the DoProcess Method
                         * means, if DoProcess require 1 sec to complete that means 
                         * the occurence will hapeen in each 3+1 = 4 secs
                         */
                        await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);
                    }
                    catch (OperationCanceledException) { }
                }
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Hosted service stopping");
            return Task.CompletedTask;
        }
    }
}
