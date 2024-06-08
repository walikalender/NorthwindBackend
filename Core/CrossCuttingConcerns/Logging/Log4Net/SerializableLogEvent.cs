

using log4net.Core;

namespace MessageProject.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent(LoggingEvent loggingEvent)
    {
        private readonly LoggingEvent _loggingEvent = loggingEvent;

        public object Message => _loggingEvent.MessageObject;
    }
}
