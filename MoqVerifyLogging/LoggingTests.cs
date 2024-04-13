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

        loggerMock.Verify(logger =>
            logger.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((value, _) => value.ToString()!.Contains("Hello, world!")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            )
        );
    }
}
