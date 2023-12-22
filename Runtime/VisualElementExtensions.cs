using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace Plugins.CrossPlatformUtilities.UniWind
{
    public static class VisualElementExtensions
    {
        [ContractAnnotation("source:null => false", true)]
        public static bool TryGetElementAt(this VisualElement source, int index, out VisualElement element)
        {
            element = null;
            if (source == null) return false;
            if (index >= source.childCount || index < 0) return false;
            element = source.ElementAt(index);
            return element != null;
        }

        /// <summary>
        ///     Adds element to source element and then returns source to perform more actions.
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="element">Element</param>
        /// <returns>Source with new element added to it.</returns>
        public static T Append<T>(this T source, VisualElement element) where T : VisualElement
        {
            source.Add(element);
            return source;
        }

        public static T Append<T>(this T source, IEnumerable<VisualElement> elements) where T : VisualElement
        {
            foreach (var element in elements)
                source.Add(element);
            return source;
        }
    }
}
