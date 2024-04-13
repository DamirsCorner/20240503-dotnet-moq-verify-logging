using Microsoft.Extensions.Logging;
using Moq;

namespace MoqVerifyLogging;

public static class MockExtensions
{
    public static void VerifyLog<T>(
        this Mock<ILogger<T>> loggerMock,
        LogLevel logLevel,
        string message
    )
    {
        loggerMock.Verify(logger =>
            logger.Log(
                logLevel,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((value, _) => value.ToString()!.Contains(message)),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()
            )
        );
    }
}
