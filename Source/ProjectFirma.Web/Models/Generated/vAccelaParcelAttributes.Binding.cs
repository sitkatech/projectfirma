//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vAccelaParcelAttributes]
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
    public partial class vAccelaParcelAttributes
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vAccelaParcelAttributes()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vAccelaParcelAttributes(string aPN, string parcelSize, string jurisdiction, string areaPlan, string communityPlan, string planAreaStatement, string planAreaStatementID, string bMPStatus, string fireDistrict, string hRA) : this()
        {
            this.APN = aPN;
            this.ParcelSize = parcelSize;
            this.Jurisdiction = jurisdiction;
            this.AreaPlan = areaPlan;
            this.CommunityPlan = communityPlan;
            this.PlanAreaStatement = planAreaStatement;
            this.PlanAreaStatementID = planAreaStatementID;
            this.BMPStatus = bMPStatus;
            this.FireDistrict = fireDistrict;
            this.HRA = hRA;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vAccelaParcelAttributes(vAccelaParcelAttributes vAccelaParcelAttributes) : this()
        {
            this.APN = vAccelaParcelAttributes.APN;
            this.ParcelSize = vAccelaParcelAttributes.ParcelSize;
            this.Jurisdiction = vAccelaParcelAttributes.Jurisdiction;
            this.AreaPlan = vAccelaParcelAttributes.AreaPlan;
            this.CommunityPlan = vAccelaParcelAttributes.CommunityPlan;
            this.PlanAreaStatement = vAccelaParcelAttributes.PlanAreaStatement;
            this.PlanAreaStatementID = vAccelaParcelAttributes.PlanAreaStatementID;
            this.BMPStatus = vAccelaParcelAttributes.BMPStatus;
            this.FireDistrict = vAccelaParcelAttributes.FireDistrict;
            this.HRA = vAccelaParcelAttributes.HRA;
            CallAfterConstructor(vAccelaParcelAttributes);
        }

        partial void CallAfterConstructor(vAccelaParcelAttributes vAccelaParcelAttributes);

        public string APN { get; set; }
        public string ParcelSize { get; set; }
        public string Jurisdiction { get; set; }
        public string AreaPlan { get; set; }
        public string CommunityPlan { get; set; }
        public string PlanAreaStatement { get; set; }
        public string PlanAreaStatementID { get; set; }
        public string BMPStatus { get; set; }
        public string FireDistrict { get; set; }
        public string HRA { get; set; }
    }
}