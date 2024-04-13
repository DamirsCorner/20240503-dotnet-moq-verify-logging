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

    [Test]
    public void LogsEventAtInformationLevel()
    {
        var loggerMock = new Mock<ILogger<Service>>();
        var service = new Service(loggerMock.Object);

        service.LogEvent(new EventId(1), "Event message");

        loggerMock.VerifyLog(LogLevel.Information, "Event message", 1);
    }

    [Test]
    public void LogsException()
    {
        var loggerMock = new Mock<ILogger<Service>>();
        var service = new Service(loggerMock.Object);

        service.LogException(new NullReferenceException());

        loggerMock.VerifyLog(
            LogLevel.Error,
            "An error occurred",
            exceptionPredicate: e => e is NullReferenceException
        );
    }
}
