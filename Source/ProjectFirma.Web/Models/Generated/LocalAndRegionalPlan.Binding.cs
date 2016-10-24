//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LocalAndRegionalPlan]
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
    [Table("[dbo].[LocalAndRegionalPlan]")]
    public partial class LocalAndRegionalPlan : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected LocalAndRegionalPlan()
        {
            this.ProjectLocalAndRegionalPlans = new HashSet<ProjectLocalAndRegionalPlan>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public LocalAndRegionalPlan(int localAndRegionalPlanID, string localAndRegionalPlanName, string planDocumentUrl, string planDocumentLinkText, bool isTransportationPlan) : this()
        {
            this.LocalAndRegionalPlanID = localAndRegionalPlanID;
            this.LocalAndRegionalPlanName = localAndRegionalPlanName;
            this.PlanDocumentUrl = planDocumentUrl;
            this.PlanDocumentLinkText = planDocumentLinkText;
            this.IsTransportationPlan = isTransportationPlan;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public LocalAndRegionalPlan(string localAndRegionalPlanName, bool isTransportationPlan) : this()
        {
            // Mark this as a new object by setting primary key with special value
            LocalAndRegionalPlanID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.LocalAndRegionalPlanName = localAndRegionalPlanName;
            this.IsTransportationPlan = isTransportationPlan;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static LocalAndRegionalPlan CreateNewBlank()
        {
            return new LocalAndRegionalPlan(default(string), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectLocalAndRegionalPlans.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(LocalAndRegionalPlan).Name, typeof(ProjectLocalAndRegionalPlan).Name};

        [Key]
        public int LocalAndRegionalPlanID { get; set; }
        public string LocalAndRegionalPlanName { get; set; }
        public string PlanDocumentUrl { get; set; }
        public string PlanDocumentLinkText { get; set; }
        public bool IsTransportationPlan { get; set; }
        public int PrimaryKey { get { return LocalAndRegionalPlanID; } set { LocalAndRegionalPlanID = value; } }

        public virtual ICollection<ProjectLocalAndRegionalPlan> ProjectLocalAndRegionalPlans { get; set; }

        public static class FieldLengths
        {
            public const int LocalAndRegionalPlanName = 100;
            public const int PlanDocumentUrl = 300;
            public const int PlanDocumentLinkText = 300;
        }
    }
}