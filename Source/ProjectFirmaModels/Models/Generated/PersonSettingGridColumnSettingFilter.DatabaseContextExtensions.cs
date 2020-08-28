//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumnSettingFilter]
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
        public static PersonSettingGridColumnSettingFilter GetPersonSettingGridColumnSettingFilter(this IQueryable<PersonSettingGridColumnSettingFilter> personSettingGridColumnSettingFilters, int personSettingGridColumnSettingFilterID)
        {
            var personSettingGridColumnSettingFilter = personSettingGridColumnSettingFilters.SingleOrDefault(x => x.PersonSettingGridColumnSettingFilterID == personSettingGridColumnSettingFilterID);
            Check.RequireNotNullThrowNotFound(personSettingGridColumnSettingFilter, "PersonSettingGridColumnSettingFilter", personSettingGridColumnSettingFilterID);
            return personSettingGridColumnSettingFilter;
        }

    }
}