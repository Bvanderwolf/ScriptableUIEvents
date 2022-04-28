using System;   
using UnityEngine;
using UnityEngine.Events;

namespace BWolf.ScriptableEvents.Base
{
    /// <summary>
    /// An abstract representation of a scriptable object as event without arguments.
    /// </summary>
    public abstract class ScriptableEvent : ScriptableEventBase
    {
        /// <summary>
        /// The unity event used by the scriptable object.
        /// </summary>
        [Serializable]
        protected class Event : UnityEvent { }

        /// <summary>
        /// The serializable event without arguments.
        /// </summary>
        [Header("Event settings")]
        [SerializeField]
        private Event _event;

        /// <summary>
        /// Raises the event.
        /// </summary>
        public void Raise()
        {
            if (OnValidateInvoke())
                _event.Invoke();
        }

        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="method">The method to subscribe.</param>
        public void AddListener(UnityAction method) => _event.AddListener(method);

        /// <summary>
        /// Removes a listener from this event.
        /// </summary>
        /// <param name="method">The method to remove.</param>
        public void RemoveListener(UnityAction method) => _event.RemoveListener(method);

        /// <summary>
        /// Removes all listeners from this event.
        /// </summary>
        public void RemoveAllListeners() => _event.RemoveAllListeners();

        /// <summary>
        /// Should validate the invoke and return whether it should continue.
        /// </summary>
        /// <returns>Whether the invoke should continue.</returns>
        protected virtual bool OnValidateInvoke() => true;
    }
}