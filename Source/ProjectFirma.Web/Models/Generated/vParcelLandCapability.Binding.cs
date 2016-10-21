//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vParcelLandCapability]
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
    public partial class vParcelLandCapability
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vParcelLandCapability()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vParcelLandCapability(int parcelID, int? squareFootage, int? baileyRatingID, short? iPESScore, string baileyRating) : this()
        {
            this.ParcelID = parcelID;
            this.SquareFootage = squareFootage;
            this.BaileyRatingID = baileyRatingID;
            this.IPESScore = iPESScore;
            this.BaileyRating = baileyRating;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vParcelLandCapability(vParcelLandCapability vParcelLandCapability) : this()
        {
            this.ParcelID = vParcelLandCapability.ParcelID;
            this.SquareFootage = vParcelLandCapability.SquareFootage;
            this.BaileyRatingID = vParcelLandCapability.BaileyRatingID;
            this.IPESScore = vParcelLandCapability.IPESScore;
            this.BaileyRating = vParcelLandCapability.BaileyRating;
            CallAfterConstructor(vParcelLandCapability);
        }

        partial void CallAfterConstructor(vParcelLandCapability vParcelLandCapability);

        public int ParcelID { get; set; }
        public int? SquareFootage { get; set; }
        public int? BaileyRatingID { get; set; }
        public short? IPESScore { get; set; }
        public string BaileyRating { get; set; }
    }
}