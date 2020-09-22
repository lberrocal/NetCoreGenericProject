using System;
using Microsoft.Extensions.Logging;

namespace GenericProject.Logging
{
    public static class LoggerExtensions
    {
        public static class EventIds
        {
            public static readonly EventId ExceptionCaught = new EventId(1000, "ExceptionCaught");
            public static readonly EventId OperationCancelledExceptionCaught = new EventId(1001, "OperationCancelledExceptionCaught");
        }
        
        public static void OperationCancelledExceptionOccurred(this ILogger logger) => logger.Log(LogLevel.Information, EventIds.OperationCancelledExceptionCaught, "A task/operation cancelled exception was caught.");
    }
}