using BWolf.ScriptableEvents.Base;
using UnityEngine;

namespace BWolf.ScriptableEvents.Events
{
    /// <summary>
    /// Represents an event that is fired after a value on a toggle has changed.
    /// </summary>
    [CreateAssetMenu(menuName = "UI/Events/Toggle")]
    public class ToggleEvent : UIEvent<bool>
    {
    }
}
