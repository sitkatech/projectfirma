//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureExpected]
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
    [Table("[dbo].[EIPPerformanceMeasureExpected]")]
    public partial class EIPPerformanceMeasureExpected : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EIPPerformanceMeasureExpected()
        {
            this.EIPPerformanceMeasureExpectedSubcategoryOptions = new HashSet<EIPPerformanceMeasureExpectedSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureExpected(int eIPPerformanceMeasureExpectedID, int projectID, int eIPPerformanceMeasureID, double? expectedValue) : this()
        {
            this.EIPPerformanceMeasureExpectedID = eIPPerformanceMeasureExpectedID;
            this.ProjectID = projectID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.ExpectedValue = expectedValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureExpected(int projectID, int eIPPerformanceMeasureID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            EIPPerformanceMeasureExpectedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EIPPerformanceMeasureExpected(Project project, EIPPerformanceMeasure eIPPerformanceMeasure) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EIPPerformanceMeasureExpectedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.EIPPerformanceMeasureExpecteds.Add(this);
            this.EIPPerformanceMeasureID = eIPPerformanceMeasure.EIPPerformanceMeasureID;
            this.EIPPerformanceMeasure = eIPPerformanceMeasure;
            eIPPerformanceMeasure.EIPPerformanceMeasureExpecteds.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EIPPerformanceMeasureExpected CreateNewBlank(Project project, EIPPerformanceMeasure eIPPerformanceMeasure)
        {
            return new EIPPerformanceMeasureExpected(project, eIPPerformanceMeasure);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return EIPPerformanceMeasureExpectedSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EIPPerformanceMeasureExpected).Name, typeof(EIPPerformanceMeasureExpectedSubcategoryOption).Name};

        [Key]
        public int EIPPerformanceMeasureExpectedID { get; set; }
        public int ProjectID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public double? ExpectedValue { get; set; }
        public int PrimaryKey { get { return EIPPerformanceMeasureExpectedID; } set { EIPPerformanceMeasureExpectedID = value; } }

        public virtual ICollection<EIPPerformanceMeasureExpectedSubcategoryOption> EIPPerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual Project Project { get; set; }
        public virtual EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}