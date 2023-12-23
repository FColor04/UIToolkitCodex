using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitCodex
{
    public class ResizeManipulator : PointerManipulator
    {
        private Rect _elementStartRect;
        private bool _enabled;
        private Vector2Int _heldEdge;
        private Vector3 _pointerStartPosition;
        public float edgeWidth = 4;

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

            var positionWithinTarget = (Vector2)evt.position - target.worldBound.position;

            _heldEdge = Vector2Int.zero;
            if (positionWithinTarget.x < edgeWidth)
                _heldEdge.x = -1;
            if (positionWithinTarget.x > target.worldBound.width - edgeWidth)
                _heldEdge.x = 1;
            if (positionWithinTarget.y < edgeWidth)
                _heldEdge.y = -1;
            if (positionWithinTarget.y > target.worldBound.height - edgeWidth)
                _heldEdge.y = 1;

            if (_heldEdge == Vector2.zero) return;

            _enabled = true;
            target.CapturePointer(evt.pointerId);
            _pointerStartPosition = evt.position;
            _elementStartRect = target.layout;

            Debug.Log(positionWithinTarget);
            Debug.Log(_heldEdge);

            evt.StopImmediatePropagation();
            evt.PreventDefault();
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
            if (_heldEdge.x == -1)
            {
                target.style.left = _elementStartRect.x + pointerDelta.x;
                target.style.width = Mathf.Max(_elementStartRect.width - pointerDelta.x,
                    target.resolvedStyle.minWidth.value);
            }
            else if (_heldEdge.x == 1)
            {
                target.style.width = Mathf.Max(_elementStartRect.width + pointerDelta.x,
                    target.resolvedStyle.minWidth.value);
            }

            if (_heldEdge.y == -1)
            {
                target.style.top = _elementStartRect.y + pointerDelta.y;
                target.style.height = Mathf.Max(_elementStartRect.height - pointerDelta.y,
                    target.resolvedStyle.minHeight.value);
            }
            else if (_heldEdge.y == 1)
            {
                target.style.height = Mathf.Max(_elementStartRect.height + pointerDelta.y,
                    target.resolvedStyle.minHeight.value);
            }
        }

        private void OnPointerCaptureOut(PointerCaptureOutEvent evt)
        {
            _enabled = false;
        }
    }
}