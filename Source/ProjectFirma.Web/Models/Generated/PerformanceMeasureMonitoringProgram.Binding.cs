//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureMonitoringProgram]
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
    [Table("[dbo].[PerformanceMeasureMonitoringProgram]")]
    public partial class PerformanceMeasureMonitoringProgram : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureMonitoringProgram()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureMonitoringProgram(int performanceMeasureMonitoringProgramID, int performanceMeasureID, int monitoringProgramID) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.PerformanceMeasureMonitoringProgramID = performanceMeasureMonitoringProgramID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.MonitoringProgramID = monitoringProgramID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureMonitoringProgram(int performanceMeasureID, int monitoringProgramID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureMonitoringProgramID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.MonitoringProgramID = monitoringProgramID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureMonitoringProgram(PerformanceMeasure performanceMeasure, MonitoringProgram monitoringProgram) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureMonitoringProgramID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.Tenant = HttpRequestStorage.Tenant;
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureMonitoringPrograms.Add(this);
            this.MonitoringProgramID = monitoringProgram.MonitoringProgramID;
            this.MonitoringProgram = monitoringProgram;
            monitoringProgram.PerformanceMeasureMonitoringPrograms.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureMonitoringProgram CreateNewBlank(PerformanceMeasure performanceMeasure, MonitoringProgram monitoringProgram)
        {
            return new PerformanceMeasureMonitoringProgram(performanceMeasure, monitoringProgram);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureMonitoringProgram).Name};

        [Key]
        public int PerformanceMeasureMonitoringProgramID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int MonitoringProgramID { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return PerformanceMeasureMonitoringProgramID; } set { PerformanceMeasureMonitoringProgramID = value; } }

        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual MonitoringProgram MonitoringProgram { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}