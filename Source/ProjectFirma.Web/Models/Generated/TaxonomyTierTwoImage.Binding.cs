//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierTwoImage]
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
    [Table("[dbo].[TaxonomyTierTwoImage]")]
    public partial class TaxonomyTierTwoImage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyTierTwoImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwoImage(int taxonomyTierTwoImageID, int taxonomyTierTwoID, int fileResourceID) : this()
        {
            this.TaxonomyTierTwoImageID = taxonomyTierTwoImageID;
            this.TaxonomyTierTwoID = taxonomyTierTwoID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwoImage(int taxonomyTierTwoID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TaxonomyTierTwoImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyTierTwoID = taxonomyTierTwoID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TaxonomyTierTwoImage(TaxonomyTierTwo taxonomyTierTwo, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyTierTwoImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyTierTwoID = taxonomyTierTwo.TaxonomyTierTwoID;
            this.TaxonomyTierTwo = taxonomyTierTwo;
            taxonomyTierTwo.TaxonomyTierTwoImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.TaxonomyTierTwoImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyTierTwoImage CreateNewBlank(TaxonomyTierTwo taxonomyTierTwo, FileResource fileResource)
        {
            return new TaxonomyTierTwoImage(taxonomyTierTwo, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyTierTwoImage).Name};

        [Key]
        public int TaxonomyTierTwoImageID { get; set; }
        public int TaxonomyTierTwoID { get; set; }
        public int FileResourceID { get; set; }
        public int PrimaryKey { get { return TaxonomyTierTwoImageID; } set { TaxonomyTierTwoImageID = value; } }

        public virtual TaxonomyTierTwo TaxonomyTierTwo { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}