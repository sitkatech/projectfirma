//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FieldDefinition]
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
        public static FieldDefinition GetFieldDefinition(this IQueryable<FieldDefinition> fieldDefinitions, int fieldDefinitionID)
        {
            var fieldDefinition = fieldDefinitions.SingleOrDefault(x => x.FieldDefinitionID == fieldDefinitionID);
            Check.RequireNotNullThrowNotFound(fieldDefinition, "FieldDefinition", fieldDefinitionID);
            return fieldDefinition;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteFieldDefinition(this IQueryable<FieldDefinition> fieldDefinitions, List<int> fieldDefinitionIDList)
        {
            if(fieldDefinitionIDList.Any())
            {
                fieldDefinitions.Where(x => fieldDefinitionIDList.Contains(x.FieldDefinitionID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteFieldDefinition(this IQueryable<FieldDefinition> fieldDefinitions, ICollection<FieldDefinition> fieldDefinitionsToDelete)
        {
            if(fieldDefinitionsToDelete.Any())
            {
                var fieldDefinitionIDList = fieldDefinitionsToDelete.Select(x => x.FieldDefinitionID).ToList();
                fieldDefinitions.Where(x => fieldDefinitionIDList.Contains(x.FieldDefinitionID)).Delete();
            }
        }

        public static void DeleteFieldDefinition(this IQueryable<FieldDefinition> fieldDefinitions, int fieldDefinitionID)
        {
            DeleteFieldDefinition(fieldDefinitions, new List<int> { fieldDefinitionID });
        }

        public static void DeleteFieldDefinition(this IQueryable<FieldDefinition> fieldDefinitions, FieldDefinition fieldDefinitionToDelete)
        {
            DeleteFieldDefinition(fieldDefinitions, new List<FieldDefinition> { fieldDefinitionToDelete });
        }
    }
}