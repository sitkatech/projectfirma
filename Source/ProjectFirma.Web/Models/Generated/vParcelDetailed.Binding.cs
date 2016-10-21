//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vParcelDetailed]
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
    public partial class vParcelDetailed
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vParcelDetailed()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vParcelDetailed(int parcelID, string parcelNumber, int coverage, int commercialFloorArea, int existingResidentialUnit, int residentialAllocation, int residentialBonusUnit, int residentialDevelopmentRight, int touristAccommodationUnit, string parcelNickname, int? parcelSize, string parcelNotes, string parcelStatusName, int organizationID, string organizationName, int? watershedID, string watershedName, string ownerName, string parcelStreetAddress, string parcelCity, string parcelState, string parcelZipCode, string localPlan, string bMPStatus, string fireDistrict, string hRA, bool autoImported, DateTime? lastUpdateDate, string landCapability) : this()
        {
            this.ParcelID = parcelID;
            this.ParcelNumber = parcelNumber;
            this.Coverage = coverage;
            this.CommercialFloorArea = commercialFloorArea;
            this.ExistingResidentialUnit = existingResidentialUnit;
            this.ResidentialAllocation = residentialAllocation;
            this.ResidentialBonusUnit = residentialBonusUnit;
            this.ResidentialDevelopmentRight = residentialDevelopmentRight;
            this.TouristAccommodationUnit = touristAccommodationUnit;
            this.ParcelNickname = parcelNickname;
            this.ParcelSize = parcelSize;
            this.ParcelNotes = parcelNotes;
            this.ParcelStatusName = parcelStatusName;
            this.OrganizationID = organizationID;
            this.OrganizationName = organizationName;
            this.WatershedID = watershedID;
            this.WatershedName = watershedName;
            this.OwnerName = ownerName;
            this.ParcelStreetAddress = parcelStreetAddress;
            this.ParcelCity = parcelCity;
            this.ParcelState = parcelState;
            this.ParcelZipCode = parcelZipCode;
            this.LocalPlan = localPlan;
            this.BMPStatus = bMPStatus;
            this.FireDistrict = fireDistrict;
            this.HRA = hRA;
            this.AutoImported = autoImported;
            this.LastUpdateDate = lastUpdateDate;
            this.LandCapability = landCapability;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vParcelDetailed(vParcelDetailed vParcelDetailed) : this()
        {
            this.ParcelID = vParcelDetailed.ParcelID;
            this.ParcelNumber = vParcelDetailed.ParcelNumber;
            this.Coverage = vParcelDetailed.Coverage;
            this.CommercialFloorArea = vParcelDetailed.CommercialFloorArea;
            this.ExistingResidentialUnit = vParcelDetailed.ExistingResidentialUnit;
            this.ResidentialAllocation = vParcelDetailed.ResidentialAllocation;
            this.ResidentialBonusUnit = vParcelDetailed.ResidentialBonusUnit;
            this.ResidentialDevelopmentRight = vParcelDetailed.ResidentialDevelopmentRight;
            this.TouristAccommodationUnit = vParcelDetailed.TouristAccommodationUnit;
            this.ParcelNickname = vParcelDetailed.ParcelNickname;
            this.ParcelSize = vParcelDetailed.ParcelSize;
            this.ParcelNotes = vParcelDetailed.ParcelNotes;
            this.ParcelStatusName = vParcelDetailed.ParcelStatusName;
            this.OrganizationID = vParcelDetailed.OrganizationID;
            this.OrganizationName = vParcelDetailed.OrganizationName;
            this.WatershedID = vParcelDetailed.WatershedID;
            this.WatershedName = vParcelDetailed.WatershedName;
            this.OwnerName = vParcelDetailed.OwnerName;
            this.ParcelStreetAddress = vParcelDetailed.ParcelStreetAddress;
            this.ParcelCity = vParcelDetailed.ParcelCity;
            this.ParcelState = vParcelDetailed.ParcelState;
            this.ParcelZipCode = vParcelDetailed.ParcelZipCode;
            this.LocalPlan = vParcelDetailed.LocalPlan;
            this.BMPStatus = vParcelDetailed.BMPStatus;
            this.FireDistrict = vParcelDetailed.FireDistrict;
            this.HRA = vParcelDetailed.HRA;
            this.AutoImported = vParcelDetailed.AutoImported;
            this.LastUpdateDate = vParcelDetailed.LastUpdateDate;
            this.LandCapability = vParcelDetailed.LandCapability;
            CallAfterConstructor(vParcelDetailed);
        }

        partial void CallAfterConstructor(vParcelDetailed vParcelDetailed);

        public int ParcelID { get; set; }
        public string ParcelNumber { get; set; }
        public int Coverage { get; set; }
        public int CommercialFloorArea { get; set; }
        public int ExistingResidentialUnit { get; set; }
        public int ResidentialAllocation { get; set; }
        public int ResidentialBonusUnit { get; set; }
        public int ResidentialDevelopmentRight { get; set; }
        public int TouristAccommodationUnit { get; set; }
        public string ParcelNickname { get; set; }
        public int? ParcelSize { get; set; }
        public string ParcelNotes { get; set; }
        public string ParcelStatusName { get; set; }
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public int? WatershedID { get; set; }
        public string WatershedName { get; set; }
        public string OwnerName { get; set; }
        public string ParcelStreetAddress { get; set; }
        public string ParcelCity { get; set; }
        public string ParcelState { get; set; }
        public string ParcelZipCode { get; set; }
        public string LocalPlan { get; set; }
        public string BMPStatus { get; set; }
        public string FireDistrict { get; set; }
        public string HRA { get; set; }
        public bool AutoImported { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LandCapability { get; set; }
    }
}