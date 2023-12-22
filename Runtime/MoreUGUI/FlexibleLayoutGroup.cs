using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FlexibleLayoutGroup : LayoutGroup
    {
        public enum FitType
        {
            Uniform,
            Width,
            Height,
            FixedRows,
            FixedColumns
        }

        public FitType fitType;

        public int rows;
        public int columns;
        public bool fitX;
        public bool fitY;
        public Vector2 spacing;
        public Vector2 cellSize;

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();

            if (fitType != FitType.FixedColumns && fitType != FitType.FixedRows)
            {
                fitX = true;
                fitY = true;
                float squareRoot = Mathf.Sqrt(transform.childCount);
                rows = Mathf.CeilToInt(squareRoot);
                columns = Mathf.CeilToInt(squareRoot);
            }

            switch (fitType)
            {
                default:
                case FitType.Uniform:
                    break;
                case FitType.Width or FitType.FixedColumns:
                    rows = Mathf.CeilToInt(transform.childCount / (float) columns);
                    break;
                case FitType.Height or FitType.FixedRows:
                    columns = Mathf.CeilToInt(transform.childCount / (float) rows);
                    break;
            }

            Rect parentRect = rectTransform.rect;
            var parentWidth = parentRect.width;
            var parentHeight = parentRect.height;

            var cellWidth = parentWidth / columns - spacing.x / columns * (columns - 1) - padding.left / (float) columns - padding.right / (float) columns;
            var cellHeight = parentHeight / rows - spacing.y / rows * (rows - 1) - padding.top / (float) rows - padding.bottom / (float) rows;

            cellSize = new Vector2(fitX ? cellWidth : cellSize.x, fitY ? cellHeight : cellSize.y);

            int rowCount = 0;
            int columnCount = 0;

            for (int i = 0; i < rectChildren.Count; i++)
            {
                rowCount = i / columns;
                columnCount = i % columns;

                var item = rectChildren[i];

                var xPos = cellSize.x * columnCount + spacing.x * columnCount + padding.left;
                var yPos = cellSize.y * rowCount + spacing.y * rowCount + padding.top;

                SetChildAlongAxis(item, 0, xPos, cellSize.x);
                SetChildAlongAxis(item, 1, yPos, cellSize.y);
            }
        }

        public override void CalculateLayoutInputVertical()
        {

        }

        public override void SetLayoutHorizontal()
        {

        }

        public override void SetLayoutVertical()
        {

        }
    }
}
