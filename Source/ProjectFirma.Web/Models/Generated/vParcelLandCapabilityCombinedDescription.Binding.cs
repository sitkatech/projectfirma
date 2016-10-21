//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vParcelLandCapabilityCombinedDescription]
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
    public partial class vParcelLandCapabilityCombinedDescription
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vParcelLandCapabilityCombinedDescription()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vParcelLandCapabilityCombinedDescription(int parcelID, string landCapability) : this()
        {
            this.ParcelID = parcelID;
            this.LandCapability = landCapability;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vParcelLandCapabilityCombinedDescription(vParcelLandCapabilityCombinedDescription vParcelLandCapabilityCombinedDescription) : this()
        {
            this.ParcelID = vParcelLandCapabilityCombinedDescription.ParcelID;
            this.LandCapability = vParcelLandCapabilityCombinedDescription.LandCapability;
            CallAfterConstructor(vParcelLandCapabilityCombinedDescription);
        }

        partial void CallAfterConstructor(vParcelLandCapabilityCombinedDescription vParcelLandCapabilityCombinedDescription);

        public int ParcelID { get; set; }
        public string LandCapability { get; set; }
    }
}