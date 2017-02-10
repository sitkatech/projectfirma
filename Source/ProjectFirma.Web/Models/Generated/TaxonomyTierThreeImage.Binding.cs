//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierThreeImage]
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
    [Table("[dbo].[TaxonomyTierThreeImage]")]
    public partial class TaxonomyTierThreeImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyTierThreeImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierThreeImage(int taxonomyTierThreeImageID, int taxonomyTierThreeID, int fileResourceID) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.TaxonomyTierThreeImageID = taxonomyTierThreeImageID;
            this.TaxonomyTierThreeID = taxonomyTierThreeID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierThreeImage(int taxonomyTierThreeID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyTierThreeImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.TaxonomyTierThreeID = taxonomyTierThreeID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TaxonomyTierThreeImage(TaxonomyTierThree taxonomyTierThree, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyTierThreeImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.Tenant = HttpRequestStorage.Tenant;
            this.TaxonomyTierThreeID = taxonomyTierThree.TaxonomyTierThreeID;
            this.TaxonomyTierThree = taxonomyTierThree;
            taxonomyTierThree.TaxonomyTierThreeImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.TaxonomyTierThreeImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyTierThreeImage CreateNewBlank(TaxonomyTierThree taxonomyTierThree, FileResource fileResource)
        {
            return new TaxonomyTierThreeImage(taxonomyTierThree, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyTierThreeImage).Name};

        [Key]
        public int TaxonomyTierThreeImageID { get; set; }
        public int TaxonomyTierThreeID { get; set; }
        public int FileResourceID { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return TaxonomyTierThreeImageID; } set { TaxonomyTierThreeImageID = value; } }

        public virtual TaxonomyTierThree TaxonomyTierThree { get; set; }
        public virtual FileResource FileResource { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}