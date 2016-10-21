//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vAccelaParcel]
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
    public partial class vAccelaParcel
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vAccelaParcel()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vAccelaParcel(string aPN, string parcelStatus, int parcelStatusID, int? ownerNumber, string ownerFullName, string ownerTitle, string ownerFirstName, string ownerMiddleName, string ownerLastName, string ownerAddress, string ownerCity, string ownerState, string ownerZip, DateTime? rEC_DATE, string rEC_FUL_NAM, string parcelAddress, string parcelCity, string parcelState, string parcelZip, string parcelSize, string jurisdiction, int jurisdictionID, string localPlan, string bMPStatus, string fireDistrict, string hRA) : this()
        {
            this.APN = aPN;
            this.ParcelStatus = parcelStatus;
            this.ParcelStatusID = parcelStatusID;
            this.OwnerNumber = ownerNumber;
            this.OwnerFullName = ownerFullName;
            this.OwnerTitle = ownerTitle;
            this.OwnerFirstName = ownerFirstName;
            this.OwnerMiddleName = ownerMiddleName;
            this.OwnerLastName = ownerLastName;
            this.OwnerAddress = ownerAddress;
            this.OwnerCity = ownerCity;
            this.OwnerState = ownerState;
            this.OwnerZip = ownerZip;
            this.REC_DATE = rEC_DATE;
            this.REC_FUL_NAM = rEC_FUL_NAM;
            this.ParcelAddress = parcelAddress;
            this.ParcelCity = parcelCity;
            this.ParcelState = parcelState;
            this.ParcelZip = parcelZip;
            this.ParcelSize = parcelSize;
            this.Jurisdiction = jurisdiction;
            this.JurisdictionID = jurisdictionID;
            this.LocalPlan = localPlan;
            this.BMPStatus = bMPStatus;
            this.FireDistrict = fireDistrict;
            this.HRA = hRA;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vAccelaParcel(vAccelaParcel vAccelaParcel) : this()
        {
            this.APN = vAccelaParcel.APN;
            this.ParcelStatus = vAccelaParcel.ParcelStatus;
            this.ParcelStatusID = vAccelaParcel.ParcelStatusID;
            this.OwnerNumber = vAccelaParcel.OwnerNumber;
            this.OwnerFullName = vAccelaParcel.OwnerFullName;
            this.OwnerTitle = vAccelaParcel.OwnerTitle;
            this.OwnerFirstName = vAccelaParcel.OwnerFirstName;
            this.OwnerMiddleName = vAccelaParcel.OwnerMiddleName;
            this.OwnerLastName = vAccelaParcel.OwnerLastName;
            this.OwnerAddress = vAccelaParcel.OwnerAddress;
            this.OwnerCity = vAccelaParcel.OwnerCity;
            this.OwnerState = vAccelaParcel.OwnerState;
            this.OwnerZip = vAccelaParcel.OwnerZip;
            this.REC_DATE = vAccelaParcel.REC_DATE;
            this.REC_FUL_NAM = vAccelaParcel.REC_FUL_NAM;
            this.ParcelAddress = vAccelaParcel.ParcelAddress;
            this.ParcelCity = vAccelaParcel.ParcelCity;
            this.ParcelState = vAccelaParcel.ParcelState;
            this.ParcelZip = vAccelaParcel.ParcelZip;
            this.ParcelSize = vAccelaParcel.ParcelSize;
            this.Jurisdiction = vAccelaParcel.Jurisdiction;
            this.JurisdictionID = vAccelaParcel.JurisdictionID;
            this.LocalPlan = vAccelaParcel.LocalPlan;
            this.BMPStatus = vAccelaParcel.BMPStatus;
            this.FireDistrict = vAccelaParcel.FireDistrict;
            this.HRA = vAccelaParcel.HRA;
            CallAfterConstructor(vAccelaParcel);
        }

        partial void CallAfterConstructor(vAccelaParcel vAccelaParcel);

        public string APN { get; set; }
        public string ParcelStatus { get; set; }
        public int ParcelStatusID { get; set; }
        public int? OwnerNumber { get; set; }
        public string OwnerFullName { get; set; }
        public string OwnerTitle { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerMiddleName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerCity { get; set; }
        public string OwnerState { get; set; }
        public string OwnerZip { get; set; }
        public DateTime? REC_DATE { get; set; }
        public string REC_FUL_NAM { get; set; }
        public string ParcelAddress { get; set; }
        public string ParcelCity { get; set; }
        public string ParcelState { get; set; }
        public string ParcelZip { get; set; }
        public string ParcelSize { get; set; }
        public string Jurisdiction { get; set; }
        public int JurisdictionID { get; set; }
        public string LocalPlan { get; set; }
        public string BMPStatus { get; set; }
        public string FireDistrict { get; set; }
        public string HRA { get; set; }
    }
}