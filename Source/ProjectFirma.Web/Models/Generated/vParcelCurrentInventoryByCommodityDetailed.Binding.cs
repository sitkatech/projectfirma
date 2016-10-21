//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vParcelCurrentInventoryByCommodityDetailed]
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
    public partial class vParcelCurrentInventoryByCommodityDetailed
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vParcelCurrentInventoryByCommodityDetailed()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vParcelCurrentInventoryByCommodityDetailed(int parcelID, string parcelNumber, string parcelNickname, string parcelStatusName, int? parcelSize, int? baileyRatingID, short? iPESScore, int? squareFootage, int coverageHard, int coveragePotential, int coverageSoft, int commercialFloorArea, int existingResidentialUnit, int residentialAllocation, int residentialBonusUnit, int residentialFloorArea, int residentialDevelopmentRight, int touristAccommodationUnit, int touristFloorArea, bool autoImported) : this()
        {
            this.ParcelID = parcelID;
            this.ParcelNumber = parcelNumber;
            this.ParcelNickname = parcelNickname;
            this.ParcelStatusName = parcelStatusName;
            this.ParcelSize = parcelSize;
            this.BaileyRatingID = baileyRatingID;
            this.IPESScore = iPESScore;
            this.SquareFootage = squareFootage;
            this.CoverageHard = coverageHard;
            this.CoveragePotential = coveragePotential;
            this.CoverageSoft = coverageSoft;
            this.CommercialFloorArea = commercialFloorArea;
            this.ExistingResidentialUnit = existingResidentialUnit;
            this.ResidentialAllocation = residentialAllocation;
            this.ResidentialBonusUnit = residentialBonusUnit;
            this.ResidentialFloorArea = residentialFloorArea;
            this.ResidentialDevelopmentRight = residentialDevelopmentRight;
            this.TouristAccommodationUnit = touristAccommodationUnit;
            this.TouristFloorArea = touristFloorArea;
            this.AutoImported = autoImported;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vParcelCurrentInventoryByCommodityDetailed(vParcelCurrentInventoryByCommodityDetailed vParcelCurrentInventoryByCommodityDetailed) : this()
        {
            this.ParcelID = vParcelCurrentInventoryByCommodityDetailed.ParcelID;
            this.ParcelNumber = vParcelCurrentInventoryByCommodityDetailed.ParcelNumber;
            this.ParcelNickname = vParcelCurrentInventoryByCommodityDetailed.ParcelNickname;
            this.ParcelStatusName = vParcelCurrentInventoryByCommodityDetailed.ParcelStatusName;
            this.ParcelSize = vParcelCurrentInventoryByCommodityDetailed.ParcelSize;
            this.BaileyRatingID = vParcelCurrentInventoryByCommodityDetailed.BaileyRatingID;
            this.IPESScore = vParcelCurrentInventoryByCommodityDetailed.IPESScore;
            this.SquareFootage = vParcelCurrentInventoryByCommodityDetailed.SquareFootage;
            this.CoverageHard = vParcelCurrentInventoryByCommodityDetailed.CoverageHard;
            this.CoveragePotential = vParcelCurrentInventoryByCommodityDetailed.CoveragePotential;
            this.CoverageSoft = vParcelCurrentInventoryByCommodityDetailed.CoverageSoft;
            this.CommercialFloorArea = vParcelCurrentInventoryByCommodityDetailed.CommercialFloorArea;
            this.ExistingResidentialUnit = vParcelCurrentInventoryByCommodityDetailed.ExistingResidentialUnit;
            this.ResidentialAllocation = vParcelCurrentInventoryByCommodityDetailed.ResidentialAllocation;
            this.ResidentialBonusUnit = vParcelCurrentInventoryByCommodityDetailed.ResidentialBonusUnit;
            this.ResidentialFloorArea = vParcelCurrentInventoryByCommodityDetailed.ResidentialFloorArea;
            this.ResidentialDevelopmentRight = vParcelCurrentInventoryByCommodityDetailed.ResidentialDevelopmentRight;
            this.TouristAccommodationUnit = vParcelCurrentInventoryByCommodityDetailed.TouristAccommodationUnit;
            this.TouristFloorArea = vParcelCurrentInventoryByCommodityDetailed.TouristFloorArea;
            this.AutoImported = vParcelCurrentInventoryByCommodityDetailed.AutoImported;
            CallAfterConstructor(vParcelCurrentInventoryByCommodityDetailed);
        }

        partial void CallAfterConstructor(vParcelCurrentInventoryByCommodityDetailed vParcelCurrentInventoryByCommodityDetailed);

        public int ParcelID { get; set; }
        public string ParcelNumber { get; set; }
        public string ParcelNickname { get; set; }
        public string ParcelStatusName { get; set; }
        public int? ParcelSize { get; set; }
        public int? BaileyRatingID { get; set; }
        public short? IPESScore { get; set; }
        public int? SquareFootage { get; set; }
        public int CoverageHard { get; set; }
        public int CoveragePotential { get; set; }
        public int CoverageSoft { get; set; }
        public int CommercialFloorArea { get; set; }
        public int ExistingResidentialUnit { get; set; }
        public int ResidentialAllocation { get; set; }
        public int ResidentialBonusUnit { get; set; }
        public int ResidentialFloorArea { get; set; }
        public int ResidentialDevelopmentRight { get; set; }
        public int TouristAccommodationUnit { get; set; }
        public int TouristFloorArea { get; set; }
        public bool AutoImported { get; set; }
    }
}