/*-----------------------------------------------------------------------
<copyright file="GraphHelper.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
