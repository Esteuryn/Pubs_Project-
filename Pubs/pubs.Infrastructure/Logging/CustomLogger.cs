using Microsoft.Extensions.Logging;
using pubs.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pubs.Infrastructure.Logging
{
    public class CustomLogger : ICustomlogger
    {
        private readonly ILogger _logger;
        public CustomLogger(ILogger<CustomLogger> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message) 
        { 
            _logger.LogInformation(message);
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }
    }
}
