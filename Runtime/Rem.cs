using System;
using UnityEngine.UIElements;

namespace Plugins.CrossPlatformUtilities.UniWind
{
    public readonly struct Rem
    {
        public float RemValue { get; }

        public float PixelValue => RemValue * 16;

        public Rem(float value)
        {
            RemValue = value;
        }

        public static implicit operator int(Rem unit)
        {
            return Convert.ToInt32(unit.PixelValue);
        }

        public static implicit operator float(Rem unit)
        {
            return unit.PixelValue;
        }

        public static implicit operator StyleFloat(Rem unit)
        {
            return unit.PixelValue;
        }

        public static implicit operator StyleLength(Rem unit)
        {
            return unit.PixelValue;
        }
    }
}