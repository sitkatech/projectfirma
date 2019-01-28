using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class FundingTypeModelExtensions
    {
        public static FundingType ToType(this FundingTypeEnum fieldDefinitionEnum)
        {
            return HttpRequestStorage.DatabaseEntities.FundingTypes.SingleOrDefault(x =>
                x.FundingTypeID == (int) fieldDefinitionEnum);
        }
        public static FundingType ToType(int fieldDefinitionID)
        {
            return HttpRequestStorage.DatabaseEntities.FundingTypes.SingleOrDefault(x =>
                x.FundingTypeID == fieldDefinitionID);
        }
    }
}