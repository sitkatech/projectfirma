//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridTable]
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
        public static PersonSettingGridTable GetPersonSettingGridTable(this IQueryable<PersonSettingGridTable> personSettingGridTables, int personSettingGridTableID)
        {
            var personSettingGridTable = personSettingGridTables.SingleOrDefault(x => x.PersonSettingGridTableID == personSettingGridTableID);
            Check.RequireNotNullThrowNotFound(personSettingGridTable, "PersonSettingGridTable", personSettingGridTableID);
            return personSettingGridTable;
        }

        // Delete using an IDList (Firma style)
        public static void DeletePersonSettingGridTable(this IQueryable<PersonSettingGridTable> personSettingGridTables, List<int> personSettingGridTableIDList)
        {
            if(personSettingGridTableIDList.Any())
            {
                personSettingGridTables.Where(x => personSettingGridTableIDList.Contains(x.PersonSettingGridTableID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePersonSettingGridTable(this IQueryable<PersonSettingGridTable> personSettingGridTables, ICollection<PersonSettingGridTable> personSettingGridTablesToDelete)
        {
            if(personSettingGridTablesToDelete.Any())
            {
                var personSettingGridTableIDList = personSettingGridTablesToDelete.Select(x => x.PersonSettingGridTableID).ToList();
                personSettingGridTables.Where(x => personSettingGridTableIDList.Contains(x.PersonSettingGridTableID)).Delete();
            }
        }

        public static void DeletePersonSettingGridTable(this IQueryable<PersonSettingGridTable> personSettingGridTables, int personSettingGridTableID)
        {
            DeletePersonSettingGridTable(personSettingGridTables, new List<int> { personSettingGridTableID });
        }

        public static void DeletePersonSettingGridTable(this IQueryable<PersonSettingGridTable> personSettingGridTables, PersonSettingGridTable personSettingGridTableToDelete)
        {
            DeletePersonSettingGridTable(personSettingGridTables, new List<PersonSettingGridTable> { personSettingGridTableToDelete });
        }
    }
}