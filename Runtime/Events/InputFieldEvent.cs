using BWolf.ScriptableEvents.Base;
using UnityEngine;

namespace BWolf.ScriptableEvents.Events
{
    /// <summary>
    /// Represents an event fired after text in an input field has changed.
    /// </summary>
    [CreateAssetMenu(menuName = "UI/Events/InputField")]
    public class InputFieldEvent : UIEvent<string>
    {
    }
}
