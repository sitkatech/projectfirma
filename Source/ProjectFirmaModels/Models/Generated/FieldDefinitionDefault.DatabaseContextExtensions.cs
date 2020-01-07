//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinitionDefault]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FieldDefinitionDefault GetFieldDefinitionDefault(this IQueryable<FieldDefinitionDefault> fieldDefinitionDefaults, int fieldDefinitionDefaultID)
        {
            var fieldDefinitionDefault = fieldDefinitionDefaults.SingleOrDefault(x => x.FieldDefinitionDefaultID == fieldDefinitionDefaultID);
            Check.RequireNotNullThrowNotFound(fieldDefinitionDefault, "FieldDefinitionDefault", fieldDefinitionDefaultID);
            return fieldDefinitionDefault;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteFieldDefinitionDefault(this IQueryable<FieldDefinitionDefault> fieldDefinitionDefaults, List<int> fieldDefinitionDefaultIDList)
        {
            if(fieldDefinitionDefaultIDList.Any())
            {
                fieldDefinitionDefaults.Where(x => fieldDefinitionDefaultIDList.Contains(x.FieldDefinitionDefaultID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteFieldDefinitionDefault(this IQueryable<FieldDefinitionDefault> fieldDefinitionDefaults, ICollection<FieldDefinitionDefault> fieldDefinitionDefaultsToDelete)
        {
            if(fieldDefinitionDefaultsToDelete.Any())
            {
                var fieldDefinitionDefaultIDList = fieldDefinitionDefaultsToDelete.Select(x => x.FieldDefinitionDefaultID).ToList();
                fieldDefinitionDefaults.Where(x => fieldDefinitionDefaultIDList.Contains(x.FieldDefinitionDefaultID)).Delete();
            }
        }

        public static void DeleteFieldDefinitionDefault(this IQueryable<FieldDefinitionDefault> fieldDefinitionDefaults, int fieldDefinitionDefaultID)
        {
            DeleteFieldDefinitionDefault(fieldDefinitionDefaults, new List<int> { fieldDefinitionDefaultID });
        }

        public static void DeleteFieldDefinitionDefault(this IQueryable<FieldDefinitionDefault> fieldDefinitionDefaults, FieldDefinitionDefault fieldDefinitionDefaultToDelete)
        {
            DeleteFieldDefinitionDefault(fieldDefinitionDefaults, new List<FieldDefinitionDefault> { fieldDefinitionDefaultToDelete });
        }
    }
}