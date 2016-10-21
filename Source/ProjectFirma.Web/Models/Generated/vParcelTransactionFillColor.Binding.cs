//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vParcelTransactionFillColor]
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
    public partial class vParcelTransactionFillColor
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vParcelTransactionFillColor()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vParcelTransactionFillColor(int parcelID, DateTime? lastUpdateDate, string parcelFillColor) : this()
        {
            this.ParcelID = parcelID;
            this.LastUpdateDate = lastUpdateDate;
            this.ParcelFillColor = parcelFillColor;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vParcelTransactionFillColor(vParcelTransactionFillColor vParcelTransactionFillColor) : this()
        {
            this.ParcelID = vParcelTransactionFillColor.ParcelID;
            this.LastUpdateDate = vParcelTransactionFillColor.LastUpdateDate;
            this.ParcelFillColor = vParcelTransactionFillColor.ParcelFillColor;
            CallAfterConstructor(vParcelTransactionFillColor);
        }

        partial void CallAfterConstructor(vParcelTransactionFillColor vParcelTransactionFillColor);

        public int ParcelID { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string ParcelFillColor { get; set; }
    }
}