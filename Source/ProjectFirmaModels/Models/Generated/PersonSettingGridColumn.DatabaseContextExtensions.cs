//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumn]
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
        public static PersonSettingGridColumn GetPersonSettingGridColumn(this IQueryable<PersonSettingGridColumn> personSettingGridColumns, int personSettingGridColumnID)
        {
            var personSettingGridColumn = personSettingGridColumns.SingleOrDefault(x => x.PersonSettingGridColumnID == personSettingGridColumnID);
            Check.RequireNotNullThrowNotFound(personSettingGridColumn, "PersonSettingGridColumn", personSettingGridColumnID);
            return personSettingGridColumn;
        }

    }
}