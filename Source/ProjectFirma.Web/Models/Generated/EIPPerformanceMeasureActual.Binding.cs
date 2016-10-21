//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureActual]
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
    [Table("[dbo].[EIPPerformanceMeasureActual]")]
    public partial class EIPPerformanceMeasureActual : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EIPPerformanceMeasureActual()
        {
            this.EIPPerformanceMeasureActualSubcategoryOptions = new HashSet<EIPPerformanceMeasureActualSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureActual(int eIPPerformanceMeasureActualID, int projectID, int eIPPerformanceMeasureID, int calendarYear, double actualValue) : this()
        {
            this.EIPPerformanceMeasureActualID = eIPPerformanceMeasureActualID;
            this.ProjectID = projectID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.CalendarYear = calendarYear;
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureActual(int projectID, int eIPPerformanceMeasureID, int calendarYear, double actualValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            EIPPerformanceMeasureActualID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.CalendarYear = calendarYear;
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EIPPerformanceMeasureActual(Project project, EIPPerformanceMeasure eIPPerformanceMeasure, int calendarYear, double actualValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EIPPerformanceMeasureActualID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.EIPPerformanceMeasureActuals.Add(this);
            this.EIPPerformanceMeasureID = eIPPerformanceMeasure.EIPPerformanceMeasureID;
            this.EIPPerformanceMeasure = eIPPerformanceMeasure;
            eIPPerformanceMeasure.EIPPerformanceMeasureActuals.Add(this);
            this.CalendarYear = calendarYear;
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EIPPerformanceMeasureActual CreateNewBlank(Project project, EIPPerformanceMeasure eIPPerformanceMeasure)
        {
            return new EIPPerformanceMeasureActual(project, eIPPerformanceMeasure, default(int), default(double));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return EIPPerformanceMeasureActualSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EIPPerformanceMeasureActual).Name, typeof(EIPPerformanceMeasureActualSubcategoryOption).Name};

        [Key]
        public int EIPPerformanceMeasureActualID { get; set; }
        public int ProjectID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public int CalendarYear { get; set; }
        public double ActualValue { get; set; }
        public int PrimaryKey { get { return EIPPerformanceMeasureActualID; } set { EIPPerformanceMeasureActualID = value; } }

        public virtual ICollection<EIPPerformanceMeasureActualSubcategoryOption> EIPPerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual Project Project { get; set; }
        public virtual EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}