using BWolf.ScriptableEvents.Base;
using UnityEngine;
using UnityEngine.UI;

namespace BWolf.ScriptableEvents.Dispatchers
{
    /// <summary>
    /// Dispatches events for dropdown value changes in a user interface.
    /// </summary>
    [RequireComponent(typeof(Dropdown))]
    public class DropdownEventDispatcher : EventDispatcher<int>
    {
        /// <summary>
        /// The dropdown to listen to.
        /// </summary>
        private Dropdown _dropdown;

        /// <summary>
        /// Sets up reference to the dropdown.
        /// </summary>
        private void Awake() => _dropdown = GetComponent<Dropdown>();

        /// <summary>
        /// Starts listening to the dropdown.
        /// </summary>
        private void OnEnable() => _dropdown.onValueChanged.AddListener(RaiseEvent);

        /// <summary>
        /// Stops listening to the dropdown.
        /// </summary>
        private void OnDisable() => _dropdown.onValueChanged.RemoveListener(RaiseEvent);
    }

}