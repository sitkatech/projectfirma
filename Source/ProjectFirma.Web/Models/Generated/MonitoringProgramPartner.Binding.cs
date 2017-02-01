//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MonitoringProgramPartner]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[MonitoringProgramPartner]")]
    public partial class MonitoringProgramPartner : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MonitoringProgramPartner()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MonitoringProgramPartner(int monitoringProgramPartnerID, int monitoringProgramID, int organizationID) : this()
        {
            this.MonitoringProgramPartnerID = monitoringProgramPartnerID;
            this.MonitoringProgramID = monitoringProgramID;
            this.OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MonitoringProgramPartner(int monitoringProgramID, int organizationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            MonitoringProgramPartnerID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.MonitoringProgramID = monitoringProgramID;
            this.OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public MonitoringProgramPartner(MonitoringProgram monitoringProgram, Organization organization) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MonitoringProgramPartnerID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.MonitoringProgramID = monitoringProgram.MonitoringProgramID;
            this.MonitoringProgram = monitoringProgram;
            monitoringProgram.MonitoringProgramPartners.Add(this);
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.MonitoringProgramPartners.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MonitoringProgramPartner CreateNewBlank(MonitoringProgram monitoringProgram, Organization organization)
        {
            return new MonitoringProgramPartner(monitoringProgram, organization);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MonitoringProgramPartner).Name};

        [Key]
        public int MonitoringProgramPartnerID { get; set; }
        public int MonitoringProgramID { get; set; }
        public int OrganizationID { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return MonitoringProgramPartnerID; } set { MonitoringProgramPartnerID = value; } }

        public virtual MonitoringProgram MonitoringProgram { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}