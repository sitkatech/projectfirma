//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vParcelCurrentInventoryByCommodity]
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
    public partial class vParcelCurrentInventoryByCommodity
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vParcelCurrentInventoryByCommodity()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vParcelCurrentInventoryByCommodity(int parcelID, int? coverage, int? commercialFloorArea, int? existingResidentialUnit, int? residentialAllocation, int? residentialBonusUnit, int? residentialDevelopmentRight, int? touristAccommodationUnit) : this()
        {
            this.ParcelID = parcelID;
            this.Coverage = coverage;
            this.CommercialFloorArea = commercialFloorArea;
            this.ExistingResidentialUnit = existingResidentialUnit;
            this.ResidentialAllocation = residentialAllocation;
            this.ResidentialBonusUnit = residentialBonusUnit;
            this.ResidentialDevelopmentRight = residentialDevelopmentRight;
            this.TouristAccommodationUnit = touristAccommodationUnit;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vParcelCurrentInventoryByCommodity(vParcelCurrentInventoryByCommodity vParcelCurrentInventoryByCommodity) : this()
        {
            this.ParcelID = vParcelCurrentInventoryByCommodity.ParcelID;
            this.Coverage = vParcelCurrentInventoryByCommodity.Coverage;
            this.CommercialFloorArea = vParcelCurrentInventoryByCommodity.CommercialFloorArea;
            this.ExistingResidentialUnit = vParcelCurrentInventoryByCommodity.ExistingResidentialUnit;
            this.ResidentialAllocation = vParcelCurrentInventoryByCommodity.ResidentialAllocation;
            this.ResidentialBonusUnit = vParcelCurrentInventoryByCommodity.ResidentialBonusUnit;
            this.ResidentialDevelopmentRight = vParcelCurrentInventoryByCommodity.ResidentialDevelopmentRight;
            this.TouristAccommodationUnit = vParcelCurrentInventoryByCommodity.TouristAccommodationUnit;
            CallAfterConstructor(vParcelCurrentInventoryByCommodity);
        }

        partial void CallAfterConstructor(vParcelCurrentInventoryByCommodity vParcelCurrentInventoryByCommodity);

        public int ParcelID { get; set; }
        public int? Coverage { get; set; }
        public int? CommercialFloorArea { get; set; }
        public int? ExistingResidentialUnit { get; set; }
        public int? ResidentialAllocation { get; set; }
        public int? ResidentialBonusUnit { get; set; }
        public int? ResidentialDevelopmentRight { get; set; }
        public int? TouristAccommodationUnit { get; set; }
    }
}