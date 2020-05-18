//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SecondaryProjectTaxonomyLeaf]
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
    // Table [dbo].[SecondaryProjectTaxonomyLeaf] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[SecondaryProjectTaxonomyLeaf]")]
    public partial class SecondaryProjectTaxonomyLeaf : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SecondaryProjectTaxonomyLeaf()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SecondaryProjectTaxonomyLeaf(int secondaryProjectTaxonomyLeafID, int projectID, int taxonomyLeafID) : this()
        {
            this.SecondaryProjectTaxonomyLeafID = secondaryProjectTaxonomyLeafID;
            this.ProjectID = projectID;
            this.TaxonomyLeafID = taxonomyLeafID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SecondaryProjectTaxonomyLeaf(int projectID, int taxonomyLeafID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SecondaryProjectTaxonomyLeafID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.TaxonomyLeafID = taxonomyLeafID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SecondaryProjectTaxonomyLeaf(Project project, TaxonomyLeaf taxonomyLeaf) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SecondaryProjectTaxonomyLeafID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.SecondaryProjectTaxonomyLeafs.Add(this);
            this.TaxonomyLeafID = taxonomyLeaf.TaxonomyLeafID;
            this.TaxonomyLeaf = taxonomyLeaf;
            taxonomyLeaf.SecondaryProjectTaxonomyLeafs.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SecondaryProjectTaxonomyLeaf CreateNewBlank(Project project, TaxonomyLeaf taxonomyLeaf)
        {
            return new SecondaryProjectTaxonomyLeaf(project, taxonomyLeaf);
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SecondaryProjectTaxonomyLeaf).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllSecondaryProjectTaxonomyLeafs.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int SecondaryProjectTaxonomyLeafID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int TaxonomyLeafID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return SecondaryProjectTaxonomyLeafID; } set { SecondaryProjectTaxonomyLeafID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual TaxonomyLeaf TaxonomyLeaf { get; set; }

        public static class FieldLengths
        {

        }
    }
}