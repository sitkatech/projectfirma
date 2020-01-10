//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReportTemplateModel]
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
    public abstract partial class ReportTemplateModel : IHavePrimaryKey
    {
        public static readonly ReportTemplateModelProject Project = ReportTemplateModelProject.Instance;

        public static readonly List<ReportTemplateModel> All;
        public static readonly ReadOnlyDictionary<int, ReportTemplateModel> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ReportTemplateModel()
        {
            All = new List<ReportTemplateModel> { Project };
            AllLookupDictionary = new ReadOnlyDictionary<int, ReportTemplateModel>(All.ToDictionary(x => x.ReportTemplateModelID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ReportTemplateModel(int reportTemplateModelID, string reportTemplateModelName, string reportTemplateModelDisplayName, string reportTemplateModelDescription)
        {
            ReportTemplateModelID = reportTemplateModelID;
            ReportTemplateModelName = reportTemplateModelName;
            ReportTemplateModelDisplayName = reportTemplateModelDisplayName;
            ReportTemplateModelDescription = reportTemplateModelDescription;
        }

        [Key]
        public int ReportTemplateModelID { get; private set; }
        public string ReportTemplateModelName { get; private set; }
        public string ReportTemplateModelDisplayName { get; private set; }
        public string ReportTemplateModelDescription { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ReportTemplateModelID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ReportTemplateModel other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ReportTemplateModelID == ReportTemplateModelID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ReportTemplateModel);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ReportTemplateModelID;
        }

        public static bool operator ==(ReportTemplateModel left, ReportTemplateModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReportTemplateModel left, ReportTemplateModel right)
        {
            return !Equals(left, right);
        }

        public ReportTemplateModelEnum ToEnum { get { return (ReportTemplateModelEnum)GetHashCode(); } }

        public static ReportTemplateModel ToType(int enumValue)
        {
            return ToType((ReportTemplateModelEnum)enumValue);
        }

        public static ReportTemplateModel ToType(ReportTemplateModelEnum enumValue)
        {
            switch (enumValue)
            {
                case ReportTemplateModelEnum.Project:
                    return Project;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ReportTemplateModelEnum
    {
        Project = 1
    }

    public partial class ReportTemplateModelProject : ReportTemplateModel
    {
        private ReportTemplateModelProject(int reportTemplateModelID, string reportTemplateModelName, string reportTemplateModelDisplayName, string reportTemplateModelDescription) : base(reportTemplateModelID, reportTemplateModelName, reportTemplateModelDisplayName, reportTemplateModelDescription) {}
        public static readonly ReportTemplateModelProject Instance = new ReportTemplateModelProject(1, @"Project", @"Project", @"Templates will be with the ""Project"" model.");
    }
}