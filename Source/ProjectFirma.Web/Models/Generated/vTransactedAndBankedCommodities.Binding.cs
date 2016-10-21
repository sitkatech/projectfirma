//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vTransactedAndBankedCommodities]
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class vTransactedAndBankedCommodities
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vTransactedAndBankedCommodities()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vTransactedAndBankedCommodities(int parcelID, int? transactionTypeID, int commodityID, int? baileyRatingID, int? quantity, DateTime lastUpdateDate, string parcelAction) : this()
        {
            this.ParcelID = parcelID;
            this.TransactionTypeID = transactionTypeID;
            this.CommodityID = commodityID;
            this.BaileyRatingID = baileyRatingID;
            this.Quantity = quantity;
            this.LastUpdateDate = lastUpdateDate;
            this.ParcelAction = parcelAction;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vTransactedAndBankedCommodities(vTransactedAndBankedCommodities vTransactedAndBankedCommodities) : this()
        {
            this.ParcelID = vTransactedAndBankedCommodities.ParcelID;
            this.TransactionTypeID = vTransactedAndBankedCommodities.TransactionTypeID;
            this.CommodityID = vTransactedAndBankedCommodities.CommodityID;
            this.BaileyRatingID = vTransactedAndBankedCommodities.BaileyRatingID;
            this.Quantity = vTransactedAndBankedCommodities.Quantity;
            this.LastUpdateDate = vTransactedAndBankedCommodities.LastUpdateDate;
            this.ParcelAction = vTransactedAndBankedCommodities.ParcelAction;
            CallAfterConstructor(vTransactedAndBankedCommodities);
        }

        partial void CallAfterConstructor(vTransactedAndBankedCommodities vTransactedAndBankedCommodities);

        public int ParcelID { get; set; }
        public int? TransactionTypeID { get; set; }
        public int CommodityID { get; set; }
        public int? BaileyRatingID { get; set; }
        public int? Quantity { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string ParcelAction { get; set; }
    }
}