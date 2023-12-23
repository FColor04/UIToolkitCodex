using System;
using System.Collections.Generic;
using UIToolkitCodex.Palettes;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitCodex.Elements
{
    public class Icon : Image
    {
        private static readonly CustomStyleProperty<Texture2D> IconProperty = new("--icon");
        private static StyleSheet StyleSheet => Resources.Load<StyleSheet>("codex-styles");
        
        public Icon()
        {
            tintColor = EditorPalette.TextColor;
            style.W(16).H(16);
            RegisterCallback<CustomStyleResolvedEvent>(OnCustomStyleResolved);
            styleSheets.Add(StyleSheet);
            if (customStyle.TryGetValue(IconProperty, out var textureValue))
            {
                image = textureValue;
            }
        }
        
        public Icon(Texture2D icon, float size = 16, Color? tintOverride = null)
        {
            image = icon;
            tintColor = tintOverride ?? EditorPalette.TextColor;
            style.W(size).H(size);
            RegisterCallback<CustomStyleResolvedEvent>(OnCustomStyleResolved);
            styleSheets.Add(StyleSheet);
        }

        public new class UxmlFactory : UxmlFactory<Icon, UxmlTraits> {}

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            
        }
        
        private void OnCustomStyleResolved(CustomStyleResolvedEvent evt)
        {
            if (evt.customStyle.TryGetValue(IconProperty, out var textureValue))
            {
                image = textureValue;
            }
        }
    }
}