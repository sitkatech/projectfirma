//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationImage]
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
    // Table [dbo].[OrganizationImage] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[OrganizationImage]")]
    public partial class OrganizationImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected OrganizationImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationImage(int organizationImageID, int organizationID, int fileResourceInfoID) : this()
        {
            this.OrganizationImageID = organizationImageID;
            this.OrganizationID = organizationID;
            this.FileResourceInfoID = fileResourceInfoID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationImage(int organizationID, int fileResourceInfoID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationID = organizationID;
            this.FileResourceInfoID = fileResourceInfoID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public OrganizationImage(Organization organization, FileResourceInfo fileResourceInfo) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.OrganizationImages.Add(this);
            this.FileResourceInfoID = fileResourceInfo.FileResourceInfoID;
            this.FileResourceInfo = fileResourceInfo;
            fileResourceInfo.OrganizationImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static OrganizationImage CreateNewBlank(Organization organization, FileResourceInfo fileResourceInfo)
        {
            return new OrganizationImage(organization, fileResourceInfo);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(OrganizationImage).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllOrganizationImages.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int OrganizationImageID { get; set; }
        public int TenantID { get; set; }
        public int OrganizationID { get; set; }
        public int FileResourceInfoID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return OrganizationImageID; } set { OrganizationImageID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Organization Organization { get; set; }
        public virtual FileResourceInfo FileResourceInfo { get; set; }

        public static class FieldLengths
        {

        }
    }
}