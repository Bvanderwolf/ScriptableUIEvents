using UnityEngine;

namespace BWolf.ScriptableEvents.Base
{
    public abstract class UIEvent<T> : ScriptableEvent<T>
    {
        [Header("UI settings")]
        [SerializeField]
        private float _cooldown = 0.0f;

        [SerializeField]
        private LogType _failedCooldownLog = LogType.AS_INFO;

        private float _lastInvokeTime;

        public bool UsesCooldown => _cooldown != 0.0f;

        public float Cooldown => _cooldown;

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