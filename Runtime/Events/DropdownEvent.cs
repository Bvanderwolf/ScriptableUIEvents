using BWolf.ScriptableEvents.Base;
using UnityEngine;

namespace BWolf.ScriptableEvents.Events
{
    /// <summary>
    /// Represents an event fired after a value in a dropdown has changed.
    /// </summary>
    [CreateAssetMenu(menuName = "UI/Events/Dropdown")]
    public class DropdownEvent : UIEvent<int>
    {
    }
}