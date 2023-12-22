#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UIElements;

namespace Plugins.CrossPlatformUtilities.UniWind.MoreUI.Elements
{
    public class PreviewField : PropertyField
    {
        public PreviewField() : base()
        {
            SetEnabled(false);
        }

        public PreviewField(SerializedProperty property) : base(property)
        {
            SetEnabled(false);
        }
    }
}
#endif
