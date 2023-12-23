using System.Collections.Generic;
using System.Linq;
using UIToolkitCodex.Microtypes;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIToolkitCodex.Elements
{
    public class Grid : VisualElement
    {
        public float cellHeight = 18;
        public int columns;
        public int rows;

        public Grid(int columns = -1, int rows = -1)
        {
            SetSize(columns, rows);
        }

        public void SetSize(int columns = -1, int rows = -1)
        {
            this.columns = columns;
            this.rows = rows;
            UpdateLayout();
        }

        public void UpdateLayout()
        {
            var children = Children().ToArray();
            var layoutContainer = new GridContainer<VisualElement>
                { elements = new List<(Vector2Int, Vector2Int, VisualElement)>() };
            var offset = 0;
            for (var i = 0; i < children.Length; i++)
            {
                var child = children[i];
                var classes = child.GetClasses().ToArray();

                var sizeX = ExtractVariable(classes, "col-span-", 1);
                var sizeY = ExtractVariable(classes, "row-span-", 1);

                var startX = ExtractVariable(classes, "col-start-", offset % columns);
                var startY = ExtractVariable(classes, "row-start-", Mathf.FloorToInt((float)i / columns));

                var endX = ExtractVariable(classes, "col-end-", -1);
                var endY = ExtractVariable(classes, "row-end-", -1);

                if (endX >= 0)
                    sizeX = endX - startX;
                else
                    endX = startX + sizeX;
                if (endY >= 0)
                    sizeY = endY - startY;
                else
                    endY = startY + sizeY;

                layoutContainer.AddElement(new Vector2Int(startX, startY), new Vector2Int(sizeX, sizeY), child);
                offset += sizeX;
            }

            layoutContainer.size.x = Mathf.Max(layoutContainer.size.x, columns);
            layoutContainer.size.y = Mathf.Max(layoutContainer.size.y, rows);

            style.Relative().H(cellHeight * layoutContainer.size.y);

            foreach (var tuple in layoutContainer.GetNormalized())
                tuple.element.style
                    .Absolute()
                    .W(new StyleLength(new Length(tuple.size.x * 100f, LengthUnit.Percent)))
                    .H(new StyleLength(new Length(tuple.size.y * 100f, LengthUnit.Percent)))
                    .Top(new StyleLength(new Length(tuple.position.y * 100f, LengthUnit.Percent)))
                    .Left(new StyleLength(new Length(tuple.position.x * 100f, LengthUnit.Percent)));
        }

        private int ExtractVariable(IEnumerable<string> array, string @base, int @default)
        {
            return int.TryParse(
                array.FirstOrSpecified(@base + @default, c => c.StartsWith(@base)).Remove(0, @base.Length),
                out var result)
                ? result
                : @default;
        }
    }
}