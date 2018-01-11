//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotOrganizationTypeExpenditure]
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
    [Table("[dbo].[SnapshotOrganizationTypeExpenditure]")]
    public partial class SnapshotOrganizationTypeExpenditure : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SnapshotOrganizationTypeExpenditure()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotOrganizationTypeExpenditure(int snapshotOrganizationTypeExpenditureID, int snapshotID, int calendarYear, decimal expenditureAmount, int organizationTypeID) : this()
        {
            this.SnapshotOrganizationTypeExpenditureID = snapshotOrganizationTypeExpenditureID;
            this.SnapshotID = snapshotID;
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
            this.OrganizationTypeID = organizationTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotOrganizationTypeExpenditure(int snapshotID, int calendarYear, decimal expenditureAmount, int organizationTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotOrganizationTypeExpenditureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SnapshotID = snapshotID;
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
            this.OrganizationTypeID = organizationTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SnapshotOrganizationTypeExpenditure(Snapshot snapshot, int calendarYear, decimal expenditureAmount, OrganizationType organizationType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotOrganizationTypeExpenditureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SnapshotID = snapshot.SnapshotID;
            this.Snapshot = snapshot;
            snapshot.SnapshotOrganizationTypeExpenditures.Add(this);
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
            this.OrganizationTypeID = organizationType.OrganizationTypeID;
            this.OrganizationType = organizationType;
            organizationType.SnapshotOrganizationTypeExpenditures.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SnapshotOrganizationTypeExpenditure CreateNewBlank(Snapshot snapshot, OrganizationType organizationType)
        {
            return new SnapshotOrganizationTypeExpenditure(snapshot, default(int), default(decimal), organizationType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SnapshotOrganizationTypeExpenditure).Name};

        [Key]
        public int SnapshotOrganizationTypeExpenditureID { get; set; }
        public int TenantID { get; private set; }
        public int SnapshotID { get; set; }
        public int CalendarYear { get; set; }
        public decimal ExpenditureAmount { get; set; }
        public int OrganizationTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return SnapshotOrganizationTypeExpenditureID; } set { SnapshotOrganizationTypeExpenditureID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Snapshot Snapshot { get; set; }
        public virtual OrganizationType OrganizationType { get; set; }

        public static class FieldLengths
        {

        }
    }
}