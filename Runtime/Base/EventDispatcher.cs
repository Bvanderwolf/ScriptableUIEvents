using UnityEngine;

namespace BWolf.ScriptableEvents.Base
{
    public class EventDispatcher : MonoBehaviour
    {
        [SerializeField]
        private ScriptableEvent _scriptableEvent;

        public void Dispatch()
        {
            _scriptableEvent.Raise();
        }

        protected T GetEvent<T>() where T : ScriptableEvent => (T)_scriptableEvent;
    }

}