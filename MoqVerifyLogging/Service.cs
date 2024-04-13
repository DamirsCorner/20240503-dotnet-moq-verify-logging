using Microsoft.Extensions.Logging;

namespace MoqVerifyLogging;

public class Service(ILogger<Service> logger)
{
    public void LogMessage(string message)
    {
        logger.LogInformation(message);
    }
}
