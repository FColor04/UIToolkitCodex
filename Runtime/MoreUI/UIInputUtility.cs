using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace UIToolkitCodex
{
    public static class UIInputUtility
    {
        public static InputDevice LastInputDevice { get; private set; }

        [RuntimeInitializeOnLoadMethod]
        public static void Init()
        {
            InputSystem.onEvent -= OnEvent;
            InputSystem.onEvent += OnEvent;
        }

        private static void OnEvent(InputEventPtr eventPtr, InputDevice device)
        {
            LastInputDevice = device;
        }
    }
}