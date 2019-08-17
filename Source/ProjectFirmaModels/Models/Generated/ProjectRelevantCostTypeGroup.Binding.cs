//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectRelevantCostTypeGroup]
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
    public abstract partial class ProjectRelevantCostTypeGroup : IHavePrimaryKey
    {
        public static readonly ProjectRelevantCostTypeGroupExpenditures Expenditures = ProjectRelevantCostTypeGroupExpenditures.Instance;
        public static readonly ProjectRelevantCostTypeGroupBudgets Budgets = ProjectRelevantCostTypeGroupBudgets.Instance;

        public static readonly List<ProjectRelevantCostTypeGroup> All;
        public static readonly ReadOnlyDictionary<int, ProjectRelevantCostTypeGroup> AllLookupDictionary;

        /// <summary>
        /// Static type constructor to coordinate static initialization order
        /// </summary>
        static ProjectRelevantCostTypeGroup()
        {
            All = new List<ProjectRelevantCostTypeGroup> { Expenditures, Budgets };
            AllLookupDictionary = new ReadOnlyDictionary<int, ProjectRelevantCostTypeGroup>(All.ToDictionary(x => x.ProjectRelevantCostTypeGroupID));
        }

        /// <summary>
        /// Protected constructor only for use in instantiating the set of static lookup values that match database
        /// </summary>
        protected ProjectRelevantCostTypeGroup(int projectRelevantCostTypeGroupID, string projectRelevantCostTypeGroupName, string projectRelevantCostTypeGroupDisplayName)
        {
            ProjectRelevantCostTypeGroupID = projectRelevantCostTypeGroupID;
            ProjectRelevantCostTypeGroupName = projectRelevantCostTypeGroupName;
            ProjectRelevantCostTypeGroupDisplayName = projectRelevantCostTypeGroupDisplayName;
        }

        [Key]
        public int ProjectRelevantCostTypeGroupID { get; private set; }
        public string ProjectRelevantCostTypeGroupName { get; private set; }
        public string ProjectRelevantCostTypeGroupDisplayName { get; private set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectRelevantCostTypeGroupID; } }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public bool Equals(ProjectRelevantCostTypeGroup other)
        {
            if (other == null)
            {
                return false;
            }
            return other.ProjectRelevantCostTypeGroupID == ProjectRelevantCostTypeGroupID;
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectRelevantCostTypeGroup);
        }

        /// <summary>
        /// Enum types are equal by primary key
        /// </summary>
        public override int GetHashCode()
        {
            return ProjectRelevantCostTypeGroupID;
        }

        public static bool operator ==(ProjectRelevantCostTypeGroup left, ProjectRelevantCostTypeGroup right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProjectRelevantCostTypeGroup left, ProjectRelevantCostTypeGroup right)
        {
            return !Equals(left, right);
        }

        public ProjectRelevantCostTypeGroupEnum ToEnum { get { return (ProjectRelevantCostTypeGroupEnum)GetHashCode(); } }

        public static ProjectRelevantCostTypeGroup ToType(int enumValue)
        {
            return ToType((ProjectRelevantCostTypeGroupEnum)enumValue);
        }

        public static ProjectRelevantCostTypeGroup ToType(ProjectRelevantCostTypeGroupEnum enumValue)
        {
            switch (enumValue)
            {
                case ProjectRelevantCostTypeGroupEnum.Budgets:
                    return Budgets;
                case ProjectRelevantCostTypeGroupEnum.Expenditures:
                    return Expenditures;
                default:
                    throw new ArgumentException(string.Format("Unable to map Enum: {0}", enumValue));
            }
        }
    }

    public enum ProjectRelevantCostTypeGroupEnum
    {
        Expenditures = 1,
        Budgets = 2
    }

    public partial class ProjectRelevantCostTypeGroupExpenditures : ProjectRelevantCostTypeGroup
    {
        private ProjectRelevantCostTypeGroupExpenditures(int projectRelevantCostTypeGroupID, string projectRelevantCostTypeGroupName, string projectRelevantCostTypeGroupDisplayName) : base(projectRelevantCostTypeGroupID, projectRelevantCostTypeGroupName, projectRelevantCostTypeGroupDisplayName) {}
        public static readonly ProjectRelevantCostTypeGroupExpenditures Instance = new ProjectRelevantCostTypeGroupExpenditures(1, @"Expenditures", @"Expenditures");
    }

    public partial class ProjectRelevantCostTypeGroupBudgets : ProjectRelevantCostTypeGroup
    {
        private ProjectRelevantCostTypeGroupBudgets(int projectRelevantCostTypeGroupID, string projectRelevantCostTypeGroupName, string projectRelevantCostTypeGroupDisplayName) : base(projectRelevantCostTypeGroupID, projectRelevantCostTypeGroupName, projectRelevantCostTypeGroupDisplayName) {}
        public static readonly ProjectRelevantCostTypeGroupBudgets Instance = new ProjectRelevantCostTypeGroupBudgets(2, @"Budgets", @"Budgets");
    }
}