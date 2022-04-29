using System;
using UnityEngine;

namespace BWolf.ScriptableEvents.Base
{
    /// <summary>
    /// An abstract representation of a scriptable ui event with one argument.
    /// </summary>
    /// <typeparam name="T">The type of argument passed to the event.</typeparam>
    public abstract class UIEvent<T> : ScriptableEvent<T>
    {
        /// <summary>
        /// The cooldown on the event invoke. 
        /// </summary>
        [Header("UI settings")]
        [SerializeField, Tooltip("The cooldown on the event invoke. ")]
        private float _cooldown = 0.0f;

        /// <summary>
        /// The way to log failed invoke because of cooldown.
        /// </summary>
        [SerializeField, Tooltip("The way to log failed invoke because of cooldown.")]
        private LogType _failedCooldownLog = LogType.AS_INFO;

        /// <summary>
        /// The last time an invoke was done. Non serialized as to not retain
        /// state after play mode sessions.
        /// </summary>
        [NonSerialized]
        private float _lastInvokeTime;

        /// <summary>
        /// Whether this ui event uses a cooldown.
        /// </summary>
        public bool UsesCooldown => _cooldown != 0.0f;

        /// <summary>
        /// The cooldown on the event invoke.  
        /// </summary>
        public float Cooldown => _cooldown;

        /// <summary>
        /// Validates whether the ui event can invoke based on cooldown.
        /// </summary>
        /// <param name="value">The argument passed to the event.</param>
        /// <returns>Whether the ui event can invoke.</returns>
        protected override bool OnValidateInvoke(T value)
        {
            if (!UsesCooldown)
                return true;

            float time = Time.time;
            bool canInvoke = _lastInvokeTime == 0.0f || time - _lastInvokeTime > _cooldown;
            if (!canInvoke)
                LogMessage($"{name} ui event not raised :: cooldown time {time - _lastInvokeTime} not passed yet",
                    _failedCooldownLog);

            _lastInvokeTime = time;

            return canInvoke;
        }
    }

}