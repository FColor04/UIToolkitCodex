using System;

namespace UIToolkitCodex.Microtypes
{
    public readonly struct Corners<T>
    {
        public readonly T topRight;
        public readonly T bottomRight;
        public readonly T bottomLeft;
        public readonly T topLeft;

        public Corners(T v)
        {
            topRight = v;
            bottomRight = v;
            bottomLeft = v;
            topLeft = v;
        }

        public Corners(T tr, T br, T bl, T tl)
        {
            topRight = tr;
            bottomRight = br;
            bottomLeft = bl;
            topLeft = tl;
        }

        public Corners<TResult> Convert<TResult>(Func<T, TResult> conversion)
        {
            return new Corners<TResult>(
                conversion(topRight),
                conversion(bottomRight),
                conversion(bottomLeft),
                conversion(topLeft)
            );
        }

        public static implicit operator Corners<T>(T source)
        {
            return new Corners<T>(source);
        }
    }
}