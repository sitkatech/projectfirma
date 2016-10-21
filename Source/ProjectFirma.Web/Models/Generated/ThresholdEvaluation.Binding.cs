//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdEvaluation]
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
    [Table("[dbo].[ThresholdEvaluation]")]
    public partial class ThresholdEvaluation : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdEvaluation()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdEvaluation(int thresholdEvaluationID, int thresholdEvaluationPeriodID, int thresholdIndicatorID, int? thresholdEvaluationStatusTypeID, int? thresholdEvaluationTrendTypeID, int? thresholdEvaluationConfidenceTypeID, int? thresholdEvaluationManagementStatusTypeID, string statusRationale, string trendRationale, string confidenceStatus, string confidenceTrend, string confidenceOverall, string programsAndActionsImplementedToImproveConditions, string effectivenessOfProgramsAndActions, string interimTarget, string targetAttainmentDate, string analyticApproachRecommendation, string monitoringApproachRecommendation, string modificationOfTheThresholdStandardOrIndicator, string attainOrMaintainThreshold, int? mapFileResourceID, string mapCaption, int? historicEvaluationPdfFileResourceID) : this()
        {
            this.ThresholdEvaluationID = thresholdEvaluationID;
            this.ThresholdEvaluationPeriodID = thresholdEvaluationPeriodID;
            this.ThresholdIndicatorID = thresholdIndicatorID;
            this.ThresholdEvaluationStatusTypeID = thresholdEvaluationStatusTypeID;
            this.ThresholdEvaluationTrendTypeID = thresholdEvaluationTrendTypeID;
            this.ThresholdEvaluationConfidenceTypeID = thresholdEvaluationConfidenceTypeID;
            this.ThresholdEvaluationManagementStatusTypeID = thresholdEvaluationManagementStatusTypeID;
            this.StatusRationale = statusRationale;
            this.TrendRationale = trendRationale;
            this.ConfidenceStatus = confidenceStatus;
            this.ConfidenceTrend = confidenceTrend;
            this.ConfidenceOverall = confidenceOverall;
            this.ProgramsAndActionsImplementedToImproveConditions = programsAndActionsImplementedToImproveConditions;
            this.EffectivenessOfProgramsAndActions = effectivenessOfProgramsAndActions;
            this.InterimTarget = interimTarget;
            this.TargetAttainmentDate = targetAttainmentDate;
            this.AnalyticApproachRecommendation = analyticApproachRecommendation;
            this.MonitoringApproachRecommendation = monitoringApproachRecommendation;
            this.ModificationOfTheThresholdStandardOrIndicator = modificationOfTheThresholdStandardOrIndicator;
            this.AttainOrMaintainThreshold = attainOrMaintainThreshold;
            this.MapFileResourceID = mapFileResourceID;
            this.MapCaption = mapCaption;
            this.HistoricEvaluationPdfFileResourceID = historicEvaluationPdfFileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdEvaluation(int thresholdEvaluationPeriodID, int thresholdIndicatorID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdEvaluationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ThresholdEvaluationPeriodID = thresholdEvaluationPeriodID;
            this.ThresholdIndicatorID = thresholdIndicatorID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ThresholdEvaluation(ThresholdEvaluationPeriod thresholdEvaluationPeriod, ThresholdIndicator thresholdIndicator) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ThresholdEvaluationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ThresholdEvaluationPeriodID = thresholdEvaluationPeriod.ThresholdEvaluationPeriodID;
            this.ThresholdEvaluationPeriod = thresholdEvaluationPeriod;
            thresholdEvaluationPeriod.ThresholdEvaluations.Add(this);
            this.ThresholdIndicatorID = thresholdIndicator.ThresholdIndicatorID;
            this.ThresholdIndicator = thresholdIndicator;
            thresholdIndicator.ThresholdEvaluations.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdEvaluation CreateNewBlank(ThresholdEvaluationPeriod thresholdEvaluationPeriod, ThresholdIndicator thresholdIndicator)
        {
            return new ThresholdEvaluation(thresholdEvaluationPeriod, thresholdIndicator);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdEvaluation).Name};

        [Key]
        public int ThresholdEvaluationID { get; set; }
        public int ThresholdEvaluationPeriodID { get; set; }
        public int ThresholdIndicatorID { get; set; }
        public int? ThresholdEvaluationStatusTypeID { get; set; }
        public int? ThresholdEvaluationTrendTypeID { get; set; }
        public int? ThresholdEvaluationConfidenceTypeID { get; set; }
        public int? ThresholdEvaluationManagementStatusTypeID { get; set; }
        public string StatusRationale { get; set; }
        public string TrendRationale { get; set; }
        public string ConfidenceStatus { get; set; }
        public string ConfidenceTrend { get; set; }
        public string ConfidenceOverall { get; set; }
        public string ProgramsAndActionsImplementedToImproveConditions { get; set; }
        public string EffectivenessOfProgramsAndActions { get; set; }
        public string InterimTarget { get; set; }
        public string TargetAttainmentDate { get; set; }
        public string AnalyticApproachRecommendation { get; set; }
        public string MonitoringApproachRecommendation { get; set; }
        public string ModificationOfTheThresholdStandardOrIndicator { get; set; }
        public string AttainOrMaintainThreshold { get; set; }
        public int? MapFileResourceID { get; set; }
        public string MapCaption { get; set; }
        public int? HistoricEvaluationPdfFileResourceID { get; set; }
        public int PrimaryKey { get { return ThresholdEvaluationID; } set { ThresholdEvaluationID = value; } }

        public virtual ThresholdEvaluationPeriod ThresholdEvaluationPeriod { get; set; }
        public virtual ThresholdIndicator ThresholdIndicator { get; set; }
        public ThresholdEvaluationStatusType ThresholdEvaluationStatusType { get { return ThresholdEvaluationStatusTypeID.HasValue ? ThresholdEvaluationStatusType.AllLookupDictionary[ThresholdEvaluationStatusTypeID.Value] : null; } }
        public ThresholdEvaluationTrendType ThresholdEvaluationTrendType { get { return ThresholdEvaluationTrendTypeID.HasValue ? ThresholdEvaluationTrendType.AllLookupDictionary[ThresholdEvaluationTrendTypeID.Value] : null; } }
        public ThresholdEvaluationConfidenceType ThresholdEvaluationConfidenceType { get { return ThresholdEvaluationConfidenceTypeID.HasValue ? ThresholdEvaluationConfidenceType.AllLookupDictionary[ThresholdEvaluationConfidenceTypeID.Value] : null; } }
        public ThresholdEvaluationManagementStatusType ThresholdEvaluationManagementStatusType { get { return ThresholdEvaluationManagementStatusTypeID.HasValue ? ThresholdEvaluationManagementStatusType.AllLookupDictionary[ThresholdEvaluationManagementStatusTypeID.Value] : null; } }
        public virtual FileResource HistoricEvaluationPdfFileResource { get; set; }
        public virtual FileResource MapFileResource { get; set; }

        public static class FieldLengths
        {
            public const int StatusRationale = 4000;
            public const int TrendRationale = 4000;
            public const int ConfidenceStatus = 4000;
            public const int ConfidenceTrend = 4000;
            public const int ConfidenceOverall = 4000;
            public const int ProgramsAndActionsImplementedToImproveConditions = 8000;
            public const int EffectivenessOfProgramsAndActions = 8000;
            public const int InterimTarget = 4000;
            public const int TargetAttainmentDate = 4000;
            public const int AnalyticApproachRecommendation = 4000;
            public const int MonitoringApproachRecommendation = 4000;
            public const int ModificationOfTheThresholdStandardOrIndicator = 4000;
            public const int AttainOrMaintainThreshold = 4000;
            public const int MapCaption = 2000;
        }
    }
}