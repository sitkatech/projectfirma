//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityPillar]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[SustainabilityPillar]")]
    public partial class SustainabilityPillar : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SustainabilityPillar()
        {
            this.SustainabilityAspects = new HashSet<SustainabilityAspect>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityPillar(int sustainabilityPillarID, string sustainabilityPillarName, string pillarAdjective, int displayOrder, string keyImageFileName, string keyColor) : this()
        {
            this.SustainabilityPillarID = sustainabilityPillarID;
            this.SustainabilityPillarName = sustainabilityPillarName;
            this.PillarAdjective = pillarAdjective;
            this.DisplayOrder = displayOrder;
            this.KeyImageFileName = keyImageFileName;
            this.KeyColor = keyColor;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityPillar(string sustainabilityPillarName, string pillarAdjective, int displayOrder, string keyImageFileName, string keyColor) : this()
        {
            // Mark this as a new object by setting primary key with special value
            SustainabilityPillarID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SustainabilityPillarName = sustainabilityPillarName;
            this.PillarAdjective = pillarAdjective;
            this.DisplayOrder = displayOrder;
            this.KeyImageFileName = keyImageFileName;
            this.KeyColor = keyColor;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SustainabilityPillar CreateNewBlank()
        {
            return new SustainabilityPillar(default(string), default(string), default(int), default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return SustainabilityAspects.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SustainabilityPillar).Name, typeof(SustainabilityAspect).Name};

        [Key]
        public int SustainabilityPillarID { get; set; }
        public string SustainabilityPillarName { get; set; }
        public string PillarAdjective { get; set; }
        public int DisplayOrder { get; set; }
        public string KeyImageFileName { get; set; }
        public string KeyColor { get; set; }
        public int PrimaryKey { get { return SustainabilityPillarID; } set { SustainabilityPillarID = value; } }

        public virtual ICollection<SustainabilityAspect> SustainabilityAspects { get; set; }

        public static class FieldLengths
        {
            public const int SustainabilityPillarName = 50;
            public const int PillarAdjective = 50;
            public const int KeyImageFileName = 255;
            public const int KeyColor = 20;
        }
    }
}