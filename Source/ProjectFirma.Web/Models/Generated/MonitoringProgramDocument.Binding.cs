//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MonitoringProgramDocument]
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
    [Table("[dbo].[MonitoringProgramDocument]")]
    public partial class MonitoringProgramDocument : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MonitoringProgramDocument()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MonitoringProgramDocument(int monitoringProgramDocumentID, int fileResourceID, int monitoringProgramID, string displayName, DateTime uploadDate) : this()
        {
            this.MonitoringProgramDocumentID = monitoringProgramDocumentID;
            this.FileResourceID = fileResourceID;
            this.MonitoringProgramID = monitoringProgramID;
            this.DisplayName = displayName;
            this.UploadDate = uploadDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MonitoringProgramDocument(int fileResourceID, int monitoringProgramID, string displayName, DateTime uploadDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MonitoringProgramDocumentID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FileResourceID = fileResourceID;
            this.MonitoringProgramID = monitoringProgramID;
            this.DisplayName = displayName;
            this.UploadDate = uploadDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public MonitoringProgramDocument(FileResource fileResource, MonitoringProgram monitoringProgram, string displayName, DateTime uploadDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MonitoringProgramDocumentID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.MonitoringProgramDocuments.Add(this);
            this.MonitoringProgramID = monitoringProgram.MonitoringProgramID;
            this.MonitoringProgram = monitoringProgram;
            monitoringProgram.MonitoringProgramDocuments.Add(this);
            this.DisplayName = displayName;
            this.UploadDate = uploadDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MonitoringProgramDocument CreateNewBlank(FileResource fileResource, MonitoringProgram monitoringProgram)
        {
            return new MonitoringProgramDocument(fileResource, monitoringProgram, default(string), default(DateTime));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MonitoringProgramDocument).Name};

        [Key]
        public int MonitoringProgramDocumentID { get; set; }
        public int TenantID { get; private set; }
        public int FileResourceID { get; set; }
        public int MonitoringProgramID { get; set; }
        public string DisplayName { get; set; }
        public DateTime UploadDate { get; set; }
        public int PrimaryKey { get { return MonitoringProgramDocumentID; } set { MonitoringProgramDocumentID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FileResource FileResource { get; set; }
        public virtual MonitoringProgram MonitoringProgram { get; set; }

        public static class FieldLengths
        {
            public const int DisplayName = 200;
        }
    }
}