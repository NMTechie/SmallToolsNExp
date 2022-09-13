using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace IHostedSvcExp
{
    public class MyProcessingUnit
    {
        private readonly ILogger<MyProcessingUnit> _logger;
        public MyProcessingUnit(ILogger<MyProcessingUnit> logger)
        {
            _logger = logger;   
        }

        public async Task<bool> DoProcessAsync(DateTime dt)
        {
            _logger.LogInformation($" Processing Log happening --> {dt.ToString()} ");
            await Task.Delay(2000);
            return true;
        }

        public bool DoProcess(DateTime dt)
        {
            _logger.LogInformation($" Processing Log happening --> {dt.ToString()} ");
            Thread.Sleep(1000);
            return true;
        }
    }
}
