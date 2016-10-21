//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LeadAgencyRightOfWayCoverage]
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
    [Table("[dbo].[LeadAgencyRightOfWayCoverage]")]
    public partial class LeadAgencyRightOfWayCoverage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected LeadAgencyRightOfWayCoverage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public LeadAgencyRightOfWayCoverage(int leadAgencyRightOfWayCoverageID, int leadAgencyID, int commodityID, int rightOfWayCoverageAmount, int? baileyRatingID, DateTime rightOfWayCoverageEffectiveDate, string rightOfWayCoverageNotes, DateTime lastUpdateDate, int lastUpdatePersonID) : this()
        {
            this.LeadAgencyRightOfWayCoverageID = leadAgencyRightOfWayCoverageID;
            this.LeadAgencyID = leadAgencyID;
            this.CommodityID = commodityID;
            this.RightOfWayCoverageAmount = rightOfWayCoverageAmount;
            this.BaileyRatingID = baileyRatingID;
            this.RightOfWayCoverageEffectiveDate = rightOfWayCoverageEffectiveDate;
            this.RightOfWayCoverageNotes = rightOfWayCoverageNotes;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public LeadAgencyRightOfWayCoverage(int leadAgencyID, int commodityID, int rightOfWayCoverageAmount, DateTime rightOfWayCoverageEffectiveDate, DateTime lastUpdateDate, int lastUpdatePersonID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            LeadAgencyRightOfWayCoverageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.LeadAgencyID = leadAgencyID;
            this.CommodityID = commodityID;
            this.RightOfWayCoverageAmount = rightOfWayCoverageAmount;
            this.RightOfWayCoverageEffectiveDate = rightOfWayCoverageEffectiveDate;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public LeadAgencyRightOfWayCoverage(LeadAgency leadAgency, Commodity commodity, int rightOfWayCoverageAmount, DateTime rightOfWayCoverageEffectiveDate, DateTime lastUpdateDate, Person lastUpdatePerson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.LeadAgencyRightOfWayCoverageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.LeadAgencyID = leadAgency.LeadAgencyID;
            this.LeadAgency = leadAgency;
            leadAgency.LeadAgencyRightOfWayCoverages.Add(this);
            this.CommodityID = commodity.CommodityID;
            this.RightOfWayCoverageAmount = rightOfWayCoverageAmount;
            this.RightOfWayCoverageEffectiveDate = rightOfWayCoverageEffectiveDate;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePerson.PersonID;
            this.LastUpdatePerson = lastUpdatePerson;
            lastUpdatePerson.LeadAgencyRightOfWayCoveragesWhereYouAreTheLastUpdatePerson.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static LeadAgencyRightOfWayCoverage CreateNewBlank(LeadAgency leadAgency, Commodity commodity, Person lastUpdatePerson)
        {
            return new LeadAgencyRightOfWayCoverage(leadAgency, commodity, default(int), default(DateTime), default(DateTime), lastUpdatePerson);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(LeadAgencyRightOfWayCoverage).Name};

        [Key]
        public int LeadAgencyRightOfWayCoverageID { get; set; }
        public int LeadAgencyID { get; set; }
        public int CommodityID { get; set; }
        public int RightOfWayCoverageAmount { get; set; }
        public int? BaileyRatingID { get; set; }
        public DateTime RightOfWayCoverageEffectiveDate { get; set; }
        public string RightOfWayCoverageNotes { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatePersonID { get; set; }
        public int PrimaryKey { get { return LeadAgencyRightOfWayCoverageID; } set { LeadAgencyRightOfWayCoverageID = value; } }

        public virtual LeadAgency LeadAgency { get; set; }
        public Commodity Commodity { get { return Commodity.AllLookupDictionary[CommodityID]; } }
        public BaileyRating BaileyRating { get { return BaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[BaileyRatingID.Value] : null; } }
        public virtual Person LastUpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int RightOfWayCoverageNotes = 500;
        }
    }
}