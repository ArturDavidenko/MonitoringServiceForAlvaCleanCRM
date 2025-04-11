using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringServiceAlvaCleanCRM.Models
{
    public class LogInMessageFromQueue
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public string PasswordHash { get; set; }

        public string ImageId { get; set; }

        public List<string> Orders { get; set; }

        public DateTime DateTime { get; set; }
    }
}
