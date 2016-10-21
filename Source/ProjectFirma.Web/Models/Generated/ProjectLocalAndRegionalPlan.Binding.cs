//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocalAndRegionalPlan]
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
    [Table("[dbo].[ProjectLocalAndRegionalPlan]")]
    public partial class ProjectLocalAndRegionalPlan : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectLocalAndRegionalPlan()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocalAndRegionalPlan(int projectLocalAndRegionalPlanID, int projectID, int localAndRegionalPlanID) : this()
        {
            this.ProjectLocalAndRegionalPlanID = projectLocalAndRegionalPlanID;
            this.ProjectID = projectID;
            this.LocalAndRegionalPlanID = localAndRegionalPlanID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocalAndRegionalPlan(int projectID, int localAndRegionalPlanID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectLocalAndRegionalPlanID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.LocalAndRegionalPlanID = localAndRegionalPlanID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectLocalAndRegionalPlan(Project project, LocalAndRegionalPlan localAndRegionalPlan) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocalAndRegionalPlanID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectLocalAndRegionalPlans.Add(this);
            this.LocalAndRegionalPlanID = localAndRegionalPlan.LocalAndRegionalPlanID;
            this.LocalAndRegionalPlan = localAndRegionalPlan;
            localAndRegionalPlan.ProjectLocalAndRegionalPlans.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectLocalAndRegionalPlan CreateNewBlank(Project project, LocalAndRegionalPlan localAndRegionalPlan)
        {
            return new ProjectLocalAndRegionalPlan(project, localAndRegionalPlan);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectLocalAndRegionalPlan).Name};

        [Key]
        public int ProjectLocalAndRegionalPlanID { get; set; }
        public int ProjectID { get; set; }
        public int LocalAndRegionalPlanID { get; set; }
        public int PrimaryKey { get { return ProjectLocalAndRegionalPlanID; } set { ProjectLocalAndRegionalPlanID = value; } }

        public virtual Project Project { get; set; }
        public virtual LocalAndRegionalPlan LocalAndRegionalPlan { get; set; }

        public static class FieldLengths
        {

        }
    }
}