//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReportTemplateModel]
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
    // Table [dbo].[ReportTemplateModel] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReportTemplateModel]")]
    public partial class ReportTemplateModel : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReportTemplateModel()
        {
            this.ReportTemplates = new HashSet<ReportTemplate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReportTemplateModel(int reportTemplateModelID, string reportTemplateModelName, string reportTemplateModelDisplayName, string reportTemplateModelDescription) : this()
        {
            this.ReportTemplateModelID = reportTemplateModelID;
            this.ReportTemplateModelName = reportTemplateModelName;
            this.ReportTemplateModelDisplayName = reportTemplateModelDisplayName;
            this.ReportTemplateModelDescription = reportTemplateModelDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReportTemplateModel(string reportTemplateModelName, string reportTemplateModelDisplayName, string reportTemplateModelDescription) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReportTemplateModelID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ReportTemplateModelName = reportTemplateModelName;
            this.ReportTemplateModelDisplayName = reportTemplateModelDisplayName;
            this.ReportTemplateModelDescription = reportTemplateModelDescription;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReportTemplateModel CreateNewBlank()
        {
            return new ReportTemplateModel(default(string), default(string), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReportTemplateModel).Name, typeof(ReportTemplate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReportTemplateModels.Remove(this);
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
        public int ReportTemplateModelID { get; set; }
        public string ReportTemplateModelName { get; set; }
        public string ReportTemplateModelDisplayName { get; set; }
        public string ReportTemplateModelDescription { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReportTemplateModelID; } set { ReportTemplateModelID = value; } }

        public virtual ICollection<ReportTemplate> ReportTemplates { get; set; }

        public static class FieldLengths
        {
            public const int ReportTemplateModelName = 100;
            public const int ReportTemplateModelDisplayName = 100;
            public const int ReportTemplateModelDescription = 250;
        }
    }
}