#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UIElements;

namespace UIToolkitCodex.Elements
{
    public class ReadOnlyField : PropertyField
    {
        public ReadOnlyField()
        {
            SetEnabled(false);
        }

        public ReadOnlyField(SerializedProperty property) : base(property)
        {
            SetEnabled(false);
        }
    }
}
#endif