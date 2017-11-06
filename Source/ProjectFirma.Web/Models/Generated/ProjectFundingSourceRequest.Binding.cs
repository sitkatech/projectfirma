//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceRequest]
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
    [Table("[dbo].[ProjectFundingSourceRequest]")]
    public partial class ProjectFundingSourceRequest : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectFundingSourceRequest()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceRequest(int projectFundingSourceRequestID, int projectID, int fundingSourceID, decimal securedAmount, decimal unsecuredAmount) : this()
        {
            this.ProjectFundingSourceRequestID = projectFundingSourceRequestID;
            this.ProjectID = projectID;
            this.FundingSourceID = fundingSourceID;
            this.SecuredAmount = securedAmount;
            this.UnsecuredAmount = unsecuredAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceRequest(int projectID, int fundingSourceID, decimal securedAmount, decimal unsecuredAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.FundingSourceID = fundingSourceID;
            this.SecuredAmount = securedAmount;
            this.UnsecuredAmount = unsecuredAmount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectFundingSourceRequest(Project project, FundingSource fundingSource, decimal securedAmount, decimal unsecuredAmount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectFundingSourceRequests.Add(this);
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.ProjectFundingSourceRequests.Add(this);
            this.SecuredAmount = securedAmount;
            this.UnsecuredAmount = unsecuredAmount;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectFundingSourceRequest CreateNewBlank(Project project, FundingSource fundingSource)
        {
            return new ProjectFundingSourceRequest(project, fundingSource, default(decimal), default(decimal));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectFundingSourceRequest).Name};

        [Key]
        public int ProjectFundingSourceRequestID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        public decimal SecuredAmount { get; set; }
        public decimal UnsecuredAmount { get; set; }
        public int PrimaryKey { get { return ProjectFundingSourceRequestID; } set { ProjectFundingSourceRequestID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual FundingSource FundingSource { get; set; }

        public static class FieldLengths
        {

        }
    }
}