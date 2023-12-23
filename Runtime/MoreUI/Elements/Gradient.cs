using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitCodex.Elements
{
    public enum GradientDirection
    {
        Unset,
        Horizontal,
        Vertical
    }

    public class GradientElement : VisualElement
    {
        private static readonly Vertex[] Vertices = new Vertex[4];
        private static readonly ushort[] Indices = { 0, 1, 2, 2, 3, 0 };
        private static readonly CustomStyleProperty<Color> _gradientFromProperty = new("--gradient-from");
        private static readonly CustomStyleProperty<Color> _gradientToProperty = new("--gradient-to");
        private static readonly CustomStyleProperty<string> _gradientDirectionProperty = new("--gradient-direction");
        private GradientDirection _gradientDirection;

        private Color _gradientFrom;
        private Color _gradientTo;

        public GradientElement()
        {
            generateVisualContent += GenerateVisualContent;
            RegisterCallback<CustomStyleResolvedEvent>(OnStylesResolved);
        }

        public GradientElement(Color from, Color to, GradientDirection direction = GradientDirection.Horizontal)
        {
            _gradientFrom = from;
            _gradientTo = to;
            _gradientDirection = direction;
            generateVisualContent += GenerateVisualContent;
            RegisterCallback<CustomStyleResolvedEvent>(OnStylesResolved);
        }

        private void OnStylesResolved(CustomStyleResolvedEvent @event)
        {
            if (_gradientFrom == default)
                @event.customStyle.TryGetValue(_gradientFromProperty, out _gradientFrom);
            if (_gradientTo == default)
                @event.customStyle.TryGetValue(_gradientToProperty, out _gradientTo);
            if (_gradientDirection == default)
            {
                @event.customStyle.TryGetValue(_gradientDirectionProperty, out var gradientDirectionAsString);
                if (Enum.TryParse(typeof(GradientDirection), gradientDirectionAsString, true,
                        out var gradientDirection))
                    _gradientDirection = (GradientDirection)gradientDirection;
                else
                    _gradientDirection = GradientDirection.Horizontal;
            }

            if (_gradientDirection == GradientDirection.Unset)
                _gradientDirection = GradientDirection.Horizontal;
        }

        private void GenerateVisualContent(MeshGenerationContext meshGenerationContext)
        {
            var rect = contentRect;
            if (rect.width < 0.1f || rect.height < 0.1f)
                return;

            UpdateVerticesTint();
            UpdateVerticesPosition(rect);

            var meshWriteData = meshGenerationContext.Allocate(Vertices.Length, Indices.Length);
            meshWriteData.SetAllVertices(Vertices);
            meshWriteData.SetAllIndices(Indices);
        }

        private static void UpdateVerticesPosition(Rect rect)
        {
            var left = rect.x;
            var right = rect.x + rect.width;
            var top = rect.y;
            var bottom = rect.y + rect.height;

            Vertices[0].position = new Vector3(left, bottom, Vertex.nearZ);
            Vertices[1].position = new Vector3(left, top, Vertex.nearZ);
            Vertices[2].position = new Vector3(right, top, Vertex.nearZ);
            Vertices[3].position = new Vector3(right, bottom, Vertex.nearZ);
        }

        private void UpdateVerticesTint()
        {
            if (_gradientDirection is GradientDirection.Horizontal)
            {
                Vertices[0].tint = _gradientFrom;
                Vertices[1].tint = _gradientFrom;
                Vertices[2].tint = _gradientTo;
                Vertices[3].tint = _gradientTo;
            }
            else
            {
                Vertices[0].tint = _gradientTo;
                Vertices[1].tint = _gradientFrom;
                Vertices[2].tint = _gradientFrom;
                Vertices[3].tint = _gradientTo;
            }
        }

        public new class UxmlFactory : UxmlFactory<GradientElement, GradientElementUxmlTraits>
        {
        }

        public class GradientElementUxmlTraits : UxmlTraits
        {
        }
    }
}