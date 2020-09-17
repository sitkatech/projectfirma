//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationClassification]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[MatchmakerOrganizationClassification] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[MatchmakerOrganizationClassification]")]
    public partial class MatchmakerOrganizationClassification : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected MatchmakerOrganizationClassification()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerOrganizationClassification(int matchmakerOrganizationClassificationID, int organizationID, int classificationID) : this()
        {
            this.MatchmakerOrganizationClassificationID = matchmakerOrganizationClassificationID;
            this.OrganizationID = organizationID;
            this.ClassificationID = classificationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public MatchmakerOrganizationClassification(int organizationID, int classificationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerOrganizationClassificationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.ClassificationID = classificationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public MatchmakerOrganizationClassification(Organization organization, Classification classification) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.MatchmakerOrganizationClassificationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.MatchmakerOrganizationClassifications.Add(this);
            this.ClassificationID = classification.ClassificationID;
            this.Classification = classification;
            classification.MatchmakerOrganizationClassifications.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static MatchmakerOrganizationClassification CreateNewBlank(Organization organization, Classification classification)
        {
            return new MatchmakerOrganizationClassification(organization, classification);
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(MatchmakerOrganizationClassification).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllMatchmakerOrganizationClassifications.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int MatchmakerOrganizationClassificationID { get; set; }
        public int TenantID { get; set; }
        public int OrganizationID { get; set; }
        public int ClassificationID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return MatchmakerOrganizationClassificationID; } set { MatchmakerOrganizationClassificationID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Organization Organization { get; set; }
        public virtual Classification Classification { get; set; }

        public static class FieldLengths
        {

        }
    }
}