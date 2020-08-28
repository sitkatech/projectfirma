//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridTable]
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
        public static PersonSettingGridTable GetPersonSettingGridTable(this IQueryable<PersonSettingGridTable> personSettingGridTables, int personSettingGridTableID)
        {
            var personSettingGridTable = personSettingGridTables.SingleOrDefault(x => x.PersonSettingGridTableID == personSettingGridTableID);
            Check.RequireNotNullThrowNotFound(personSettingGridTable, "PersonSettingGridTable", personSettingGridTableID);
            return personSettingGridTable;
        }

    }
}