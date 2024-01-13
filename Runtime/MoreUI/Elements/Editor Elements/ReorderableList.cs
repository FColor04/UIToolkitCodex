using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace UIToolkitCodex.Editor
{
    public class ReorderableList : ListView
    {
        public Action<VisualElement> OnAddClicked = null;
        
        public int AddItem()
        {
            viewController.AddItems(1);
            if (binding == null)
            {
                SetSelection(itemsSource.Count - 1);
                ScrollToItem(-1);
            }
            else
                schedule.Execute(() =>
                {
                    SetSelection(itemsSource.Count - 1);
                    ScrollToItem(-1);
                }).ExecuteLater(100L);
            
            return viewController.GetItemsCount() - 1;
        }

        public int AddItem(object value)
        {
            
            return viewController.GetItemsCount() - 1;
        }
        
        private static Array AddToArray(Array source, int itemCount)
        {
            System.Type elementType = source.GetType().GetElementType();
            if (elementType == (System.Type) null)
                throw new InvalidOperationException("Cannot resize source, because its size is fixed.");
            Array instance = Array.CreateInstance(elementType, source.Length + itemCount);
            Array.Copy(source, instance, source.Length);
            return instance;
        }
        
        private void OnAddDefault(VisualElement _)
        {
            viewController.AddItems(1);
            if (binding == null)
            {
                SetSelection(itemsSource.Count - 1);
                ScrollToItem(-1);
            }
            else
                schedule.Execute(() =>
                {
                    SetSelection(itemsSource.Count - 1);
                    ScrollToItem(-1);
                }).ExecuteLater(100L);
        }

        public ReorderableList(SerializedProperty property) : base(null, -1f, () => new PropertyField())
        {
            if (property == null) throw new ArgumentException("Provided Serialized property is null");
            
            if (OnAddClicked == null)
                OnAddClicked = OnAddDefault;
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

            schedule.Execute(() =>
            {
                var addButton = this.Q<Button>(footerAddButtonName);
                if (addButton == null || addButton.parent == null) return;
                var buttonParent = addButton.parent;
                var newAddButton = new Button(() => {})
                {
                    name = footerAddButtonName,
                    text = "+"
                };
                newAddButton.clicked += () => OnAddClicked(newAddButton);

                buttonParent.Remove(addButton);
                buttonParent.Add(newAddButton);
            });
            
            this.BindProperty(property);
        }
    }
}
