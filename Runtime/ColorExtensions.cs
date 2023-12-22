using UIToolkitCodex.Palettes;
using UnityEngine;

namespace UIToolkitCodex
{
    public static class ColorExtensions
    {
        public static float Max(this Color source) => Mathf.Max(source.r, source.g, source.b);
        public static float Min(this Color source) => Mathf.Min(source.r, source.g, source.b);
        public static float Luminosity(this Color source) => source.Max() - source.Min();

        public static float Saturation(this Color source)
        {
            var luminosity = source.Luminosity();
            return luminosity < 0.5f ? 
                luminosity / (source.Max() + source.Min()) : 
                luminosity / (2 - source.Max() - source.Min());
        }

        public static Color Saturate(this Color source, float amount)
        {
            Color.RGBToHSV(source, out var h, out var s, out var v);
            return Color.HSVToRGB(h, s * amount, v);
        }
        
        public static Color Fade(this Color source, float amount)
        {
            return new Color(source.r, source.g, source.b, amount);
        }
        
        public static Color Pick(this (Color, Color) source, bool inverse = false)
        {
            return EditorPalette.IsDarkMode ^ inverse ? source.Item2 : source.Item1;
        }
    }
}