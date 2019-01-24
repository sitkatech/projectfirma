//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ImportExternalProjectStaging]
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
    // Table [dbo].[ImportExternalProjectStaging] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ImportExternalProjectStaging]")]
    public partial class ImportExternalProjectStaging : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ImportExternalProjectStaging()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ImportExternalProjectStaging(int importExternalProjectStagingID, int createPersonID, DateTime createDate, string projectName, string description, short? planningDesignStartYear, short? implementationStartYear, short? endYear, double? estimatedCost) : this()
        {
            this.ImportExternalProjectStagingID = importExternalProjectStagingID;
            this.CreatePersonID = createPersonID;
            this.CreateDate = createDate;
            this.ProjectName = projectName;
            this.Description = description;
            this.PlanningDesignStartYear = planningDesignStartYear;
            this.ImplementationStartYear = implementationStartYear;
            this.EndYear = endYear;
            this.EstimatedCost = estimatedCost;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ImportExternalProjectStaging(int createPersonID, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ImportExternalProjectStagingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CreatePersonID = createPersonID;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ImportExternalProjectStaging(Person createPerson, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ImportExternalProjectStagingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CreatePersonID = createPerson.PersonID;
            this.CreatePerson = createPerson;
            createPerson.ImportExternalProjectStagingsWhereYouAreTheCreatePerson.Add(this);
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ImportExternalProjectStaging CreateNewBlank(Person createPerson)
        {
            return new ImportExternalProjectStaging(createPerson, default(DateTime));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ImportExternalProjectStaging).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.AllImportExternalProjectStagings.Remove(this);
        }

        [Key]
        public int ImportExternalProjectStagingID { get; set; }
        public int TenantID { get; set; }
        public int CreatePersonID { get; set; }
        public DateTime CreateDate { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public short? PlanningDesignStartYear { get; set; }
        public short? ImplementationStartYear { get; set; }
        public short? EndYear { get; set; }
        public double? EstimatedCost { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ImportExternalProjectStagingID; } set { ImportExternalProjectStagingID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Person CreatePerson { get; set; }

        public static class FieldLengths
        {
            public const int ProjectName = 140;
            public const int Description = 4000;
        }
    }
}