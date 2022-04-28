using BWolf.ScriptableEvents.Base;
using UnityEngine;
using UnityEngine.UI;

namespace BWolf.ScriptableEvents.Dispatchers
{
    public class InputFieldEventDispatcher : EventDispatcher<string>
    {
        private enum EventType
        {
            [InspectorName("Value Changes")]
            VALUE_CHANGE,

            [InspectorName("End of edit")]
            END_EDIT
        }

        [SerializeField]
        private EventType _eventType;

        private InputField _inputField;

        private void Awake()
        {
            _inputField = GetComponent<InputField>();
        }

        private void OnEnable()
        {
            switch (_eventType)
            {
                case EventType.VALUE_CHANGE:
                    _inputField.onValueChanged.AddListener(Dispatch);
                    break;

                case EventType.END_EDIT:
                    _inputField.onEndEdit.AddListener(Dispatch);
                    break;
            }
        }

        private void OnDisable()
        {
            switch (_eventType)
            {
                case EventType.VALUE_CHANGE:
                    _inputField.onValueChanged.RemoveListener(Dispatch);
                    break;

                case EventType.END_EDIT:
                    _inputField.onEndEdit.RemoveListener(Dispatch);
                    break;
            }
        }
    }

}