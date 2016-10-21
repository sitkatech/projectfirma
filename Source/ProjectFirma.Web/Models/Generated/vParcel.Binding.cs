//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vParcel]
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
    public partial class vParcel
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vParcel()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vParcel(int parcelID, string parcelNumber, string parcelNickname, int? parcelSize, string parcelNotes, string parcelStatusName, int organizationID, string organizationName, int? watershedID, string watershedName, string ownerName, int? parcelStreetNumber, string parcelAddress, string parcelStreetAddress, string parcelCity, string parcelState, string parcelZipCode, string localPlan, string bMPStatus, string fireDistrict, string hRA, bool autoImported) : this()
        {
            this.ParcelID = parcelID;
            this.ParcelNumber = parcelNumber;
            this.ParcelNickname = parcelNickname;
            this.ParcelSize = parcelSize;
            this.ParcelNotes = parcelNotes;
            this.ParcelStatusName = parcelStatusName;
            this.OrganizationID = organizationID;
            this.OrganizationName = organizationName;
            this.WatershedID = watershedID;
            this.WatershedName = watershedName;
            this.OwnerName = ownerName;
            this.ParcelStreetNumber = parcelStreetNumber;
            this.ParcelAddress = parcelAddress;
            this.ParcelStreetAddress = parcelStreetAddress;
            this.ParcelCity = parcelCity;
            this.ParcelState = parcelState;
            this.ParcelZipCode = parcelZipCode;
            this.LocalPlan = localPlan;
            this.BMPStatus = bMPStatus;
            this.FireDistrict = fireDistrict;
            this.HRA = hRA;
            this.AutoImported = autoImported;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vParcel(vParcel vParcel) : this()
        {
            this.ParcelID = vParcel.ParcelID;
            this.ParcelNumber = vParcel.ParcelNumber;
            this.ParcelNickname = vParcel.ParcelNickname;
            this.ParcelSize = vParcel.ParcelSize;
            this.ParcelNotes = vParcel.ParcelNotes;
            this.ParcelStatusName = vParcel.ParcelStatusName;
            this.OrganizationID = vParcel.OrganizationID;
            this.OrganizationName = vParcel.OrganizationName;
            this.WatershedID = vParcel.WatershedID;
            this.WatershedName = vParcel.WatershedName;
            this.OwnerName = vParcel.OwnerName;
            this.ParcelStreetNumber = vParcel.ParcelStreetNumber;
            this.ParcelAddress = vParcel.ParcelAddress;
            this.ParcelStreetAddress = vParcel.ParcelStreetAddress;
            this.ParcelCity = vParcel.ParcelCity;
            this.ParcelState = vParcel.ParcelState;
            this.ParcelZipCode = vParcel.ParcelZipCode;
            this.LocalPlan = vParcel.LocalPlan;
            this.BMPStatus = vParcel.BMPStatus;
            this.FireDistrict = vParcel.FireDistrict;
            this.HRA = vParcel.HRA;
            this.AutoImported = vParcel.AutoImported;
            CallAfterConstructor(vParcel);
        }

        partial void CallAfterConstructor(vParcel vParcel);

        public int ParcelID { get; set; }
        public string ParcelNumber { get; set; }
        public string ParcelNickname { get; set; }
        public int? ParcelSize { get; set; }
        public string ParcelNotes { get; set; }
        public string ParcelStatusName { get; set; }
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public int? WatershedID { get; set; }
        public string WatershedName { get; set; }
        public string OwnerName { get; set; }
        public int? ParcelStreetNumber { get; set; }
        public string ParcelAddress { get; set; }
        public string ParcelStreetAddress { get; set; }
        public string ParcelCity { get; set; }
        public string ParcelState { get; set; }
        public string ParcelZipCode { get; set; }
        public string LocalPlan { get; set; }
        public string BMPStatus { get; set; }
        public string FireDistrict { get; set; }
        public string HRA { get; set; }
        public bool AutoImported { get; set; }
    }
}