using Microsoft.Extensions.Logging;
using Moq;

namespace MoqVerifyLogging;

public class LoggingTests
{
    [Test]
    public void LogsMessageAtInformationLevel()
    {
        var loggerMock = new Mock<ILogger<Service>>();
        var service = new Service(loggerMock.Object);

        service.LogMessage("Hello, world!");

        loggerMock.VerifyLog(LogLevel.Information, "Hello, world!");
    }
}
