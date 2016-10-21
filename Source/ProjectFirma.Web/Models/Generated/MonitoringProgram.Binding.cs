//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MonitoringProgram]
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
    [Table("[dbo].[MonitoringProgram]")]
    public partial class MonitoringProgram : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MonitoringProgram()
        {
            this.IndicatorMonitoringPrograms = new HashSet<IndicatorMonitoringProgram>();
            this.MonitoringProgramDocuments = new HashSet<MonitoringProgramDocument>();
            this.MonitoringProgramPartners = new HashSet<MonitoringProgramPartner>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MonitoringProgram(int monitoringProgramID, string monitoringProgramName, string monitoringApproach, string monitoringProgramUrl) : this()
        {
            this.MonitoringProgramID = monitoringProgramID;
            this.MonitoringProgramName = monitoringProgramName;
            this.MonitoringApproach = monitoringApproach;
            this.MonitoringProgramUrl = monitoringProgramUrl;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MonitoringProgram(string monitoringProgramName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            MonitoringProgramID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.MonitoringProgramName = monitoringProgramName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MonitoringProgram CreateNewBlank()
        {
            return new MonitoringProgram(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return IndicatorMonitoringPrograms.Any() || MonitoringProgramDocuments.Any() || MonitoringProgramPartners.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MonitoringProgram).Name, typeof(IndicatorMonitoringProgram).Name, typeof(MonitoringProgramDocument).Name, typeof(MonitoringProgramPartner).Name};

        [Key]
        public int MonitoringProgramID { get; set; }
        public string MonitoringProgramName { get; set; }
        public string MonitoringApproach { get; set; }
        public string MonitoringProgramUrl { get; set; }
        public int PrimaryKey { get { return MonitoringProgramID; } set { MonitoringProgramID = value; } }

        public virtual ICollection<IndicatorMonitoringProgram> IndicatorMonitoringPrograms { get; set; }
        public virtual ICollection<MonitoringProgramDocument> MonitoringProgramDocuments { get; set; }
        public virtual ICollection<MonitoringProgramPartner> MonitoringProgramPartners { get; set; }

        public static class FieldLengths
        {
            public const int MonitoringProgramName = 200;
            public const int MonitoringApproach = 1000;
            public const int MonitoringProgramUrl = 200;
        }
    }
}