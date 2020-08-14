//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumn]
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
        public static PersonSettingGridColumn GetPersonSettingGridColumn(this IQueryable<PersonSettingGridColumn> personSettingGridColumns, int personSettingGridColumnID)
        {
            var personSettingGridColumn = personSettingGridColumns.SingleOrDefault(x => x.PersonSettingGridColumnID == personSettingGridColumnID);
            Check.RequireNotNullThrowNotFound(personSettingGridColumn, "PersonSettingGridColumn", personSettingGridColumnID);
            return personSettingGridColumn;
        }

        // Delete using an IDList (Firma style)
        public static void DeletePersonSettingGridColumn(this IQueryable<PersonSettingGridColumn> personSettingGridColumns, List<int> personSettingGridColumnIDList)
        {
            if(personSettingGridColumnIDList.Any())
            {
                personSettingGridColumns.Where(x => personSettingGridColumnIDList.Contains(x.PersonSettingGridColumnID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePersonSettingGridColumn(this IQueryable<PersonSettingGridColumn> personSettingGridColumns, ICollection<PersonSettingGridColumn> personSettingGridColumnsToDelete)
        {
            if(personSettingGridColumnsToDelete.Any())
            {
                var personSettingGridColumnIDList = personSettingGridColumnsToDelete.Select(x => x.PersonSettingGridColumnID).ToList();
                personSettingGridColumns.Where(x => personSettingGridColumnIDList.Contains(x.PersonSettingGridColumnID)).Delete();
            }
        }

        public static void DeletePersonSettingGridColumn(this IQueryable<PersonSettingGridColumn> personSettingGridColumns, int personSettingGridColumnID)
        {
            DeletePersonSettingGridColumn(personSettingGridColumns, new List<int> { personSettingGridColumnID });
        }

        public static void DeletePersonSettingGridColumn(this IQueryable<PersonSettingGridColumn> personSettingGridColumns, PersonSettingGridColumn personSettingGridColumnToDelete)
        {
            DeletePersonSettingGridColumn(personSettingGridColumns, new List<PersonSettingGridColumn> { personSettingGridColumnToDelete });
        }
    }
}