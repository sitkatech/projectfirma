//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReportTemplateModelType]
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public abstract partial class ReportTemplateModelType : IHavePrimaryKey
    {
        public static readonly ReportTemplateModelTypeSingleModel SingleModel = ReportTemplateModelTypeSingleModel.Instance;
        public static readonly ReportTemplateModelTypeMultipleModels MultipleModels = ReportTemplateModelTypeMultipleModels.Instance;

        public static readonly List<ReportTemplateModelType> All;
        public static readonly ReadOnlyDictionary<int, ReportTemplateModelType> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ReportTemplateModelType()
        {
            All = new List<ReportTemplateModelType> { SingleModel, MultipleModels };
            AllLookupDictionary = new ReadOnlyDictionary<int, ReportTemplateModelType>(All.ToDictionary(x => x.ReportTemplateModelTypeID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ReportTemplateModelType(int reportTemplateModelTypeID, string reportTemplateModelTypeName, string reportTemplateModelTypeDisplayName, string reportTemplateModelTypeDescription)
        {
            ReportTemplateModelTypeID = reportTemplateModelTypeID;
            ReportTemplateModelTypeName = reportTemplateModelTypeName;
            ReportTemplateModelTypeDisplayName = reportTemplateModelTypeDisplayName;
            ReportTemplateModelTypeDescription = reportTemplateModelTypeDescription;
        }

        [Key]
        public int ReportTemplateModelTypeID { get; private set; }
        public string ReportTemplateModelTypeName { get; private set; }
        public string ReportTemplateModelTypeDisplayName { get; private set; }
        public string ReportTemplateModelTypeDescription { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ReportTemplateModelTypeID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ReportTemplateModelType other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ReportTemplateModelTypeID == ReportTemplateModelTypeID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ReportTemplateModelType);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ReportTemplateModelTypeID;
        }

        public static bool operator ==(ReportTemplateModelType left, ReportTemplateModelType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReportTemplateModelType left, ReportTemplateModelType right)
        {
            return !Equals(left, right);
        }

        public ReportTemplateModelTypeEnum ToEnum { get { return (ReportTemplateModelTypeEnum)GetHashCode(); } }

        public static ReportTemplateModelType ToType(int enumValue)
        {
            return ToType((ReportTemplateModelTypeEnum)enumValue);
        }

        public static ReportTemplateModelType ToType(ReportTemplateModelTypeEnum enumValue)
        {
            switch (enumValue)
            {
                case ReportTemplateModelTypeEnum.MultipleModels:
                    return MultipleModels;
                case ReportTemplateModelTypeEnum.SingleModel:
                    return SingleModel;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ReportTemplateModelTypeEnum
    {
        SingleModel = 1,
        MultipleModels = 2
    }

    public partial class ReportTemplateModelTypeSingleModel : ReportTemplateModelType
    {
        private ReportTemplateModelTypeSingleModel(int reportTemplateModelTypeID, string reportTemplateModelTypeName, string reportTemplateModelTypeDisplayName, string reportTemplateModelTypeDescription) : base(reportTemplateModelTypeID, reportTemplateModelTypeName, reportTemplateModelTypeDisplayName, reportTemplateModelTypeDescription) {}
        public static readonly ReportTemplateModelTypeSingleModel Instance = new ReportTemplateModelTypeSingleModel(1, @"SingleModel", @"Single Model", @"Reports with the ""Single Model"" model type will be provided a single model per report. If multiple elements are selected and generated with this model type, the template will be run for each of the elements and then joined into a final word document.");
    }

    public partial class ReportTemplateModelTypeMultipleModels : ReportTemplateModelType
    {
        private ReportTemplateModelTypeMultipleModels(int reportTemplateModelTypeID, string reportTemplateModelTypeName, string reportTemplateModelTypeDisplayName, string reportTemplateModelTypeDescription) : base(reportTemplateModelTypeID, reportTemplateModelTypeName, reportTemplateModelTypeDisplayName, reportTemplateModelTypeDescription) {}
        public static readonly ReportTemplateModelTypeMultipleModels Instance = new ReportTemplateModelTypeMultipleModels(2, @"MultipleModels", @"Multiple Models", @"Reports with the ""Multiple Models"" model type will be provided with a list of the elements selected for the report. The template will be run once, but will have access to all of the models selected for iteration within it.");
    }
}