//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationObjective]
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
    [Table("[dbo].[TransportationObjective]")]
    public partial class TransportationObjective : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TransportationObjective()
        {
            this.Projects = new HashSet<Project>();
            this.ProposedProjects = new HashSet<ProposedProject>();
            this.TransportationObjectiveImages = new HashSet<TransportationObjectiveImage>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationObjective(int transportationObjectiveID, int transportationStrategyID, string transportationObjectiveName, string transportationObjectiveDescription, int fundingTypeID, int? sortOrder) : this()
        {
            this.TransportationObjectiveID = transportationObjectiveID;
            this.TransportationStrategyID = transportationStrategyID;
            this.TransportationObjectiveName = transportationObjectiveName;
            this.TransportationObjectiveDescription = transportationObjectiveDescription;
            this.FundingTypeID = fundingTypeID;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationObjective(int transportationStrategyID, string transportationObjectiveName, int fundingTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TransportationObjectiveID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TransportationStrategyID = transportationStrategyID;
            this.TransportationObjectiveName = transportationObjectiveName;
            this.FundingTypeID = fundingTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TransportationObjective(TransportationStrategy transportationStrategy, string transportationObjectiveName, FundingType fundingType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TransportationObjectiveID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TransportationStrategyID = transportationStrategy.TransportationStrategyID;
            this.TransportationStrategy = transportationStrategy;
            transportationStrategy.TransportationObjectives.Add(this);
            this.TransportationObjectiveName = transportationObjectiveName;
            this.FundingTypeID = fundingType.FundingTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TransportationObjective CreateNewBlank(TransportationStrategy transportationStrategy, FundingType fundingType)
        {
            return new TransportationObjective(transportationStrategy, default(string), fundingType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Projects.Any() || ProposedProjects.Any() || TransportationObjectiveImages.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TransportationObjective).Name, typeof(Project).Name, typeof(ProposedProject).Name, typeof(TransportationObjectiveImage).Name};

        [Key]
        public int TransportationObjectiveID { get; set; }
        public int TransportationStrategyID { get; set; }
        public string TransportationObjectiveName { get; set; }
        [NotMapped]
        private string TransportationObjectiveDescription { get; set; }
        public HtmlString TransportationObjectiveDescriptionHtmlString
        { 
            get { return TransportationObjectiveDescription == null ? null : new HtmlString(TransportationObjectiveDescription); }
            set { TransportationObjectiveDescription = value == null ? null : value.ToString(); }
        }
        public int FundingTypeID { get; set; }
        public int? SortOrder { get; set; }
        public int PrimaryKey { get { return TransportationObjectiveID; } set { TransportationObjectiveID = value; } }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ProposedProject> ProposedProjects { get; set; }
        public virtual ICollection<TransportationObjectiveImage> TransportationObjectiveImages { get; set; }
        public virtual TransportationStrategy TransportationStrategy { get; set; }
        public FundingType FundingType { get { return FundingType.AllLookupDictionary[FundingTypeID]; } }

        public static class FieldLengths
        {
            public const int TransportationObjectiveName = 100;
        }
    }
}