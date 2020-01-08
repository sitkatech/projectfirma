//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReportTemplateModelType]
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
    // Table [dbo].[ReportTemplateModelType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReportTemplateModelType]")]
    public partial class ReportTemplateModelType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReportTemplateModelType()
        {
            this.ReportTemplates = new HashSet<ReportTemplate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReportTemplateModelType(int reportTemplateModelTypeID, string reportTemplateModelTypeName, string reportTemplateModelTypeDisplayName, string reportTemplateModelTypeDescription) : this()
        {
            this.ReportTemplateModelTypeID = reportTemplateModelTypeID;
            this.ReportTemplateModelTypeName = reportTemplateModelTypeName;
            this.ReportTemplateModelTypeDisplayName = reportTemplateModelTypeDisplayName;
            this.ReportTemplateModelTypeDescription = reportTemplateModelTypeDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReportTemplateModelType(string reportTemplateModelTypeName, string reportTemplateModelTypeDisplayName, string reportTemplateModelTypeDescription) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReportTemplateModelTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ReportTemplateModelTypeName = reportTemplateModelTypeName;
            this.ReportTemplateModelTypeDisplayName = reportTemplateModelTypeDisplayName;
            this.ReportTemplateModelTypeDescription = reportTemplateModelTypeDescription;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReportTemplateModelType CreateNewBlank()
        {
            return new ReportTemplateModelType(default(string), default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ReportTemplates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReportTemplateModelType).Name, typeof(ReportTemplate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReportTemplateModelTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in ReportTemplates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReportTemplateModelTypeID { get; set; }
        public string ReportTemplateModelTypeName { get; set; }
        public string ReportTemplateModelTypeDisplayName { get; set; }
        public string ReportTemplateModelTypeDescription { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReportTemplateModelTypeID; } set { ReportTemplateModelTypeID = value; } }

        public virtual ICollection<ReportTemplate> ReportTemplates { get; set; }

        public static class FieldLengths
        {
            public const int ReportTemplateModelTypeName = 100;
            public const int ReportTemplateModelTypeDisplayName = 100;
            public const int ReportTemplateModelTypeDescription = 250;
        }
    }
}