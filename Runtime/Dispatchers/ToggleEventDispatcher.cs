using BWolf.ScriptableEvents.Base;
using UnityEngine;
using UnityEngine.UI;

namespace BWolf.ScriptableEvents.Dispatchers
{
    [RequireComponent(typeof(Toggle))]

    public class ToggleEventDispatcher : EventDispatcher<bool>
    {
        private Toggle _toggle;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
        }

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(Dispatch);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(Dispatch);
        }
    }

}