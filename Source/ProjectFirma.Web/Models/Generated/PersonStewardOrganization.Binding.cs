//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardOrganization]
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
    [Table("[dbo].[PersonStewardOrganization]")]
    public partial class PersonStewardOrganization : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonStewardOrganization()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonStewardOrganization(int personStewardOrganizationID, int personID, int organizationID) : this()
        {
            this.PersonStewardOrganizationID = personStewardOrganizationID;
            this.PersonID = personID;
            this.OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonStewardOrganization(int personID, int organizationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonStewardOrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonID = personID;
            this.OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PersonStewardOrganization(Person person, Organization organization) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonStewardOrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonID = person.PersonID;
            this.Person = person;
            person.PersonStewardOrganizations.Add(this);
            this.OrganizationID = organization.OrganizationID;
            this.Organization = organization;
            organization.PersonStewardOrganizations.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonStewardOrganization CreateNewBlank(Person person, Organization organization)
        {
            return new PersonStewardOrganization(person, organization);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonStewardOrganization).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {
            DeleteFull(HttpRequestStorage.DatabaseEntities);
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            dbContext.AllPersonStewardOrganizations.Remove(this);
        }

        [Key]
        public int PersonStewardOrganizationID { get; set; }
        public int TenantID { get; private set; }
        public int PersonID { get; set; }
        public int OrganizationID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonStewardOrganizationID; } set { PersonStewardOrganizationID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Person Person { get; set; }
        public virtual Organization Organization { get; set; }

        public static class FieldLengths
        {

        }
    }
}