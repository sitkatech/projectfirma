/*-----------------------------------------------------------------------
<copyright file="DhtmlxGridColumnFilterType.cs" company="Environmental Science Associates">
Copyright (c) Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
namespace LtInfo.Common.Views
{
    public enum DhtmlxGridColumnFilterType
    {
        Text,
        Html,
        Numeric,
        FormattedNumeric,
        None,
        SelectFilterStrict,
        SelectFilterHtmlStrict,
        DateRange

        //protected string FilterType { get; set; }

        //public DhtmlxGridColumnFilterType(string filterType)
        //{
        //    FilterType = filterType;
        //}

        //public static implicit operator string(DhtmlxGridColumnFilterType x)
        //{
        //    return x.ToString();
        //}

        //public override string ToString()
        //{
        //    return FilterType;
        //}

        //public static readonly DhtmlxGridColumnFilterType Text = new DhtmlxGridColumnFilterType("#text_filter");
        //public static readonly DhtmlxGridColumnFilterType Html = new DhtmlxGridColumnFilterType("#html_filter");
        //public static readonly DhtmlxGridColumnFilterType Numeric = new DhtmlxGridColumnFilterType("#numeric_filter");
        //public static readonly DhtmlxGridColumnFilterType FormattedNumeric = new DhtmlxGridColumnFilterType("#formatted_numeric_filter");
        //public static readonly DhtmlxGridColumnFilterType None = new DhtmlxGridColumnFilterType("&nbsp;");
        //public static readonly DhtmlxGridColumnFilterType SelectFilterStrict = new DhtmlxGridColumnFilterType("#select_filter_strict");
        //public static readonly DhtmlxGridColumnFilterType SelectFilterHtmlStrict = new DhtmlxGridColumnFilterType("#select_filter_html_strict");
    }
}
