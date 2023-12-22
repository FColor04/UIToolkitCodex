using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Plugins.CrossPlatformUtilities.UniWind.MoreUI
{
    public class AutoscrollManipulator : Manipulator
    {
        private VisualElement _currentElement;
        private ScrollView _scrollView;

        private bool ShouldAutoscroll => UIInputUtility.LastInputDevice is Gamepad or Keyboard;

        protected override void RegisterCallbacksOnTarget()
        {
            _scrollView = target as ScrollView;
            target.RegisterCallback<FocusInEvent>(FocusIn);
            target.RegisterCallback<FocusOutEvent>(FocusOut);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<FocusInEvent>(FocusIn);
            target.UnregisterCallback<FocusOutEvent>(FocusOut);
        }

        private void FocusIn(FocusInEvent evt)
        {
            _currentElement = evt.target as VisualElement;

            if (_currentElement != null && ShouldAutoscroll)
                _scrollView.scrollOffset =
                    _currentElement.layout.position - _scrollView.contentViewport.worldBound.size / 2f;
        }

        private void FocusOut(FocusOutEvent evt)
        {
            if (_currentElement == evt.target)
                _currentElement = null;
        }
    }
}