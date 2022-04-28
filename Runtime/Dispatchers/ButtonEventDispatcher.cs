using BWolf.ScriptableEvents.Base;
using UnityEngine;
using UnityEngine.UI;

namespace BWolf.ScriptableEvents.Dispatchers
{
    [RequireComponent(typeof(Button))]
    public class ButtonEventDispatcher : EventDispatcher
    {
        private Button _toggle;

        private void Awake()
        {
            _toggle = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _toggle.onClick.AddListener(Dispatch);
        }

        private void OnDisable()
        {
            _toggle.onClick.RemoveListener(Dispatch);
        }
    }

}