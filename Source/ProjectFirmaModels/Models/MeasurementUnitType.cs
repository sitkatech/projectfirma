/*-----------------------------------------------------------------------
<copyright file="MeasurementUnitType.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirmaModels.Models
{
    public partial class MeasurementUnitType
    {
        public virtual string DisplayValue(double? reportedValue)
        {
            var stringPrecision = new string('0', NumberOfSignificantDigits);
            var unitDisplayName = MeasurementUnitTypeID == (int)MeasurementUnitTypeEnum.Number ? "" : LegendDisplayName;
            return reportedValue.HasValue ? $"{reportedValue.Value.ToString($"#,###,###,##0.{stringPrecision}")} {unitDisplayName}"
                : ViewUtilities.NotAvailableString;
        }
    }

    public partial class MeasurementUnitTypeAcres
    {
    }

    public partial class MeasurementUnitTypeMiles
    {
    }

    public partial class MeasurementUnitTypeSquareFeet
    {
    }

    public partial class MeasurementUnitTypeLinearFeet
    {
    }

    public partial class MeasurementUnitTypeKilogram
    {
    }

    public partial class MeasurementUnitTypeNumber
    {
    }

    public partial class MeasurementUnitTypePounds
    {
    }

    public partial class MeasurementUnitTypeTons
    {
    }

    public partial class MeasurementUnitTypeDollars
    {
        public override string DisplayValue(double? reportedValue)
        {
            return reportedValue.HasValue ? reportedValue.ToStringCurrency() : ViewUtilities.NotAvailableString;
        }
    }
}
