using UnityEngine;

namespace BWolf.ScriptableEvents.Base
{
    public abstract class EventDispatcher<T> : MonoBehaviour
    {
        [SerializeField]
        private ScriptableEvent<T> _scriptableEvent;

        public void Dispatch(T value)
        {
            _scriptableEvent.Raise(value);
        }

        protected ScriptableEvent<T> GetEvent() => _scriptableEvent;
    }

}