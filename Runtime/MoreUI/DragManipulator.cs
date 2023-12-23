using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitCodex
{
    public class DragManipulator : PointerManipulator
    {
        private Vector3 _elementStartPosition;
        private bool _enabled;
        private Vector3 _pointerStartPosition;

        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<PointerDownEvent>(OnPointerDown);
            target.RegisterCallback<PointerUpEvent>(OnPointerUp);
            target.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            target.RegisterCallback<PointerCaptureOutEvent>(OnPointerCaptureOut);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
            target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
            target.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
            target.UnregisterCallback<PointerCaptureOutEvent>(OnPointerCaptureOut);
        }

        private void OnPointerDown(PointerDownEvent evt)
        {
            if (target.HasPointerCapture(evt.pointerId)) return;

            _enabled = true;
            target.CapturePointer(evt.pointerId);
            _pointerStartPosition = evt.position;
            _elementStartPosition = new Vector3(target.layout.x, target.layout.y);

            evt.StopImmediatePropagation();
        }

        private void OnPointerUp(PointerUpEvent evt)
        {
            if (!_enabled || !target.HasPointerCapture(evt.pointerId)) return;
            target.ReleasePointer(evt.pointerId);
        }

        private void OnPointerMove(PointerMoveEvent evt)
        {
            if (!_enabled || !target.HasPointerCapture(evt.pointerId)) return;
            var pointerDelta = evt.position - _pointerStartPosition;
            target.style.left = _elementStartPosition.x + pointerDelta.x;
            target.style.top = _elementStartPosition.y + pointerDelta.y;
        }

        private void OnPointerCaptureOut(PointerCaptureOutEvent evt)
        {
            _enabled = false;
        }
    }
}