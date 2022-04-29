using System;
using UnityEngine;
using UnityEngine.Events;

namespace BWolf.ScriptableEvents.Base
{
    /// <summary>
    /// An abstract representation of a scriptable event with one argument.
    /// </summary>
    /// <typeparam name="T">The type of argument passed to the event.</typeparam>
    public abstract class ScriptableEvent<T> : ScriptableEventBase
    {
        /// <summary>
        /// The unity event used by the scriptable object.
        /// </summary>
        [Serializable]
        public class Event : UnityEvent<T> { }

        /// <summary>
        /// The serialized unity event with one argument.
        /// </summary>
        [Header("Event settings")]
        [SerializeField]
        private Event _event;

        /// <summary>
        /// Raises the event.
        /// </summary>
        public void Raise(T value)
        {
            if (OnValidateInvoke(value))
                _event.Invoke(value);
        }

        /// <summary>
        /// Adds a listener to this event.
        /// </summary>
        /// <param name="method">The method to subscribe.</param>
        public void AddListener(UnityAction<T> method) => _event.AddListener(method);

        /// <summary>
        /// Removes a listener from this event.
        /// </summary>
        /// <param name="method">The method to remove.</param>
        public void RemoveListener(UnityAction<T> method) => _event.RemoveListener(method);

        /// <summary>
        /// Removes all listeners from this event.
        /// </summary>
        public void RemoveAllListeners() => _event.RemoveAllListeners();

        /// <summary>
        /// Should validate the invoke and return whether it should continue.
        /// </summary>
        /// <returns>Whether the invoke should continue.</returns>
        protected virtual bool OnValidateInvoke(T value) => true;
    }
}