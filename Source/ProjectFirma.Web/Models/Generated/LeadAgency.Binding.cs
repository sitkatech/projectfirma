//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LeadAgency]
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
    [Table("[dbo].[LeadAgency]")]
    public partial class LeadAgency : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected LeadAgency()
        {
            this.LandBanks = new HashSet<LandBank>();
            this.LeadAgencyRightOfWayCoverages = new HashSet<LeadAgencyRightOfWayCoverage>();
            this.LeadAgencyTransactionTypeCommodities = new HashSet<LeadAgencyTransactionTypeCommodity>();
            this.LeadAgencyTransactionTypeCommodityLogs = new HashSet<LeadAgencyTransactionTypeCommodityLog>();
            this.TdrTransactions = new HashSet<TdrTransaction>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public LeadAgency(int leadAgencyID, int organizationID, string leadAgencyAbbreviation, int sortOrder, bool canManageRightOfWayCoverage) : this()
        {
            this.LeadAgencyID = leadAgencyID;
            this.OrganizationID = organizationID;
            this.LeadAgencyAbbreviation = leadAgencyAbbreviation;
            this.SortOrder = sortOrder;
            this.CanManageRightOfWayCoverage = canManageRightOfWayCoverage;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public LeadAgency(int organizationID, string leadAgencyAbbreviation, int sortOrder, bool canManageRightOfWayCoverage) : this()
        {
            // Mark this as a new object by setting primary key with special value
            LeadAgencyID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.LeadAgencyAbbreviation = leadAgencyAbbreviation;
            this.SortOrder = sortOrder;
            this.CanManageRightOfWayCoverage = canManageRightOfWayCoverage;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public LeadAgency(Organization organization, string leadAgencyAbbreviation, int sortOrder, bool canManageRightOfWayCoverage) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.LeadAgencyID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            this.LeadAgencyAbbreviation = leadAgencyAbbreviation;
            this.SortOrder = sortOrder;
            this.CanManageRightOfWayCoverage = canManageRightOfWayCoverage;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static LeadAgency CreateNewBlank(Organization organization)
        {
            return new LeadAgency(organization, default(string), default(int), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return (LandBank != null) || LeadAgencyRightOfWayCoverages.Any() || LeadAgencyTransactionTypeCommodities.Any() || LeadAgencyTransactionTypeCommodityLogs.Any() || TdrTransactions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(LeadAgency).Name, typeof(LandBank).Name, typeof(LeadAgencyRightOfWayCoverage).Name, typeof(LeadAgencyTransactionTypeCommodity).Name, typeof(LeadAgencyTransactionTypeCommodityLog).Name, typeof(TdrTransaction).Name};

        [Key]
        public int LeadAgencyID { get; set; }
        public int OrganizationID { get; set; }
        public string LeadAgencyAbbreviation { get; set; }
        public int SortOrder { get; set; }
        public bool CanManageRightOfWayCoverage { get; set; }
        public int PrimaryKey { get { return LeadAgencyID; } set { LeadAgencyID = value; } }

        protected virtual ICollection<LandBank> LandBanks { get; set; }
        public LandBank LandBank { get { return LandBanks.SingleOrDefault(); } set { LandBanks = new List<LandBank>{value};} }
        public virtual ICollection<LeadAgencyRightOfWayCoverage> LeadAgencyRightOfWayCoverages { get; set; }
        public virtual ICollection<LeadAgencyTransactionTypeCommodity> LeadAgencyTransactionTypeCommodities { get; set; }
        public virtual ICollection<LeadAgencyTransactionTypeCommodityLog> LeadAgencyTransactionTypeCommodityLogs { get; set; }
        public virtual ICollection<TdrTransaction> TdrTransactions { get; set; }
        public virtual Organization Organization { get; set; }

        public static class FieldLengths
        {
            public const int LeadAgencyAbbreviation = 10;
        }
    }
}