//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonGridSetting]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static PersonGridSetting GetPersonGridSetting(this IQueryable<PersonGridSetting> personGridSettings, int personGridSettingID)
        {
            var personGridSetting = personGridSettings.SingleOrDefault(x => x.PersonGridSettingID == personGridSettingID);
            Check.RequireNotNullThrowNotFound(personGridSetting, "PersonGridSetting", personGridSettingID);
            return personGridSetting;
        }

    }
}