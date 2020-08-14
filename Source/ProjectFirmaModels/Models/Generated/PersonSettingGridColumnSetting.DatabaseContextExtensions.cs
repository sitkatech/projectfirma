//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumnSetting]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        // Delete using an IDList (Firma style)
        public static void DeletePersonSettingGridColumnSetting(this IQueryable<PersonSettingGridColumnSetting> personSettingGridColumnSettings, List<int> personSettingGridColumnSettingIDList)
        {
            if(personSettingGridColumnSettingIDList.Any())
            {
                personSettingGridColumnSettings.Where(x => personSettingGridColumnSettingIDList.Contains(x.PersonSettingGridColumnSettingID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePersonSettingGridColumnSetting(this IQueryable<PersonSettingGridColumnSetting> personSettingGridColumnSettings, ICollection<PersonSettingGridColumnSetting> personSettingGridColumnSettingsToDelete)
        {
            if(personSettingGridColumnSettingsToDelete.Any())
            {
                var personSettingGridColumnSettingIDList = personSettingGridColumnSettingsToDelete.Select(x => x.PersonSettingGridColumnSettingID).ToList();
                personSettingGridColumnSettings.Where(x => personSettingGridColumnSettingIDList.Contains(x.PersonSettingGridColumnSettingID)).Delete();
            }
        }

        public static void DeletePersonSettingGridColumnSetting(this IQueryable<PersonSettingGridColumnSetting> personSettingGridColumnSettings, int personSettingGridColumnSettingID)
        {
            DeletePersonSettingGridColumnSetting(personSettingGridColumnSettings, new List<int> { personSettingGridColumnSettingID });
        }

        public static void DeletePersonSettingGridColumnSetting(this IQueryable<PersonSettingGridColumnSetting> personSettingGridColumnSettings, PersonSettingGridColumnSetting personSettingGridColumnSettingToDelete)
        {
            DeletePersonSettingGridColumnSetting(personSettingGridColumnSettings, new List<PersonSettingGridColumnSetting> { personSettingGridColumnSettingToDelete });
        }
    }
}