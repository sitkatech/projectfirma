//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SustainabilityAspect]
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
    [Table("[dbo].[SustainabilityAspect]")]
    public partial class SustainabilityAspect : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SustainabilityAspect()
        {
            this.SustainabilityIndicators = new HashSet<SustainabilityIndicator>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityAspect(int sustainabilityAspectID, int sustainabilityPillarID, string sustainabilityAspectName, string displayName, int displayOrder, string keyImageFileName, string blurb, string outroText, string actionIntroText, string outcomeIntroText) : this()
        {
            this.SustainabilityAspectID = sustainabilityAspectID;
            this.SustainabilityPillarID = sustainabilityPillarID;
            this.SustainabilityAspectName = sustainabilityAspectName;
            this.DisplayName = displayName;
            this.DisplayOrder = displayOrder;
            this.KeyImageFileName = keyImageFileName;
            this.Blurb = blurb;
            this.OutroText = outroText;
            this.ActionIntroText = actionIntroText;
            this.OutcomeIntroText = outcomeIntroText;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SustainabilityAspect(int sustainabilityPillarID, string sustainabilityAspectName, string displayName, int displayOrder, string keyImageFileName, string blurb) : this()
        {
            // Mark this as a new object by setting primary key with special value
            SustainabilityAspectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SustainabilityPillarID = sustainabilityPillarID;
            this.SustainabilityAspectName = sustainabilityAspectName;
            this.DisplayName = displayName;
            this.DisplayOrder = displayOrder;
            this.KeyImageFileName = keyImageFileName;
            this.Blurb = blurb;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SustainabilityAspect(SustainabilityPillar sustainabilityPillar, string sustainabilityAspectName, string displayName, int displayOrder, string keyImageFileName, string blurb) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SustainabilityAspectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SustainabilityPillarID = sustainabilityPillar.SustainabilityPillarID;
            this.SustainabilityPillar = sustainabilityPillar;
            sustainabilityPillar.SustainabilityAspects.Add(this);
            this.SustainabilityAspectName = sustainabilityAspectName;
            this.DisplayName = displayName;
            this.DisplayOrder = displayOrder;
            this.KeyImageFileName = keyImageFileName;
            this.Blurb = blurb;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SustainabilityAspect CreateNewBlank(SustainabilityPillar sustainabilityPillar)
        {
            return new SustainabilityAspect(sustainabilityPillar, default(string), default(string), default(int), default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return SustainabilityIndicators.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SustainabilityAspect).Name, typeof(SustainabilityIndicator).Name};

        [Key]
        public int SustainabilityAspectID { get; set; }
        public int SustainabilityPillarID { get; set; }
        public string SustainabilityAspectName { get; set; }
        public string DisplayName { get; set; }
        public int DisplayOrder { get; set; }
        public string KeyImageFileName { get; set; }
        public string Blurb { get; set; }
        [NotMapped]
        private string OutroText { get; set; }
        public HtmlString OutroTextHtmlString
        { 
            get { return OutroText == null ? null : new HtmlString(OutroText); }
            set { OutroText = value == null ? null : value.ToString(); }
        }
        [NotMapped]
        private string ActionIntroText { get; set; }
        public HtmlString ActionIntroTextHtmlString
        { 
            get { return ActionIntroText == null ? null : new HtmlString(ActionIntroText); }
            set { ActionIntroText = value == null ? null : value.ToString(); }
        }
        [NotMapped]
        private string OutcomeIntroText { get; set; }
        public HtmlString OutcomeIntroTextHtmlString
        { 
            get { return OutcomeIntroText == null ? null : new HtmlString(OutcomeIntroText); }
            set { OutcomeIntroText = value == null ? null : value.ToString(); }
        }
        public int PrimaryKey { get { return SustainabilityAspectID; } set { SustainabilityAspectID = value; } }

        public virtual ICollection<SustainabilityIndicator> SustainabilityIndicators { get; set; }
        public virtual SustainabilityPillar SustainabilityPillar { get; set; }

        public static class FieldLengths
        {
            public const int SustainabilityAspectName = 50;
            public const int DisplayName = 50;
            public const int KeyImageFileName = 255;
            public const int Blurb = 1000;
        }
    }
}