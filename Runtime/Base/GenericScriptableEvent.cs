using System;
using UnityEngine;
using UnityEngine.Events;

namespace BWolf.ScriptableEvents.Base
{
    public abstract class ScriptableEvent<T> : ScriptableEventBase
    {
        [Serializable]
        public class Event : UnityEvent<T>
        {
        }

        [Header("Event settings")]
        [SerializeField]
        private Event _event;

        public void Raise(T value)
        {
            if (OnValidateInvoke(value))
                _event.Invoke(value);
        }

        public void AddListener(UnityAction<T> method)
        {
            _event.AddListener(method);
        }

        public void RemoveListener(UnityAction<T> method)
        {
            _event.RemoveListener(method);
        }

        public void RemoveAllListeners()
        {
            _event.RemoveAllListeners();
        }

        protected virtual bool OnValidateInvoke(T value) => true;
    }

}