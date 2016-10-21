//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSource]
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
    [Table("[dbo].[FundingSource]")]
    public partial class FundingSource : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FundingSource()
        {
            this.ProjectFundingSourceExpenditures = new HashSet<ProjectFundingSourceExpenditure>();
            this.ProjectFundingSourceExpenditureUpdates = new HashSet<ProjectFundingSourceExpenditureUpdate>();
            this.TransportationProjectBudgets = new HashSet<TransportationProjectBudget>();
            this.TransportationProjectBudgetUpdates = new HashSet<TransportationProjectBudgetUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSource(int fundingSourceID, int organizationID, string fundingSourceName, bool isActive, string fundingSourceDescription, bool isTransportationFundingSource) : this()
        {
            this.FundingSourceID = fundingSourceID;
            this.OrganizationID = organizationID;
            this.FundingSourceName = fundingSourceName;
            this.IsActive = isActive;
            this.FundingSourceDescription = fundingSourceDescription;
            this.IsTransportationFundingSource = isTransportationFundingSource;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSource(int organizationID, string fundingSourceName, bool isActive, bool isTransportationFundingSource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            FundingSourceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.FundingSourceName = fundingSourceName;
            this.IsActive = isActive;
            this.IsTransportationFundingSource = isTransportationFundingSource;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FundingSource(Organization organization, string fundingSourceName, bool isActive, bool isTransportationFundingSource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.FundingSources.Add(this);
            this.FundingSourceName = fundingSourceName;
            this.IsActive = isActive;
            this.IsTransportationFundingSource = isTransportationFundingSource;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FundingSource CreateNewBlank(Organization organization)
        {
            return new FundingSource(organization, default(string), default(bool), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectFundingSourceExpenditures.Any() || ProjectFundingSourceExpenditureUpdates.Any() || TransportationProjectBudgets.Any() || TransportationProjectBudgetUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FundingSource).Name, typeof(ProjectFundingSourceExpenditure).Name, typeof(ProjectFundingSourceExpenditureUpdate).Name, typeof(TransportationProjectBudget).Name, typeof(TransportationProjectBudgetUpdate).Name};

        [Key]
        public int FundingSourceID { get; set; }
        public int OrganizationID { get; set; }
        public string FundingSourceName { get; set; }
        public bool IsActive { get; set; }
        public string FundingSourceDescription { get; set; }
        public bool IsTransportationFundingSource { get; set; }
        public int PrimaryKey { get { return FundingSourceID; } set { FundingSourceID = value; } }

        public virtual ICollection<ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditureUpdate> ProjectFundingSourceExpenditureUpdates { get; set; }
        public virtual ICollection<TransportationProjectBudget> TransportationProjectBudgets { get; set; }
        public virtual ICollection<TransportationProjectBudgetUpdate> TransportationProjectBudgetUpdates { get; set; }
        public virtual Organization Organization { get; set; }

        public static class FieldLengths
        {
            public const int FundingSourceName = 200;
            public const int FundingSourceDescription = 500;
        }
    }
}