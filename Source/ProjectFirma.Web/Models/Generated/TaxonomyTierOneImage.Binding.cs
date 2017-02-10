//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierOneImage]
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
    [Table("[dbo].[TaxonomyTierOneImage]")]
    public partial class TaxonomyTierOneImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyTierOneImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierOneImage(int taxonomyTierOneImageID, int taxonomyTierOneID, int fileResourceID) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.TaxonomyTierOneImageID = taxonomyTierOneImageID;
            this.TaxonomyTierOneID = taxonomyTierOneID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierOneImage(int taxonomyTierOneID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyTierOneImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.TaxonomyTierOneID = taxonomyTierOneID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TaxonomyTierOneImage(TaxonomyTierOne taxonomyTierOne, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyTierOneImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.Tenant = HttpRequestStorage.Tenant;
            this.TaxonomyTierOneID = taxonomyTierOne.TaxonomyTierOneID;
            this.TaxonomyTierOne = taxonomyTierOne;
            taxonomyTierOne.TaxonomyTierOneImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.TaxonomyTierOneImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyTierOneImage CreateNewBlank(TaxonomyTierOne taxonomyTierOne, FileResource fileResource)
        {
            return new TaxonomyTierOneImage(taxonomyTierOne, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyTierOneImage).Name};

        [Key]
        public int TaxonomyTierOneImageID { get; set; }
        public int TaxonomyTierOneID { get; set; }
        public int FileResourceID { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return TaxonomyTierOneImageID; } set { TaxonomyTierOneImageID = value; } }

        public virtual TaxonomyTierOne TaxonomyTierOne { get; set; }
        public virtual FileResource FileResource { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}