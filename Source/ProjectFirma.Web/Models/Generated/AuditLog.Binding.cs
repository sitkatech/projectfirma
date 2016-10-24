//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AuditLog]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[AuditLog]")]
    public partial class AuditLog : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AuditLog()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AuditLog(int auditLogID, int personID, DateTime auditLogDate, int auditLogEventTypeID, string tableName, int recordID, string columnName, string originalValue, string newValue, string auditDescription, int? projectID, int? proposedProjectID) : this()
        {
            this.AuditLogID = auditLogID;
            this.PersonID = personID;
            this.AuditLogDate = auditLogDate;
            this.AuditLogEventTypeID = auditLogEventTypeID;
            this.TableName = tableName;
            this.RecordID = recordID;
            this.ColumnName = columnName;
            this.OriginalValue = originalValue;
            this.NewValue = newValue;
            this.AuditDescription = auditDescription;
            this.ProjectID = projectID;
            this.ProposedProjectID = proposedProjectID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AuditLog(int personID, DateTime auditLogDate, int auditLogEventTypeID, string tableName, int recordID, string columnName, string newValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            AuditLogID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonID = personID;
            this.AuditLogDate = auditLogDate;
            this.AuditLogEventTypeID = auditLogEventTypeID;
            this.TableName = tableName;
            this.RecordID = recordID;
            this.ColumnName = columnName;
            this.NewValue = newValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public AuditLog(Person person, DateTime auditLogDate, AuditLogEventType auditLogEventType, string tableName, int recordID, string columnName, string newValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AuditLogID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonID = person.PersonID;
            this.Person = person;
            person.AuditLogs.Add(this);
            this.AuditLogDate = auditLogDate;
            this.AuditLogEventTypeID = auditLogEventType.AuditLogEventTypeID;
            this.TableName = tableName;
            this.RecordID = recordID;
            this.ColumnName = columnName;
            this.NewValue = newValue;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AuditLog CreateNewBlank(Person person, AuditLogEventType auditLogEventType)
        {
            return new AuditLog(person, default(DateTime), auditLogEventType, default(string), default(int), default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AuditLog).Name};

        [Key]
        public int AuditLogID { get; set; }
        public int PersonID { get; set; }
        public DateTime AuditLogDate { get; set; }
        public int AuditLogEventTypeID { get; set; }
        public string TableName { get; set; }
        public int RecordID { get; set; }
        public string ColumnName { get; set; }
        public string OriginalValue { get; set; }
        public string NewValue { get; set; }
        public string AuditDescription { get; set; }
        public int? ProjectID { get; set; }
        public int? ProposedProjectID { get; set; }
        public int PrimaryKey { get { return AuditLogID; } set { AuditLogID = value; } }

        public virtual Person Person { get; set; }
        public AuditLogEventType AuditLogEventType { get { return AuditLogEventType.AllLookupDictionary[AuditLogEventTypeID]; } }

        public static class FieldLengths
        {
            public const int TableName = 500;
            public const int ColumnName = 500;
        }
    }
}