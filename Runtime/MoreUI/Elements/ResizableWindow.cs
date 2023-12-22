using UIToolkitCodex;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.CrossPlatformUtilities.UniWind.MoreUI.Elements
{
    public class ResizableWindow : VisualElement
    {
        private readonly VisualElement _contentContainer;

        public ResizableWindow()
        {
            //Root
            style.position = new StyleEnum<Position>(Position.Absolute);
            style.minHeight = new StyleLength(40);
            style.minWidth = new StyleLength(120);
            style.P(4).Radius(8).Border(new Color(1f, 0.5f, 0f));
            style.backgroundColor = new StyleColor(new Color(0, 0, 0, 0.3f));
            RegisterCallback<FocusInEvent>(_ => style.Border(4));
            RegisterCallback<FocusOutEvent>(_ => style.Border(0));

            this.AddManipulator(new ResizeManipulator());
            this.AddManipulator(new DragManipulator());

            //Header
            Header = new VisualElement();

            Header.style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row);

            Header.Add(new Label
            {
                style =
                {
                    color = new StyleColor(Color.white),
                    flexGrow = 1
                }
            });

            Header.Add(new Button(() => parent.Remove(this))
            {
                text = "X",
                style =
                {
                    marginTop = 8,
                    marginRight = 8,
                    marginBottom = 0,
                    marginLeft = 0,
                    paddingTop = 2,
                    paddingRight = 2,
                    paddingBottom = 2,
                    paddingLeft = 2,
                    fontSize = 14,
                    height = 18,
                    width = 18
                }
            });

            HeaderText = "Window";
            hierarchy.Add(Header);

            //Content container

            _contentContainer = new ScrollView();
            hierarchy.Add(_contentContainer);
            _contentContainer.style.minHeight = 16;
            _contentContainer.AddManipulator(new AutoscrollManipulator());
        }

        public VisualElement Header { get; }

        public string HeaderText
        {
            get => Header.Q<Label>().text;
            set => Header.Q<Label>().text = value;
        }

        public override VisualElement contentContainer => _contentContainer;
    }
}
