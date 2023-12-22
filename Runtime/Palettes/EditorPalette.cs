using Plugins.CrossPlatformUtilities.UniWind.Microtypes;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
#endif

namespace Plugins.CrossPlatformUtilities.UniWind.Palettes
{
    public static class EditorPalette
    {
        public static bool IsDarkMode =>
#if UNITY_EDITOR
            EditorGUIUtility.isProSkin;
#else
            true;
#endif
        public static readonly VariantColor DarkModeSurfacePalette = new (
            new Color32(0xf4, 0xf4, 0xf4, 0xff),
            new Color32(0xe4, 0xe4, 0xe4, 0xff),
            new Color32(0x6a, 0x6a, 0x6a, 0xff),
            new Color32(0x51, 0x51, 0x51, 0xff),
            new Color32(0x42, 0x42, 0x42, 0xff),
            new Color32(0x38, 0x38, 0x38, 0xff),
            new Color32(0x32, 0x32, 0x32, 0xff),
            new Color32(0x2e, 0x2e, 0x2e, 0xff),
            new Color32(0x2a, 0x2a, 0x2a, 0xff),
            new Color32(0x22, 0x22, 0x22, 0xff),
            new Color32(0x19, 0x19, 0x19, 0xff)
            );
        public static readonly VariantColor LightModeSurfacePalette = new (
            new Color32(0xff, 0xff, 0xff, 0xff),
            new Color32(0xf4, 0xf4, 0xf4, 0xff),
            new Color32(0xf0, 0xf0, 0xf0, 0xff),
            new Color32(0xe4, 0xe4, 0xe4, 0xff),
            new Color32(0xd3, 0xd3, 0xd3, 0xff),
            new Color32(0xc8, 0xc8, 0xc8, 0xff),
            new Color32(0xa5, 0xa5, 0xa5, 0xff),
            new Color32(0x8a, 0x8a, 0x8a, 0xff),
            new Color32(0x5a, 0x5a, 0x5a, 0xff),
            new Color32(0x22, 0x22, 0x22, 0xff),
            new Color32(0x09, 0x09, 0x09, 0xff)
            );
        /// <summary>
        /// 100 - intended for text, 950 - intended for most important background color, 500 - background color
        /// </summary>
        public static readonly VariantColor VariantSurfaceColorFixed = IsDarkMode ? DarkModeSurfacePalette : LightModeSurfacePalette;
        public static readonly VariantColor VariantSurfaceColor = IsDarkMode ? DarkModeSurfacePalette : LightModeSurfacePalette.Invert();
        public static readonly Color BackgroundColor = IsDarkMode ? DarkModeSurfacePalette.s500 : LightModeSurfacePalette.s500;
        public static readonly Color TextColor = IsDarkMode ? DarkModeSurfacePalette.s100 : LightModeSurfacePalette.s900;
        public static readonly Color AccentColor = IsDarkMode ? new Color32(0x01, 0x8c, 0xff, 0xff) : new Color32(0x7b, 0xae, 0xfa, 0xff);
    }
}