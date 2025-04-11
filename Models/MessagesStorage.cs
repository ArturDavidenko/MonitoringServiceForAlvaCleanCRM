using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringServiceAlvaCleanCRM.Models
{
    public static class MessagesStorage
    {
        private static readonly List<LogInMessageFromQueue> _messages = new();
        private static readonly HashSet<string> _shownMessageSignatures = new();

        public static void Add(LogInMessageFromQueue message)
        {
            lock (_messages)
            {
                _messages.Add(message);
            }
        }

        public static List<LogInMessageFromQueue> GetNewMessages()
        {
            lock (_messages)
            {
                var newMessages = _messages
                    .Where(m => !_shownMessageSignatures.Contains($"{m.Id}-{m.DateTime.Ticks}"))
                    .ToList();

                foreach (var msg in newMessages)
                    _shownMessageSignatures.Add($"{msg.Id}-{msg.DateTime.Ticks}");

                return newMessages;
            }
        }
    }
}
