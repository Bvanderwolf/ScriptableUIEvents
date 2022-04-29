using BWolf.ScriptableEvents.Base;
using UnityEngine;
using UnityEngine.UI;

namespace BWolf.ScriptableEvents.Dispatchers
{
    /// <summary>
    /// Dispatches events for toggle value changes in an user interface.
    /// </summary>
    [RequireComponent(typeof(Toggle))]
    public class ToggleEventDispatcher : EventDispatcher<bool>
    {
        /// <summary>
        /// The toggle to start listening to.
        /// </summary>
        private Toggle _toggle;

        /// <summary>
        /// Sets up reference to the toggle.
        /// </summary>
        private void Awake() => _toggle = GetComponent<Toggle>();

        /// <summary>
        /// Starts listening to the toggle.
        /// </summary>
        private void OnEnable() => _toggle.onValueChanged.AddListener(RaiseEvent);

        /// <summary>
        /// Stops listening to the toggle.
        /// </summary>
        private void OnDisable() => _toggle.onValueChanged.RemoveListener(RaiseEvent);
    }
}