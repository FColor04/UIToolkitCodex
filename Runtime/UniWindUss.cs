using UIToolkitCodex.Microtypes;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitCodex
{
    public static class UIToolkitCodex
    {
        //Background
        public static IStyle Bg(this IStyle style, StyleColor color)
        {
            style.backgroundColor = color;
            return style;
        }

        #region Overflow

        public static IStyle OverflowHidden(this IStyle style)
        {
            style.overflow = new StyleEnum<Overflow>(Overflow.Hidden);
            return style;
        }

        #endregion

        #region Size

        public static IStyle W(this IStyle style, StyleLength width)
        {
            style.width = width;
            return style;
        }

        public static IStyle WMin(this IStyle style, StyleLength minWidth)
        {
            style.minWidth = minWidth;
            return style;
        }

        public static IStyle WMax(this IStyle style, StyleLength maxWidth)
        {
            style.maxWidth = maxWidth;
            return style;
        }

        public static IStyle H(this IStyle style, StyleLength height)
        {
            style.height = height;
            return style;
        }

        public static IStyle HMin(this IStyle style, StyleLength minHeight)
        {
            style.minHeight = minHeight;
            return style;
        }

        public static IStyle HMax(this IStyle style, StyleLength maxHeight)
        {
            style.maxHeight = maxHeight;
            return style;
        }

        #endregion

        #region Padding

        public static IStyle P(this IStyle style, Edges<float> value)
        {
            return style.P(value.Convert<StyleLength>(input => input));
        }

        public static IStyle P(this IStyle style, Edges<StyleLength> value)
        {
            style.paddingTop = value.top;
            style.paddingRight = value.right;
            style.paddingBottom = value.bottom;
            style.paddingLeft = value.left;
            return style;
        }

        #endregion

        #region Margin

        public static IStyle M(this IStyle style, Edges<float> value)
        {
            return style.M(value.Convert<StyleLength>(input => input));
        }

        public static IStyle M(this IStyle style, Edges<StyleLength> value)
        {
            style.marginTop = value.top;
            style.marginRight = value.right;
            style.marginBottom = value.bottom;
            style.marginLeft = value.left;
            return style;
        }

        #endregion

        #region Border

        //Border Thickness

        public static IStyle Border(this IStyle style, Edges<float> thickness)
        {
            return style.Border(thickness.Convert<StyleFloat>(input => input));
        }

        public static IStyle Border(this IStyle style, Edges<StyleFloat> thickness)
        {
            style.borderTopWidth = thickness.top;
            style.borderRightWidth = thickness.right;
            style.borderBottomWidth = thickness.bottom;
            style.borderLeftWidth = thickness.left;
            return style;
        }

        //Border Color

        public static IStyle Border(this IStyle style, Edges<Color> color)
        {
            return style.Border(color.Convert<StyleColor>(input => input));
        }

        public static IStyle Border(this IStyle style, Edges<StyleColor> color)
        {
            style.borderTopColor = color.top;
            style.borderRightColor = color.right;
            style.borderBottomColor = color.bottom;
            style.borderLeftColor = color.left;
            return style;
        }

        //Border Radius

        public static IStyle Radius(this IStyle style, Corners<float> radius)
        {
            return style.Radius(radius.Convert<StyleLength>(input => input));
        }

        public static IStyle Radius(this IStyle style, Corners<StyleLength> radius)
        {
            style.borderTopRightRadius = radius.topRight;
            style.borderBottomRightRadius = radius.bottomRight;
            style.borderBottomLeftRadius = radius.bottomLeft;
            style.borderTopLeftRadius = radius.topLeft;
            return style;
        }

        #endregion

        #region Display

        public static IStyle Flex(this IStyle style)
        {
            style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);
            return style;
        }

        public static IStyle Hidden(this IStyle style)
        {
            style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);
            return style;
        }

        //Flex

        public static IStyle FlexRow(this IStyle style)
        {
            style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row);
            return style;
        }

        public static IStyle FlexRowReverse(this IStyle style)
        {
            style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.RowReverse);
            return style;
        }

        public static IStyle FlexColumn(this IStyle style)
        {
            style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Column);
            return style;
        }

        public static IStyle FlexColumnReverse(this IStyle style)
        {
            style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.ColumnReverse);
            return style;
        }

        public static IStyle FlexCenter(this IStyle style)
        {
            style.justifyContent = new StyleEnum<Justify>(Justify.Center);
            style.alignItems = new StyleEnum<Align>(Align.Center);
            return style;
        }

        public static IStyle ItemsCenter(this IStyle style)
        {
            style.alignItems = new StyleEnum<Align>(Align.Center);
            return style;
        }

        public static IStyle JustifyCenter(this IStyle style)
        {
            style.justifyContent = new StyleEnum<Justify>(Justify.Center);
            return style;
        }

        public static IStyle Grow(this IStyle style)
        {
            style.flexGrow = new StyleFloat(1);
            return style;
        }

        public static IStyle Grow(this IStyle style, StyleFloat value)
        {
            style.flexGrow = value;
            return style;
        }

        public static IStyle Basis(this IStyle style, StyleLength value)
        {
            style.flexBasis = value;
            return style;
        }

        public static IStyle FlexWrap(this IStyle style)
        {
            style.flexWrap = new StyleEnum<Wrap>(Wrap.Wrap);
            return style;
        }

        public static IStyle FlexNoWrap(this IStyle style)
        {
            style.flexWrap = new StyleEnum<Wrap>(Wrap.NoWrap);
            return style;
        }

        public static IStyle FlexWrapReverse(this IStyle style)
        {
            style.flexWrap = new StyleEnum<Wrap>(Wrap.WrapReverse);
            return style;
        }

        #endregion

        #region Position

        public static IStyle Absolute(this IStyle style)
        {
            style.position = new StyleEnum<Position>(Position.Absolute);
            return style;
        }

        public static IStyle Relative(this IStyle style)
        {
            style.position = new StyleEnum<Position>(Position.Relative);
            return style;
        }

        public static IStyle Top(this IStyle style, Length length)
        {
            return style.Top((StyleLength)length);
        }

        public static IStyle Top(this IStyle style, StyleLength length)
        {
            style.top = length;
            return style;
        }

        public static IStyle Right(this IStyle style, Length length)
        {
            return style.Right((StyleLength)length);
        }

        public static IStyle Right(this IStyle style, StyleLength length)
        {
            style.right = length;
            return style;
        }

        public static IStyle Left(this IStyle style, Length length)
        {
            return style.Left((StyleLength)length);
        }

        public static IStyle Left(this IStyle style, StyleLength length)
        {
            style.left = length;
            return style;
        }

        public static IStyle Bottom(this IStyle style, Length length)
        {
            return style.Bottom((StyleLength)length);
        }

        public static IStyle Bottom(this IStyle style, StyleLength length)
        {
            style.bottom = length;
            return style;
        }

        #endregion

        #region Text

        public static IStyle Bold(this IStyle style)
        {
            var current = style.unityFontStyleAndWeight.value;
            var newFontStyle = current is FontStyle.Italic or FontStyle.BoldAndItalic
                ? FontStyle.BoldAndItalic
                : FontStyle.Bold;
            style.unityFontStyleAndWeight = new StyleEnum<FontStyle>(newFontStyle);
            return style;
        }

        public static IStyle FontRegular(this IStyle style)
        {
            style.unityFontStyleAndWeight = new StyleEnum<FontStyle>(FontStyle.Normal);
            return style;
        }

        public static IStyle Italic(this IStyle style)
        {
            var current = style.unityFontStyleAndWeight.value;
            var newFontStyle = current is FontStyle.Bold or FontStyle.BoldAndItalic
                ? FontStyle.BoldAndItalic
                : FontStyle.Italic;
            style.unityFontStyleAndWeight = new StyleEnum<FontStyle>(newFontStyle);
            return style;
        }

        public static IStyle TextCenter(this IStyle style)
        {
            style.unityTextAlign = new StyleEnum<TextAnchor>(TextAnchor.MiddleCenter);
            return style;
        }

        public static IStyle Text(this IStyle style, StyleLength value)
        {
            style.fontSize = value;
            return style;
        }

        public static IStyle TextXs(this IStyle style)
        {
            return style.Text(0.75f.Rem());
        }

        public static IStyle TextSm(this IStyle style)
        {
            return style.Text(0.875f.Rem());
        }

        public static IStyle TextBase(this IStyle style)
        {
            return style.Text(1f.Rem());
        }

        public static IStyle TextLg(this IStyle style)
        {
            return style.Text(1.125f.Rem());
        }

        public static IStyle TextXl(this IStyle style)
        {
            return style.Text(1.25f.Rem());
        }

        public static IStyle Text2Xl(this IStyle style)
        {
            return style.Text(1.5f.Rem());
        }

        public static IStyle Text3Xl(this IStyle style)
        {
            return style.Text(1.875f.Rem());
        }

        public static IStyle Text4Xl(this IStyle style)
        {
            return style.Text(2.25f.Rem());
        }

        public static IStyle Text5Xl(this IStyle style)
        {
            return style.Text(3f.Rem());
        }

        public static IStyle Text6Xl(this IStyle style)
        {
            return style.Text(3.75f.Rem());
        }

        public static IStyle Text7Xl(this IStyle style)
        {
            return style.Text(4.5f.Rem());
        }

        public static IStyle Text8Xl(this IStyle style)
        {
            return style.Text(6f.Rem());
        }

        public static IStyle Text9Xl(this IStyle style)
        {
            return style.Text(8f.Rem());
        }

        #endregion
    }
}