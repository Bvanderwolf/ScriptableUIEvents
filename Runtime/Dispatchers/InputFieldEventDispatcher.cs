using BWolf.ScriptableEvents.Base;
using UnityEngine;
using UnityEngine.UI;

namespace BWolf.ScriptableEvents.Dispatchers
{
    /// <summary>
    /// Dispatches events for value changes or end of edits in an input field.
    /// </summary>
    public class InputFieldEventDispatcher : EventDispatcher<string>
    {
        /// <summary>
        /// The type of changes to listen for.
        /// </summary>
        private enum EventType
        {
            [InspectorName("Value Changes")]
            VALUE_CHANGE,

            [InspectorName("End of edit")]
            END_EDIT
        }

        /// <summary>
        /// The type of changes to listen for.
        /// </summary>
        [SerializeField, Tooltip("The type of changes to listen for.")]
        private EventType _eventType;

        /// <summary>
        /// The input field to start listening to.
        /// </summary>
        private InputField _inputField;

        /// <summary>
        /// Sets up reference to input field.
        /// </summary>
        private void Awake() => _inputField = GetComponent<InputField>();

        /// <summary>
        /// Starts listening to the input field.
        /// </summary>
        private void OnEnable()
        {
            switch (_eventType)
            {
                case EventType.VALUE_CHANGE:
                    _inputField.onValueChanged.AddListener(RaiseEvent);
                    break;

                case EventType.END_EDIT:
                    _inputField.onEndEdit.AddListener(RaiseEvent);
                    break;
            }
        }

        /// <summary>
        /// Stops listening to the input field.
        /// </summary>
        private void OnDisable()
        {
            switch (_eventType)
            {
                case EventType.VALUE_CHANGE:
                    _inputField.onValueChanged.RemoveListener(RaiseEvent);
                    break;

                case EventType.END_EDIT:
                    _inputField.onEndEdit.RemoveListener(RaiseEvent);
                    break;
            }
        }
    }
}