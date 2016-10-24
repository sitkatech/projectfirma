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