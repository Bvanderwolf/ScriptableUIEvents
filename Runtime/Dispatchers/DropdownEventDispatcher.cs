using BWolf.ScriptableEvents.Base;
using UnityEngine;
using UnityEngine.UI;

namespace BWolf.ScriptableEvents.Dispatchers
{
    [RequireComponent(typeof(Dropdown))]
    public class DropdownEventDispatcher : EventDispatcher<int>
    {
        private Dropdown _dropdown;

        private void Awake()
        {
            _dropdown = GetComponent<Dropdown>();
        }

        private void OnEnable()
        {
            _dropdown.onValueChanged.AddListener(Dispatch);
        }

        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(Dispatch);
        }
    }

}