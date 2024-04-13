using Microsoft.Extensions.Logging;

namespace MoqVerifyLogging;

public class Service(ILogger<Service> logger)
{
    public void LogMessage(string message)
    {
        logger.LogInformation(message);
    }

    public void LogEvent(EventId eventId, string message)
    {
        logger.LogInformation(eventId, message);
    }

    public void LogException(Exception exception)
    {
        logger.LogError(exception, "An error occurred");
    }
}
