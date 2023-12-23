using UIToolkitCodex.Palettes;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitCodex.Elements
{
    public class Icon : Image
    {
        public Icon(Texture2D icon, float size = 16, Color? tintOverride = null)
        {
            image = icon;
            tintColor = tintOverride ?? EditorPalette.TextColor;
            style.W(size).H(size);
        }
    }
}