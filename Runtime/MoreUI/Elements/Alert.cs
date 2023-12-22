using UIToolkitCodex;
using UIToolkitCodex.Microtypes;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.CrossPlatformUtilities.UniWind.MoreUI.Elements
{
    public class Alert : VisualElement
    {
        public Alert(string text, VariantColor colorScheme, Texture2D icon = null, bool cleanupTexture = false)
        {
            var backgroundColor = colorScheme.s900.Fade(0.5f);
            var edgeColor = colorScheme.s300.Fade(0.5f);
            var textColor = colorScheme.s100;
            
            //TODO: Parent disable stretch, set max width to 100%, set text to middle left
            style.P(8).Radius(8).Border(2).Border(edgeColor).Bg(backgroundColor).FlexRow();
            
            if(icon != null)
                hierarchy.Add(new Image(){image = icon, tintColor = textColor}.Stylize(s => s.H(32).W(32).M(new Edges<float>(r: 16))));
            
            hierarchy.Add(new Label(text)
            {
                style =
                {
                    color = textColor, 
                    whiteSpace = new StyleEnum<WhiteSpace>(WhiteSpace.Normal),
                    flexShrink = 1
                }
            });
            
            if(cleanupTexture)
                RegisterCallback<DetachFromPanelEvent>(evt =>
                {
                    if(icon != null)
                        Object.Destroy(icon);
                    evt.StopPropagation();
                });
        }
    }
}