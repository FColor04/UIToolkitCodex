using System;

namespace UIToolkitCodex.Microtypes
{
    public readonly struct Edges<T>
    {
        public readonly T top;
        public readonly T right;
        public readonly T bottom;
        public readonly T left;

        public Edges(T v)
        {
            top = v;
            right = v;
            bottom = v;
            left = v;
        }

        public Edges(T x = default, T y = default)
        {
            top = y;
            right = x;
            bottom = y;
            left = x;
        }

        public Edges(T t = default, T r = default, T b = default, T l = default)
        {
            top = t;
            right = r;
            bottom = b;
            left = l;
        }

        public Edges<TResult> Convert<TResult>(Func<T, TResult> conversion)
        {
            return new Edges<TResult>(
                conversion(top),
                conversion(right),
                conversion(bottom),
                conversion(left)
            );
        }

        public static implicit operator Edges<T>(T source)
        {
            return new Edges<T>(source);
        }
    }
}