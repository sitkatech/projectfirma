//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vParcelCurrentInventoryByCommodityBaileyRating]
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
    public partial class vParcelCurrentInventoryByCommodityBaileyRating
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vParcelCurrentInventoryByCommodityBaileyRating()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vParcelCurrentInventoryByCommodityBaileyRating(int parcelID, int? baileyRatingID, int commercialFloorArea, int coverageHard, int coverageSoft, int coveragePotential, int existingResidentialUnit, int personsAtOneTime, int residentialDevelopmentRight, int residentialAllocation, int residentialBonusUnit, int restorationCredit, int touristAccommodationUnit, int residentialFloorArea, int touristFloorArea) : this()
        {
            this.ParcelID = parcelID;
            this.BaileyRatingID = baileyRatingID;
            this.CommercialFloorArea = commercialFloorArea;
            this.CoverageHard = coverageHard;
            this.CoverageSoft = coverageSoft;
            this.CoveragePotential = coveragePotential;
            this.ExistingResidentialUnit = existingResidentialUnit;
            this.PersonsAtOneTime = personsAtOneTime;
            this.ResidentialDevelopmentRight = residentialDevelopmentRight;
            this.ResidentialAllocation = residentialAllocation;
            this.ResidentialBonusUnit = residentialBonusUnit;
            this.RestorationCredit = restorationCredit;
            this.TouristAccommodationUnit = touristAccommodationUnit;
            this.ResidentialFloorArea = residentialFloorArea;
            this.TouristFloorArea = touristFloorArea;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vParcelCurrentInventoryByCommodityBaileyRating(vParcelCurrentInventoryByCommodityBaileyRating vParcelCurrentInventoryByCommodityBaileyRating) : this()
        {
            this.ParcelID = vParcelCurrentInventoryByCommodityBaileyRating.ParcelID;
            this.BaileyRatingID = vParcelCurrentInventoryByCommodityBaileyRating.BaileyRatingID;
            this.CommercialFloorArea = vParcelCurrentInventoryByCommodityBaileyRating.CommercialFloorArea;
            this.CoverageHard = vParcelCurrentInventoryByCommodityBaileyRating.CoverageHard;
            this.CoverageSoft = vParcelCurrentInventoryByCommodityBaileyRating.CoverageSoft;
            this.CoveragePotential = vParcelCurrentInventoryByCommodityBaileyRating.CoveragePotential;
            this.ExistingResidentialUnit = vParcelCurrentInventoryByCommodityBaileyRating.ExistingResidentialUnit;
            this.PersonsAtOneTime = vParcelCurrentInventoryByCommodityBaileyRating.PersonsAtOneTime;
            this.ResidentialDevelopmentRight = vParcelCurrentInventoryByCommodityBaileyRating.ResidentialDevelopmentRight;
            this.ResidentialAllocation = vParcelCurrentInventoryByCommodityBaileyRating.ResidentialAllocation;
            this.ResidentialBonusUnit = vParcelCurrentInventoryByCommodityBaileyRating.ResidentialBonusUnit;
            this.RestorationCredit = vParcelCurrentInventoryByCommodityBaileyRating.RestorationCredit;
            this.TouristAccommodationUnit = vParcelCurrentInventoryByCommodityBaileyRating.TouristAccommodationUnit;
            this.ResidentialFloorArea = vParcelCurrentInventoryByCommodityBaileyRating.ResidentialFloorArea;
            this.TouristFloorArea = vParcelCurrentInventoryByCommodityBaileyRating.TouristFloorArea;
            CallAfterConstructor(vParcelCurrentInventoryByCommodityBaileyRating);
        }

        partial void CallAfterConstructor(vParcelCurrentInventoryByCommodityBaileyRating vParcelCurrentInventoryByCommodityBaileyRating);

        public int ParcelID { get; set; }
        public int? BaileyRatingID { get; set; }
        public int CommercialFloorArea { get; set; }
        public int CoverageHard { get; set; }
        public int CoverageSoft { get; set; }
        public int CoveragePotential { get; set; }
        public int ExistingResidentialUnit { get; set; }
        public int PersonsAtOneTime { get; set; }
        public int ResidentialDevelopmentRight { get; set; }
        public int ResidentialAllocation { get; set; }
        public int ResidentialBonusUnit { get; set; }
        public int RestorationCredit { get; set; }
        public int TouristAccommodationUnit { get; set; }
        public int ResidentialFloorArea { get; set; }
        public int TouristFloorArea { get; set; }
    }
}