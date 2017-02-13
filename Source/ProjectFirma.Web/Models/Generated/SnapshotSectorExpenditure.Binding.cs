//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotSectorExpenditure]
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
    [Table("[dbo].[SnapshotSectorExpenditure]")]
    public partial class SnapshotSectorExpenditure : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SnapshotSectorExpenditure()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotSectorExpenditure(int snapshotSectorExpenditureID, int snapshotID, int sectorID, int calendarYear, decimal expenditureAmount) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.SnapshotSectorExpenditureID = snapshotSectorExpenditureID;
            this.SnapshotID = snapshotID;
            this.SectorID = sectorID;
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotSectorExpenditure(int snapshotID, int sectorID, int calendarYear, decimal expenditureAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotSectorExpenditureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.SnapshotID = snapshotID;
            this.SectorID = sectorID;
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SnapshotSectorExpenditure(Snapshot snapshot, Sector sector, int calendarYear, decimal expenditureAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotSectorExpenditureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.SnapshotID = snapshot.SnapshotID;
            this.Snapshot = snapshot;
            snapshot.SnapshotSectorExpenditures.Add(this);
            this.SectorID = sector.SectorID;
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SnapshotSectorExpenditure CreateNewBlank(Snapshot snapshot, Sector sector)
        {
            return new SnapshotSectorExpenditure(snapshot, sector, default(int), default(decimal));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SnapshotSectorExpenditure).Name};

        [Key]
        public int SnapshotSectorExpenditureID { get; set; }
        public int TenantID { get; private set; }
        public int SnapshotID { get; set; }
        public int SectorID { get; set; }
        public int CalendarYear { get; set; }
        public decimal ExpenditureAmount { get; set; }
        public int PrimaryKey { get { return SnapshotSectorExpenditureID; } set { SnapshotSectorExpenditureID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Snapshot Snapshot { get; set; }
        public Sector Sector { get { return Sector.AllLookupDictionary[SectorID]; } }

        public static class FieldLengths
        {

        }
    }
}