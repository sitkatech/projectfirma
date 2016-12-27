//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyTierTwo]
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
    [Table("[dbo].[TaxonomyTierTwo]")]
    public partial class TaxonomyTierTwo : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyTierTwo()
        {
            this.TaxonomyTierOnes = new HashSet<TaxonomyTierOne>();
            this.TaxonomyTierTwoImages = new HashSet<TaxonomyTierTwoImage>();
            this.TaxonomyTierTwoPerformanceMeasures = new HashSet<TaxonomyTierTwoPerformanceMeasure>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwo(int taxonomyTierTwoID, int taxonomyTierThreeID, string taxonomyTierTwoName, string taxonomyTierTwoDescription) : this()
        {
            this.TaxonomyTierTwoID = taxonomyTierTwoID;
            this.TaxonomyTierThreeID = taxonomyTierThreeID;
            this.TaxonomyTierTwoName = taxonomyTierTwoName;
            this.TaxonomyTierTwoDescription = taxonomyTierTwoDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwo(int taxonomyTierThreeID, string taxonomyTierTwoName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TaxonomyTierTwoID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyTierThreeID = taxonomyTierThreeID;
            this.TaxonomyTierTwoName = taxonomyTierTwoName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TaxonomyTierTwo(TaxonomyTierThree taxonomyTierThree, string taxonomyTierTwoName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyTierTwoID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyTierThreeID = taxonomyTierThree.TaxonomyTierThreeID;
            this.TaxonomyTierThree = taxonomyTierThree;
            taxonomyTierThree.TaxonomyTierTwos.Add(this);
            this.TaxonomyTierTwoName = taxonomyTierTwoName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyTierTwo CreateNewBlank(TaxonomyTierThree taxonomyTierThree)
        {
            return new TaxonomyTierTwo(taxonomyTierThree, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return TaxonomyTierOnes.Any() || TaxonomyTierTwoImages.Any() || TaxonomyTierTwoPerformanceMeasures.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyTierTwo).Name, typeof(TaxonomyTierOne).Name, typeof(TaxonomyTierTwoImage).Name, typeof(TaxonomyTierTwoPerformanceMeasure).Name};

        [Key]
        public int TaxonomyTierTwoID { get; set; }
        public int TaxonomyTierThreeID { get; set; }
        public string TaxonomyTierTwoName { get; set; }
        [NotMapped]
        private string TaxonomyTierTwoDescription { get; set; }
        public HtmlString TaxonomyTierTwoDescriptionHtmlString
        { 
            get { return TaxonomyTierTwoDescription == null ? null : new HtmlString(TaxonomyTierTwoDescription); }
            set { TaxonomyTierTwoDescription = value == null ? null : value.ToString(); }
        }
        public int PrimaryKey { get { return TaxonomyTierTwoID; } set { TaxonomyTierTwoID = value; } }

        public virtual ICollection<TaxonomyTierOne> TaxonomyTierOnes { get; set; }
        public virtual ICollection<TaxonomyTierTwoImage> TaxonomyTierTwoImages { get; set; }
        public virtual ICollection<TaxonomyTierTwoPerformanceMeasure> TaxonomyTierTwoPerformanceMeasures { get; set; }
        public virtual TaxonomyTierThree TaxonomyTierThree { get; set; }

        public static class FieldLengths
        {
            public const int TaxonomyTierTwoName = 100;
        }
    }
}