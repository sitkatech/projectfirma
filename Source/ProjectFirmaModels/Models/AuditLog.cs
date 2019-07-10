/*-----------------------------------------------------------------------
<copyright file="AuditLog.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class AuditLog
    {
        private const string EntityContainerName = "DatabaseEntities";
        private const string PrimaryKeyName = "PrimaryKey";
        private const string PropertyNameProjectStageID = "ProjectStageID";
        private const string PropertyNameProjectImageTimingID = "ProjectImageTimingID";
        private const string PropertyNameProjectLocationAreaID = "ProjectLocationAreaID";
        private const string PropertyNameProjectID = "ProjectID";

        public static readonly List<string> IgnoredTables = new List<string>
        {
            "FirmaPage",
            "FirmaPageImage",
            "FileResource",
            "Notification",
            "NotificationProject",
            "PerformanceMeasureActualSubcategoryOptionUpdate",
            "PerformanceMeasureActualUpdate",
            "PerformanceMeasureExpectedSubcategoryOptionUpdate",
            "PerformanceMeasureExpectedUpdate",
            "PerformanceMeasureImage",
            "ProjectExemptReportingYearUpdate",
            "ProjectExternalLinkUpdate",
            "ProjectFundingSourceExpenditureUpdate",
            "ProjectImageUpdate",
            "ProjectNoteUpdate",
            "ProjectLocationStaging",
            "ProjectLocationStagingUpdate",
            "ProjectUpdate",
            "ProjectUpdateBatch",
            "ProjectUpdateHistory",
            "SupportRequestLog",
            "ProjectBudgetUpdate",
            "ProjectFundingSourceBudgetUpdate",
            "ProjectDocumentUpdate",
            "PersonStewardOrganization",
            "PersonStewardTaxonomyBranch",
            "PersonStewardGeospatialArea",
            "AuditLog"
        };

        public string GetAuditDescriptionDisplay()
        {
            if (string.IsNullOrWhiteSpace(AuditDescription))
            {
                return AuditLogEventType.GetAuditStringForOperationType(ColumnName, OriginalValue, NewValue);
            }

            return AuditDescription;
        }

        public static List<AuditLog> GetAuditLogRecordsForModifiedOrDeleted(DbEntityEntry dbEntry, Person person, ObjectContext objectContext, int tenantID)
        {
            var result = new List<AuditLog>();
            var tableName = EntityFrameworkHelpers.GetTableName(dbEntry.Entity.GetType(), objectContext);
            if (!IgnoredTables.Contains(tableName))
            {
                switch (dbEntry.State)
                {
                    case EntityState.Deleted:
                        var newAuditLog = CreateAuditLogEntryForDeleted(objectContext, dbEntry, tableName, person, DateTime.Now, AuditLogEventType.Deleted, tenantID);
                        result.Add(newAuditLog);
                        break;

                    case EntityState.Modified:
                        var modifiedProperties = dbEntry.CurrentValues.PropertyNames.Where(p => dbEntry.Property(p).IsModified).Select(dbEntry.Property).ToList();
                        var auditLogs =
                            modifiedProperties.Select(
                                modifiedProperty => CreateAuditLogEntryForAddedOrModified(objectContext, dbEntry, tableName, person, DateTime.Now, AuditLogEventType.Modified, modifiedProperty, tenantID))
                                .Where(x => x != null)
                                .ToList();
                        result.AddRange(auditLogs);
                        break;
                }
            }
            // Otherwise, don't do anything, we don't care about Unchanged or Detached entities 
            return result;
        }

        /// <summary>
        /// This has its own path because we need to call this after the initial savechanges to grab the new primary key id from the database
        /// </summary>
        public static List<AuditLog> GetAuditLogRecordsForAdded(DbEntityEntry dbEntry, Person person, ObjectContext objectContext, int tenantID)
        {
            var result = new List<AuditLog>();
            var tableName = EntityFrameworkHelpers.GetTableName(dbEntry.Entity.GetType(), objectContext);
            if (!IgnoredTables.Contains(tableName))
            {
                var modifiedProperties = dbEntry.CurrentValues.PropertyNames.Select(dbEntry.Property).Where(currentProperty => !IsPropertyChangeOfNullToNull(currentProperty)).ToList();
                var auditLogs =
                    modifiedProperties.Select(
                        modifiedProperty => CreateAuditLogEntryForAddedOrModified(objectContext, dbEntry, tableName, person, DateTime.Now, AuditLogEventType.Added, modifiedProperty, tenantID))
                        .Where(x => x != null)
                        .ToList();
                result.AddRange(auditLogs);
            }
            return result;
        }

        /// <summary>
        /// Remove uninteresting properties from Add operations, to reduce noisy meaningless AuditLogs
        /// </summary>
        private static bool IsPropertyChangeOfNullToNull(DbPropertyEntry currentProperty)
        {
            return currentProperty.CurrentValue == null && currentProperty.OriginalValue == null;
        }

        /// <summary>
        /// Creates an audit log entry for a <see cref="DbEntityEntry"/> that has an <see cref="EntityState"/> of <see cref="EntityState.Deleted"/>
        /// Deleted log entries do not have columns/property names, so there will just be one record created
        /// </summary>
        private static AuditLog CreateAuditLogEntryForDeleted(ObjectContext objectContext,
            DbEntityEntry dbEntry,
            string tableName,
            Person person,
            DateTime changeDate,
            AuditLogEventType auditLogEventType, int tenantID)
        {
            var auditableEntityDeleted = GetIAuditableEntityFromEntity(dbEntry.Entity, tableName);
            var optionalAuditDescriptionString = auditLogEventType.GetAuditStringForOperationType(tableName, null, auditableEntityDeleted.GetAuditDescriptionString());
            var auditLogEntry = CreateAuditLogEntryImpl(dbEntry,
                tableName,
                person,
                changeDate,
                auditLogEventType,
                "*ALL",
                AuditLogEventType.Deleted.AuditLogEventTypeDisplayName,
                null,
                optionalAuditDescriptionString, tenantID);
            return auditLogEntry;
        }

        /// <summary>
        /// Creates an audit log entry for a <see cref="DbEntityEntry"/> that has an <see cref="EntityState"/> of <see cref="EntityState.Added"/> or <see cref="EntityState.Modified"/>
        /// It will create an audit log entry for each property that has changed
        /// </summary>
        private static AuditLog CreateAuditLogEntryForAddedOrModified(ObjectContext objectContext,
            DbEntityEntry dbEntry,
            string tableName,
            Person person,
            DateTime changeDate,
            AuditLogEventType auditLogEventType,
            DbPropertyEntry modifiedProperty, int tenantID)
        {
            var propertyName = modifiedProperty.Name;
            if (!string.Equals(propertyName, string.Format("{0}ID", tableName), StringComparison.InvariantCultureIgnoreCase) && !string.Equals(propertyName, "TenantID", StringComparison.InvariantCultureIgnoreCase))
            {
                var optionalAuditDescriptionString = GetAuditDescriptionStringIfAnyForProperty(objectContext, dbEntry, propertyName, auditLogEventType);
                var auditLogEntry = CreateAuditLogEntryImpl(dbEntry,
                    tableName,
                    person,
                    changeDate,
                    auditLogEventType,
                    propertyName,
                    modifiedProperty.CurrentValue,
                    modifiedProperty.OriginalValue,
                    optionalAuditDescriptionString, tenantID);
                return auditLogEntry;
            }
            return null;
        }

        /// <summary>
        /// This is for adding any extra optional columns like ProjectID to the audit log record
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="tableName"></param>
        /// <param name="auditLog"></param>
        private static void AddAdditionalRecordColumns(DbEntityEntry entry, string tableName, AuditLog auditLog)
        {
            if (Project.DependentEntityTypeNames.Contains(tableName))
            {
                var projectID = (int?) entry.Property(PropertyNameProjectID).CurrentValue;
                if (projectID.HasValue)
                {
                    auditLog.ProjectID = projectID;    
                }                
            }
        }

        private static AuditLog CreateAuditLogEntryImpl(DbEntityEntry dbEntry,
            string tableName,
            Person person,
            DateTime changeDate,
            AuditLogEventType auditLogEventType,
            string propertyName,
            object newValue,
            object originalValue,
            string optionalAuditDescriptionString, int tenantID)
        {
            var recordID = (int) dbEntry.Property(PrimaryKeyName).CurrentValue;
            var newValueString = newValue != null ? newValue.ToString() : string.Empty;
            var auditLog = new AuditLog(person, changeDate, auditLogEventType, tableName, recordID, propertyName, newValueString)
            {
                OriginalValue = originalValue != null ? originalValue.ToString() : null,
                AuditDescription = optionalAuditDescriptionString,
                TenantID = tenantID
            };
            AddAdditionalRecordColumns(dbEntry, tableName, auditLog);
            return auditLog;
        }

        /// <summary>
        /// Gets the audit description string for a property that came from a <see cref="DbEntityEntry"/> that has an <see cref="EntityState"/> of <see cref="EntityState.Added"/> or <see cref="EntityState.Modified"/>
        /// This will attempt to look up a foreign key and return a more descriptive string for that fk property
        /// </summary>
        public static string GetAuditDescriptionStringIfAnyForProperty(ObjectContext objectContext, DbEntityEntry dbEntry, string propertyName, AuditLogEventType auditLogEventType)
        {
            var objectStateEntry = objectContext.ObjectStateManager.GetObjectStateEntry(dbEntry.Entity);
            // find foreign key relationships for given propertyname
            var relatedEnds = GetDependentForeignKeyRelatedEndsForProperty(objectStateEntry, propertyName);

            foreach (var end in relatedEnds)
            {
                var elementType = end.RelationshipSet.ElementType as AssociationType;
                if (elementType == null || !elementType.IsForeignKey)
                {
                    continue;
                }

                foreach (var constraint in elementType.ReferentialConstraints)
                {
                    // Multiplicity many means we are looking at a foreign key in a dependent entity
                    // I assume that ToRole will point to a dependent entity, don't know if it can be FromRole
                    Check.Require(constraint.ToRole.RelationshipMultiplicity == RelationshipMultiplicity.Many);
                    // If not 1 then it is a composite key I guess. Becomes a lot more difficult to handle.
                    Check.Require(constraint.ToProperties.Count == 1);

                    var entityName = constraint.FromRole.Name;
                    string auditDescriptionStringForOriginalValue = null;
                    if (!IgnoredTables.Contains(entityName))
                    {
                        var constraintProperty = constraint.ToProperties[0];
                        var principalEntity = (EntityReference) end;

                        var newEntityKey = principalEntity.EntityKey;
                        var auditDescriptionStringForNewValue = GetAuditDescriptionStringForEntityKey(objectContext, newEntityKey, entityName);

                        if (newEntityKey != null)
                        {
                            var oldEntityKey = CreateEntityKeyForValue(newEntityKey.EntitySetName,
                                principalEntity.EntityKey.EntityKeyValues[0].Key,
                                objectStateEntry.OriginalValues[constraintProperty.Name]);
                            auditDescriptionStringForOriginalValue = GetAuditDescriptionStringForEntityKey(objectContext, oldEntityKey, entityName);
                        }
                        return auditLogEventType.GetAuditStringForOperationType(entityName, auditDescriptionStringForOriginalValue, auditDescriptionStringForNewValue);
                    }
                }
            }

            var enumsToHumanReadableString = ConvertEnumsToHumanReadableString(propertyName, objectStateEntry, auditLogEventType);
            if (enumsToHumanReadableString != null)
            {
                return enumsToHumanReadableString;
            }

            return null;
        }

        /// <summary>
        /// Creates an entity key for the given entitySet and primaryKeyValue
        /// Used to look up the Entity from the Original Value
        /// </summary>
        private static EntityKey CreateEntityKeyForValue(string entitySetName, string entityKeyName, object primaryKeyValue)
        {
            EntityKey oldEntityKey = null;
            // Create an EntityKey for the old foreign key value if there was one
            if (!(primaryKeyValue is DBNull))
            {
                var oldPrimaryKeyValue = primaryKeyValue;
                oldEntityKey = new EntityKey
                {
                    EntityContainerName = EntityContainerName,
                    EntitySetName = entitySetName,
                    EntityKeyValues = new[] {new EntityKeyMember(entityKeyName, oldPrimaryKeyValue)}
                };
            }
            return oldEntityKey;
        }

        /// <summary>
        /// Gets the <see cref="IAuditableEntity.AuditDescriptionString"/> for a given entityKey
        /// </summary>
        private static string GetAuditDescriptionStringForEntityKey(ObjectContext objectContext, EntityKey entityKey, string entityName)
        {
            if (entityKey != null)
            {
                var auditableEntity = GetIAuditableEntityFromEntityKey(objectContext, entityKey, entityName);
                return auditableEntity.GetAuditDescriptionString();
            }
            return null;
        }

        /// <summary>
        /// Finds the foreign key related ends for a property, if any
        /// </summary>
        /// <param name="objectStateEntry"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static IEnumerable<IRelatedEnd> GetDependentForeignKeyRelatedEndsForProperty(ObjectStateEntry objectStateEntry, string propertyName)
        {
            return objectStateEntry.RelationshipManager.GetAllRelatedEnds().Where(x =>
            {
                if (!(x is EntityReference)) // we only handle entity references; we can't handle entity collections
                {
                    return false;
                }
                var associationType = ((AssociationType) x.RelationshipSet.ElementType);
                if (associationType == null)
                {
                    return false;
                }
                var referentialConstraints = associationType.ReferentialConstraints;

                return associationType.IsForeignKey && referentialConstraints.Any(c => c.ToProperties.Contains(propertyName));
            }).ToList();
        }

        /// <summary>
        /// Given an objectcontext and entityKey, return an IAuditableEntity
        /// </summary>
        private static IAuditableEntity GetIAuditableEntityFromEntityKey(ObjectContext objectContext, EntityKey entityKey, string tableName)
        {
            var entity = objectContext.GetObjectByKey(entityKey);
            return GetIAuditableEntityFromEntity(entity, tableName);
        }

        /// <summary>
        /// Given an entity, try to cast it to an IAuditableEntity and return it
        /// </summary>
        private static IAuditableEntity GetIAuditableEntityFromEntity(object entity, string tableName)
        {
            var auditableEntity = entity as IAuditableEntity;
            Check.RequireNotNull(auditableEntity, string.Format("{0} needs to implement {1}", tableName, typeof(IAuditableEntity).Name));
            return auditableEntity;
        }

        private static string ConvertEnumsToHumanReadableString(string propertyName, ObjectStateEntry objectStateEntry, AuditLogEventType auditLogEventType)
        {
            switch (propertyName)
            {
                case PropertyNameProjectStageID:
                    return ConvertProjectStageEnumToHumanReadableString(objectStateEntry, auditLogEventType);
                case PropertyNameProjectImageTimingID:
                    return ConvertProjectImageTimingEnumToHumanReadableString(objectStateEntry, auditLogEventType);
                case PropertyNameProjectLocationAreaID:
                    return ConvertProjectLocationAreaEnumToHumanReadableString(objectStateEntry, auditLogEventType);
                default:
                    // deliberately do nothing for now, expand as needed for other enum
                    return null;
            }
        }

        /// <summary>
        /// TODO: should be able to refactor these convert enum to human readable string functions to one call
        /// </summary>
        private static string ConvertProjectStageEnumToHumanReadableString(ObjectStateEntry objectStateEntry, AuditLogEventType auditLogEventType)
        {
            string oldProjectStageName;

            var originalValue = objectStateEntry.OriginalValues[PropertyNameProjectStageID];
            var currentValue = objectStateEntry.CurrentValues[PropertyNameProjectStageID];

            if (originalValue is DBNull)
            {
                oldProjectStageName = "";
            }
            else
            {
                var oldPrimaryKeyValue = (int) originalValue;
                oldProjectStageName = ProjectStage.AllLookupDictionary[oldPrimaryKeyValue].ProjectStageDisplayName;
            }
            var newProjectStageName = ProjectStage.AllLookupDictionary[(int) currentValue].ProjectStageDisplayName;
            return auditLogEventType.GetAuditStringForOperationType("Project Stage", oldProjectStageName, newProjectStageName);
        }

        /// <summary>
        /// TODO: should be able to refactor these convert enum to human readable string functions to one call
        /// </summary>
        private static string ConvertProjectImageTimingEnumToHumanReadableString(ObjectStateEntry objectStateEntry, AuditLogEventType auditLogEventType)
        {
            string oldName;

            var originalValue = objectStateEntry.OriginalValues[PropertyNameProjectImageTimingID];
            var currentValue = objectStateEntry.CurrentValues[PropertyNameProjectImageTimingID];

            if (originalValue is DBNull)
            {
                oldName = "";
            }
            else
            {
                var oldPrimaryKeyValue = (int) originalValue;
                oldName = ProjectImageTiming.AllLookupDictionary[oldPrimaryKeyValue].ProjectImageTimingDisplayName;
            }
            var newName = ProjectImageTiming.AllLookupDictionary[(int) currentValue].ProjectImageTimingDisplayName;
            return auditLogEventType.GetAuditStringForOperationType("Image Timing", oldName, newName);
        }

        /// <summary>
        /// TODO: should be able to refactor these convert enum to human readable string functions to one call
        /// </summary>
        private static string ConvertProjectLocationAreaEnumToHumanReadableString(ObjectStateEntry objectStateEntry, AuditLogEventType auditLogEventType)
        {
            string oldName;

            var originalValue = objectStateEntry.OriginalValues[PropertyNameProjectLocationAreaID];
            var currentValue = objectStateEntry.CurrentValues[PropertyNameProjectLocationAreaID];

            if (originalValue is DBNull)
            {
                oldName = "";
            }
            else
            {
                oldName = string.Empty;// ProjectLocationArea.AllLookupDictionary[((int) originalValue)].ProjectLocationAreaDisplayName;
            }

            string newName;
            if (currentValue is DBNull)
            {
                newName = "";
            }
            else
            {
                newName = string.Empty; //ProjectLocationArea.AllLookupDictionary[(int) currentValue].ProjectLocationAreaDisplayName;
            }
            return auditLogEventType.GetAuditStringForOperationType("Location", oldName, newName);
        }
    }
}
