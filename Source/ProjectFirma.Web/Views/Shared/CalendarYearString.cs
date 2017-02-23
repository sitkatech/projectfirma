/*-----------------------------------------------------------------------
<copyright file="CalendarYearString.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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

namespace ProjectFirma.Web.Views.Shared
{
    public struct CalendarYearString
    {
        public readonly int CalendarYear;
        public readonly bool IsRealEntry;
        public AddedDeletedOrRealElement AddedDeletedOrRealElement;
        public string DisplayCssClass;

        public CalendarYearString(int calendarYear, AddedDeletedOrRealElement addedDeletedOrRealElement)
        {
            CalendarYear = calendarYear;
            IsRealEntry = addedDeletedOrRealElement == AddedDeletedOrRealElement.RealElement;
            AddedDeletedOrRealElement = addedDeletedOrRealElement;
            switch (AddedDeletedOrRealElement)
            {
                case AddedDeletedOrRealElement.AddedElement:
                    DisplayCssClass = HtmlDiffContainer.DisplayCssClassAddedElement;
                    break;
                case AddedDeletedOrRealElement.DeletedElement:
                    DisplayCssClass = HtmlDiffContainer.DisplayCssClassDeletedElement;
                    break;
                case AddedDeletedOrRealElement.RealElement:
                    DisplayCssClass = string.Empty;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public CalendarYearString(int calendarYear) : this(calendarYear, AddedDeletedOrRealElement.RealElement)
        {
        }
    }

    public enum AddedDeletedOrRealElement
    {
        AddedElement,
        DeletedElement,
        RealElement
    }
}
