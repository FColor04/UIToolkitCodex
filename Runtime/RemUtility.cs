using System;

namespace UIToolkitCodex
{
    public static class RemUtility
    {
        public static Rem Rem(this int value)
        {
            return new Rem(value);
        }

        public static Rem Rem(this float value)
        {
            return new Rem(value);
        }

        public static Rem Rem(this double value)
        {
            return new Rem(Convert.ToSingle(value));
        }
    }
}