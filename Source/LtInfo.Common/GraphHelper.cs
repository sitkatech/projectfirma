using System;
using System.Collections.Generic;
using System.Linq;

namespace LtInfo.Common
{
    public static class GraphHelper
    {
        public static List<T> Traverse<T>(T item, Func<T, T> otherNodeSelector) where T : class
        {
            bool isGraphAValidTree;
            return TraverseImpl(item, x => new List<T>{ otherNodeSelector(x)}, out isGraphAValidTree);
        }

        public static List<T> Traverse<T>(T item, Func<T, IEnumerable<T>> otherNodeSelector) where T : class
        {
            bool isGraphAValidTree;
            return TraverseImpl(item, otherNodeSelector, out isGraphAValidTree);
        }

        public static bool IsTraverseAValidTree<T>(T item, Func<T, T> otherNodeSelector) where T : class
        {
            return IsTraverseAValidTree(item, x => new List<T> { otherNodeSelector(x) });
        }

        public static bool IsTraverseAValidTree<T>(T item, Func<T, IEnumerable<T>> otherNodeSelector) where T : class
        {
            bool isGraphAValidTree;
            TraverseImpl(item, otherNodeSelector, out isGraphAValidTree);
            return isGraphAValidTree;
        }

        private static List<T> TraverseImpl<T>(T item, Func<T, IEnumerable<T>> otherNodeSelector, out bool isGraphAValidTree) where T : class
        {
            isGraphAValidTree = true;
            var itemsVisited = new HashSet<T>();
            var itemsToVisit = new Stack<T>();
            itemsToVisit.Push(item);
            while (itemsToVisit.Any())
            {
                var next = itemsToVisit.Pop();
                if (next == null)
                {
                    continue;
                }
                if (itemsVisited.Contains(next))
                {
                    isGraphAValidTree = false;
                    continue;
                }
                itemsVisited.Add(next);
                var children = otherNodeSelector(next);
                if (children == null)
                {
                    continue;
                }
                foreach (var child in children)
                {
                    itemsToVisit.Push(child);
                }
            }
            return itemsVisited.ToList();
        }
    }
}