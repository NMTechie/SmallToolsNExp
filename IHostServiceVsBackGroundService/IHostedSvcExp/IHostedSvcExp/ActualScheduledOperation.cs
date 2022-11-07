using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace IHostedSvcExp
{
    /*
     * In parallence of the OBBTimeseriesConsumerJobScheduler
     */
    public class ActualScheduledOperation
    {
        private readonly ILogger _logger;
        public ActualScheduledOperation(EventHubConsumerHelper _evtHubHelper)
        {

        }
    }
}
