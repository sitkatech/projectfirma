//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorMonitoringProgram]
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
    [Table("[dbo].[IndicatorMonitoringProgram]")]
    public partial class IndicatorMonitoringProgram : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected IndicatorMonitoringProgram()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorMonitoringProgram(int indicatorMonitoringProgramID, int indicatorID, int monitoringProgramID) : this()
        {
            this.IndicatorMonitoringProgramID = indicatorMonitoringProgramID;
            this.IndicatorID = indicatorID;
            this.MonitoringProgramID = monitoringProgramID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorMonitoringProgram(int indicatorID, int monitoringProgramID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            IndicatorMonitoringProgramID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IndicatorID = indicatorID;
            this.MonitoringProgramID = monitoringProgramID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public IndicatorMonitoringProgram(Indicator indicator, MonitoringProgram monitoringProgram) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.IndicatorMonitoringProgramID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IndicatorID = indicator.IndicatorID;
            this.Indicator = indicator;
            indicator.IndicatorMonitoringPrograms.Add(this);
            this.MonitoringProgramID = monitoringProgram.MonitoringProgramID;
            this.MonitoringProgram = monitoringProgram;
            monitoringProgram.IndicatorMonitoringPrograms.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static IndicatorMonitoringProgram CreateNewBlank(Indicator indicator, MonitoringProgram monitoringProgram)
        {
            return new IndicatorMonitoringProgram(indicator, monitoringProgram);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(IndicatorMonitoringProgram).Name};

        [Key]
        public int IndicatorMonitoringProgramID { get; set; }
        public int IndicatorID { get; set; }
        public int MonitoringProgramID { get; set; }
        public int PrimaryKey { get { return IndicatorMonitoringProgramID; } set { IndicatorMonitoringProgramID = value; } }

        public virtual Indicator Indicator { get; set; }
        public virtual MonitoringProgram MonitoringProgram { get; set; }

        public static class FieldLengths
        {

        }
    }
}