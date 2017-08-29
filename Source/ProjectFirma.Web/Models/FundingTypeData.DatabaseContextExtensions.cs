/*-----------------------------------------------------------------------
<copyright file="FundingTypeData.DatabaseContextExtensions.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FundingTypeData GetFundingTypeDataByFundingType(this IQueryable<FundingTypeData> fundingTypeDatas, FundingType fundingType)
        {
            return GetFundingTypeDataByFundingType(fundingTypeDatas, fundingType.FundingTypeID);
        }

        public static FundingTypeData GetFundingTypeDataByFundingType(this IQueryable<FundingTypeData> fundingTypeDatas, int fundingTypeID)
        {
            return fundingTypeDatas.SingleOrDefault(x => x.FundingTypeID == fundingTypeID);
        }

        public static FundingTypeData GetFundingTypeDataByFundingType(this IQueryable<FundingTypeData> fundingTypeDatas, FundingTypeEnum fundingTypeEnum)
        {
            return fundingTypeDatas.SingleOrDefault(x => x.FundingTypeID == (int) fundingTypeEnum);
        }

        public static FundingTypeData GetFundingTypeDataByFundingType(this IQueryable<FundingTypeData> fundingTypeDatas, FundingTypePrimaryKey fundingTypePrimaryKey)
        {
            return fundingTypeDatas.SingleOrDefault(x => x.FundingTypeID == fundingTypePrimaryKey.PrimaryKeyValue);
        }
    }
}
