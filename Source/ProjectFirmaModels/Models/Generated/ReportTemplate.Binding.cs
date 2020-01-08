//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReportTemplate]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[ReportTemplate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ReportTemplate]")]
    public partial class ReportTemplate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReportTemplate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReportTemplate(int reportTemplateID, int fileResourceID, string displayName, string description, int reportTemplateModelTypeID) : this()
        {
            this.ReportTemplateID = reportTemplateID;
            this.FileResourceID = fileResourceID;
            this.DisplayName = displayName;
            this.Description = description;
            this.ReportTemplateModelTypeID = reportTemplateModelTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReportTemplate(int fileResourceID, string displayName, int reportTemplateModelTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReportTemplateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FileResourceID = fileResourceID;
            this.DisplayName = displayName;
            this.ReportTemplateModelTypeID = reportTemplateModelTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ReportTemplate(FileResource fileResource, string displayName, ReportTemplateModelType reportTemplateModelType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReportTemplateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ReportTemplates.Add(this);
            this.DisplayName = displayName;
            this.ReportTemplateModelTypeID = reportTemplateModelType.ReportTemplateModelTypeID;
            this.ReportTemplateModelType = reportTemplateModelType;
            reportTemplateModelType.ReportTemplates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReportTemplate CreateNewBlank(FileResource fileResource, ReportTemplateModelType reportTemplateModelType)
        {
            return new ReportTemplate(fileResource, default(string), reportTemplateModelType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReportTemplate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllReportTemplates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReportTemplateID { get; set; }
        public int TenantID { get; set; }
        public int FileResourceID { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int ReportTemplateModelTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReportTemplateID; } set { ReportTemplateID = value; } }

        public virtual FileResource FileResource { get; set; }
        public virtual ReportTemplateModelType ReportTemplateModelType { get; set; }

        public static class FieldLengths
        {
            public const int DisplayName = 200;
            public const int Description = 1000;
        }
    }
}