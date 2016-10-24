//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectThresholdCategory]
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
    [Table("[dbo].[ProposedProjectThresholdCategory]")]
    public partial class ProposedProjectThresholdCategory : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProposedProjectThresholdCategory()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectThresholdCategory(int proposedProjectThresholdCategoryID, int proposedProjectID, int thresholdCategoryID, string proposedProjectThresholdCategoryNotes) : this()
        {
            this.ProposedProjectThresholdCategoryID = proposedProjectThresholdCategoryID;
            this.ProposedProjectID = proposedProjectID;
            this.ThresholdCategoryID = thresholdCategoryID;
            this.ProposedProjectThresholdCategoryNotes = proposedProjectThresholdCategoryNotes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectThresholdCategory(int proposedProjectID, int thresholdCategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProposedProjectThresholdCategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProposedProjectID = proposedProjectID;
            this.ThresholdCategoryID = thresholdCategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProposedProjectThresholdCategory(ProposedProject proposedProject, ThresholdCategory thresholdCategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectThresholdCategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.ProposedProjectThresholdCategories.Add(this);
            this.ThresholdCategoryID = thresholdCategory.ThresholdCategoryID;
            this.ThresholdCategory = thresholdCategory;
            thresholdCategory.ProposedProjectThresholdCategories.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProposedProjectThresholdCategory CreateNewBlank(ProposedProject proposedProject, ThresholdCategory thresholdCategory)
        {
            return new ProposedProjectThresholdCategory(proposedProject, thresholdCategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProposedProjectThresholdCategory).Name};

        [Key]
        public int ProposedProjectThresholdCategoryID { get; set; }
        public int ProposedProjectID { get; set; }
        public int ThresholdCategoryID { get; set; }
        public string ProposedProjectThresholdCategoryNotes { get; set; }
        public int PrimaryKey { get { return ProposedProjectThresholdCategoryID; } set { ProposedProjectThresholdCategoryID = value; } }

        public virtual ProposedProject ProposedProject { get; set; }
        public virtual ThresholdCategory ThresholdCategory { get; set; }

        public static class FieldLengths
        {
            public const int ProposedProjectThresholdCategoryNotes = 600;
        }
    }
}