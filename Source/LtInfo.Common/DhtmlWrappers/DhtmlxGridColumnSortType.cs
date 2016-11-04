using System;

namespace LtInfo.Common.DhtmlWrappers
{
    public class DhtmlxGridColumnSortType
    {
        public string SortingType { get; private set; }

        public DhtmlxGridColumnSortType(string sortingType)
        {
            SortingType = sortingType;
        }
    }
}