using UnityEngine;

namespace BWolf.ScriptableEvents.Base
{
    /// <summary>
    /// An abstract representation of a behaviour that can dispatch
    /// scriptable object events with no arguments.
    /// </summary>
    public class EventDispatcher : MonoBehaviour
    {
        /// <summary>
        /// The reference to the scriptable object event.
        /// </summary>
        [SerializeField]
        private ScriptableEvent _scriptableEvent;

        /// <summary>
        /// Raises the scriptable object event.
        /// </summary>
        public void RaiseEvent() => _scriptableEvent.Raise();
    }
}