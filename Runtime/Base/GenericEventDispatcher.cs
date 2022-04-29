using UnityEngine;

namespace BWolf.ScriptableEvents.Base
{
    /// <summary>
    /// An abstract representation of a behaviour that can dispatch
    /// scriptable object events with one argument.
    /// </summary>
    /// <typeparam name="T">The type of argument used for the event.</typeparam>
    public abstract class EventDispatcher<T> : MonoBehaviour
    {
        /// <summary>
        /// The reference to the scriptable object event.
        /// </summary>
        [SerializeField]
        private ScriptableEvent<T> _scriptableEvent;

        /// <summary>
        /// Raises the scriptable object event.
        /// </summary>
        /// <param name="value">The argument used for the event.</param>
        public void RaiseEvent(T value) => _scriptableEvent.Raise(value);
    }

}