using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class MeasurementUnitType
    {
        public virtual string DisplayValue(double? reportedValue)
        {
            return reportedValue.HasValue ? reportedValue.ToGroupedNumeric() : ViewUtilities.NotAvailableString;
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