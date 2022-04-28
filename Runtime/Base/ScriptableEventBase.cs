using UnityEngine;

namespace BWolf.ScriptableEvents.Base
{
    /// <summary>
    /// Represents the basis for a scriptable event.
    /// </summary>
    public abstract class ScriptableEventBase : ScriptableObject
    {
        /// <summary>
        /// The way to log message.
        /// </summary>
        protected enum LogType
        {
            [InspectorName("As Info")]
            AS_INFO,

            [InspectorName("As Warning")]
            AS_WARNING,

            [InspectorName("As Error")]
            AS_ERROR
        }

        /// <summary>
        /// Whether this event logs messages.
        /// </summary>
        [Header("Base settings")]
        [SerializeField, Tooltip("Whether this event logs messages.")]
        private bool _logsEvents;

        /// <summary>
        /// Whether this event logs messages.
        /// </summary>
        public bool LogsEvents => _logsEvents;

        /// <summary>
        /// Logs given message as given type if event logging is on.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="logType">The way to log the message.</param>
        protected void LogMessage(string message, LogType logType)
        {
            if (!_logsEvents)
                return;

            switch (logType)
            {
                case LogType.AS_INFO:
                    Debug.Log(message);
                    break;
                case LogType.AS_WARNING:
                    Debug.LogWarning(message);
                    break;
                case LogType.AS_ERROR:
                    Debug.LogError(message);
                    break;
            }
        }
    }
}