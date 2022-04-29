using BWolf.ScriptableEvents.Base;
using UnityEngine;
using UnityEngine.UI;

namespace BWolf.ScriptableEvents.Dispatchers
{
    /// <summary>
    /// Dispatches events for button clicks in a user interface.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class ButtonEventDispatcher : EventDispatcher
    {
        /// <summary>
        /// The button to listen to.
        /// </summary>
        private Button _button;

        /// <summary>
        /// Sets up reference to the button.
        /// </summary>
        private void Awake() => _button = GetComponent<Button>();

        /// <summary>
        /// Starts listening to the button.
        /// </summary>
        private void OnEnable() => _button.onClick.AddListener(RaiseEvent);

        /// <summary>
        /// Stops listening to the button.
        /// </summary>
        private void OnDisable() => _button.onClick.RemoveListener(RaiseEvent);
    }

}