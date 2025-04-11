using MonitoringServiceAlvaCleanCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringServiceAlvaCleanCRM.Repository.Interfaces
{
    internal interface IConsumerRepository
    {
        public Task ConsumeMessagesFromQueue(CancellationToken cancellationToken = default);

        public Task PrintMessageFromQueue();
    }
}
