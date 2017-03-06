/*-----------------------------------------------------------------------
<copyright file="DhtmlxGridColumnFormatType.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
namespace LtInfo.Common.DhtmlWrappers
{
    public class DhtmlxGridColumnFormatType
    {
        public readonly string ColumnFormatType;

        public DhtmlxGridColumnFormatType(string columnFormatType)
        {
            ColumnFormatType = columnFormatType;
        }

        public static readonly DhtmlxGridColumnFormatType Decimal = new DhtmlxGridColumnFormatType("decimalSitka");
        public static readonly DhtmlxGridColumnFormatType Integer = new DhtmlxGridColumnFormatType("integerSitka");
        public static readonly DhtmlxGridColumnFormatType Currency = new DhtmlxGridColumnFormatType("currencySitka");
        public static readonly DhtmlxGridColumnFormatType Percent = new DhtmlxGridColumnFormatType("percentSitka");
        public static readonly DhtmlxGridColumnFormatType None = new DhtmlxGridColumnFormatType("noneSitka");
        public static readonly DhtmlxGridColumnFormatType DateTime = new DhtmlxGridColumnFormatType("dateTimeSitka");
        public static readonly DhtmlxGridColumnFormatType Date = new DhtmlxGridColumnFormatType("dateSitka");
        public static readonly DhtmlxGridColumnFormatType LatLong = new DhtmlxGridColumnFormatType("latLongSitka");
    }
}
