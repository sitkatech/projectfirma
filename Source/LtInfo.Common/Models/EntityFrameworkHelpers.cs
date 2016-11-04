using System;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace LtInfo.Common.Models
{
    public static class EntityFrameworkHelpers
    {
        /// <summary>
        /// Microsoft finally gave a legit way to get table name for an entity type in EF 6.1. 
        /// See http://romiller.com/2014/04/08/ef6-1-mapping-between-types-tables/
        /// </summary>
        public static string GetTableName(Type type, ObjectContext objectContext)
        {
            var metadata = objectContext.MetadataWorkspace;

            // Get the part of the model that contains info about the actual CLR types
            var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));

            // Get the entity type from the model that maps to the CLR type
            var entityType = metadata
                    .GetItems<EntityType>(DataSpace.OSpace)
                    .SingleOrDefault(e => objectItemCollection.GetClrType(e) == type);

            // Early abort; what we find here is better than nothing, and may work much of the time -- SLG
            if (entityType == null)
            {
                return type.BaseType != null ? type.BaseType.Name : type.Name;
            }

            // Get the entity set that uses this entity type
            var entitySet = metadata
                .GetItems<EntityContainer>(DataSpace.CSpace)
                .Single()
                .EntitySets
                .Single(s => s.ElementType.Name == entityType.Name);

            // Find the mapping between conceptual and storage model for this entity set
            var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
                    .Single()
                    .EntitySetMappings
                    .Single(s => s.EntitySet == entitySet);

            // Find the storage entity set (table) that the entity is mapped
            var table = mapping
                .EntityTypeMappings.Single()
                .Fragments.Single()
                .StoreEntitySet;

            // Return the table name from the storage entity set
            return (string)table.MetadataProperties["Table"].Value ?? table.Name;
        }
    }
}


