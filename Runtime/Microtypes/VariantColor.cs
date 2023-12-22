using UnityEngine;

namespace UIToolkitCodex.Microtypes
{
    public readonly struct VariantColor
    {
        public readonly Color s50;
        public readonly Color s100;
        public readonly Color s200;
        public readonly Color s300;
        public readonly Color s400;
        public readonly Color s500;
        public readonly Color s600;
        public readonly Color s700;
        public readonly Color s800;
        public readonly Color s900;
        public readonly Color s950;

        public (Color, Color) S50S950 => (s50, s950);
        public (Color, Color) S100S900 => (s100, s900);
        public (Color, Color) S200S800 => (s200, s800);
        public (Color, Color) S300S700 => (s300, s700);
        public (Color, Color) S400S600 => (s400, s600);
        public (Color, Color) S500S500 => (s500, s500);
        public (Color, Color) S600S400 => (s600, s400);
        public (Color, Color) S700S300 => (s700, s300);
        public (Color, Color) S800S200 => (s800, s200);
        public (Color, Color) S900S100 => (s900, s100);
        public (Color, Color) S950S50 => (s950, s50);

        public VariantColor(Color s500) : 
            this(
                s500.Saturate(0.1f), 
                s500.Saturate(0.2f), 
                s500.Saturate(0.4f), 
                s500.Saturate(0.6f), 
                s500.Saturate(0.8f), 
                s500, 
                s500.Saturate(1.2f), 
                s500.Saturate(1.4f), 
                s500.Saturate(1.6f), 
                s500.Saturate(1.9f), 
                s500.Saturate(2f)) {}

        public VariantColor(Color s50, Color s100, Color s200, Color s300, Color s400, Color s500, Color s600, Color s700, Color s800, Color s900, Color s950)
        {
            this.s50 = s50;
            this.s100 = s100;
            this.s200 = s200;
            this.s300 = s300;
            this.s400 = s400;
            this.s500 = s500;
            this.s600 = s600;
            this.s700 = s700;
            this.s800 = s800;
            this.s900 = s900;
            this.s950 = s950;
        }

        public VariantColor(Color s50, Color s500, Color s950)
        {
            this.s50 = s50;
            this.s100 = Color.Lerp(s50, s500, 0.2f);
            this.s200 = Color.Lerp(s50, s500, 0.4f);
            this.s300 = Color.Lerp(s50, s500, 0.6f);
            this.s400 = Color.Lerp(s50, s500, 0.8f);
            this.s500 = s500;
            this.s600 = Color.Lerp(s500, s950, 0.2f);
            this.s700 = Color.Lerp(s500, s950, 0.4f);
            this.s800 = Color.Lerp(s500, s950, 0.6f);
            this.s900 = Color.Lerp(s500, s950, 0.8f);
            this.s950 = s950;
        }

        public VariantColor Invert() => new(s950, s900, s800, s700, s600, s500, s400, s300, s200, s100, s50);
    }
}