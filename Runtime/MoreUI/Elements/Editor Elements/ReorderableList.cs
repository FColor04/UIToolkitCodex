using System;
using System.Collections;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.CrossPlatformUtilities.UniWind.MoreUI.Elements
{
    public class ReorderableList : ListView
    {
        public ReorderableList(SerializedProperty property) : base(null, -1f, () => new PropertyField())
        {
            headerTitle = property.displayName;

            bindItem = (element, i) =>
            {
                property.serializedObject.Update();
                ((PropertyField) element).BindProperty(property.GetArrayElementAtIndex(i));
            };
            unbindItem = (element, i) =>
            {
                ((PropertyField) element).Unbind();
            };
            reorderable = true;
            reorderMode = ListViewReorderMode.Animated;
            showAddRemoveFooter = true;
            showFoldoutHeader = true;

            virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight;

            this.BindProperty(property);
        }
    }
}
