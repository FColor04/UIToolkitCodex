using UIToolkitCodex.Microtypes;
using UIToolkitCodex.Palettes;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace UIToolkitCodex.Editor
{
    public class FieldInspectorElement : VisualElement
    {
        public FieldInspectorElement(SerializedObject obj, bool displayNameHeader = true)
        {
            AddToClassList("unity-inspector-element");
            if(displayNameHeader)
                Add(new Label(ObjectNames.NicifyVariableName(obj.targetObject.name)).Stylize(s => s.Bg(EditorPalette.VariantSurfaceColorFixed.s800).Grow().P(4).Bold()));
            style.W(new Length(100, LengthUnit.Percent)).P(4);

            var serializedSettingsIterator = obj.GetIterator();
            
            serializedSettingsIterator.NextVisible(true);

            while (serializedSettingsIterator.NextVisible(false))
            {
                var property = new PropertyField(serializedSettingsIterator).Stylize(s => s.HMin(16).M(new Edges<float>(12, 0)));
                property.Bind(obj);
                Add(property);
            }
        }
    }
}