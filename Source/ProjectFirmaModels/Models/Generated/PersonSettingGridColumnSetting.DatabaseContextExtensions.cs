//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumnSetting]
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
        public static PersonSettingGridColumnSetting GetPersonSettingGridColumnSetting(this IQueryable<PersonSettingGridColumnSetting> personSettingGridColumnSettings, int personSettingGridColumnSettingID)
        {
            var personSettingGridColumnSetting = personSettingGridColumnSettings.SingleOrDefault(x => x.PersonSettingGridColumnSettingID == personSettingGridColumnSettingID);
            Check.RequireNotNullThrowNotFound(personSettingGridColumnSetting, "PersonSettingGridColumnSetting", personSettingGridColumnSettingID);
            return personSettingGridColumnSetting;
        }

    }
}