//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SupportRequestLog]
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
    [Table("[dbo].[SupportRequestLog]")]
    public partial class SupportRequestLog : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SupportRequestLog()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SupportRequestLog(int supportRequestLogID, DateTime requestDate, string requestPersonName, string requestPersonEmail, int? requestPersonID, int supportRequestTypeID, string requestDescription, string requestPersonOrganization, string requestPersonPhone) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.SupportRequestLogID = supportRequestLogID;
            this.RequestDate = requestDate;
            this.RequestPersonName = requestPersonName;
            this.RequestPersonEmail = requestPersonEmail;
            this.RequestPersonID = requestPersonID;
            this.SupportRequestTypeID = supportRequestTypeID;
            this.RequestDescription = requestDescription;
            this.RequestPersonOrganization = requestPersonOrganization;
            this.RequestPersonPhone = requestPersonPhone;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SupportRequestLog(DateTime requestDate, string requestPersonName, string requestPersonEmail, int supportRequestTypeID, string requestDescription) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SupportRequestLogID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.RequestDate = requestDate;
            this.RequestPersonName = requestPersonName;
            this.RequestPersonEmail = requestPersonEmail;
            this.SupportRequestTypeID = supportRequestTypeID;
            this.RequestDescription = requestDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SupportRequestLog(DateTime requestDate, string requestPersonName, string requestPersonEmail, SupportRequestType supportRequestType, string requestDescription) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SupportRequestLogID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.Tenant = HttpRequestStorage.Tenant;
            this.RequestDate = requestDate;
            this.RequestPersonName = requestPersonName;
            this.RequestPersonEmail = requestPersonEmail;
            this.SupportRequestTypeID = supportRequestType.SupportRequestTypeID;
            this.RequestDescription = requestDescription;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SupportRequestLog CreateNewBlank(SupportRequestType supportRequestType)
        {
            return new SupportRequestLog(default(DateTime), default(string), default(string), supportRequestType, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SupportRequestLog).Name};

        [Key]
        public int SupportRequestLogID { get; set; }
        public int TenantID { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestPersonName { get; set; }
        public string RequestPersonEmail { get; set; }
        public int? RequestPersonID { get; set; }
        public int SupportRequestTypeID { get; set; }
        public string RequestDescription { get; set; }
        public string RequestPersonOrganization { get; set; }
        public string RequestPersonPhone { get; set; }
        public int PrimaryKey { get { return SupportRequestLogID; } set { SupportRequestLogID = value; } }

        public virtual Tenant Tenant { get; set; }
        public virtual Person RequestPerson { get; set; }
        public SupportRequestType SupportRequestType { get { return SupportRequestType.AllLookupDictionary[SupportRequestTypeID]; } }

        public static class FieldLengths
        {
            public const int RequestPersonName = 200;
            public const int RequestPersonEmail = 256;
            public const int RequestDescription = 2000;
            public const int RequestPersonOrganization = 500;
            public const int RequestPersonPhone = 50;
        }
    }
}