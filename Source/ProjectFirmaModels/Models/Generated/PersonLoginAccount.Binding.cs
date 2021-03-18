//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonLoginAccount]
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
    // Table [dbo].[PersonLoginAccount] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PersonLoginAccount]")]
    public partial class PersonLoginAccount : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonLoginAccount()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonLoginAccount(int personLoginAccountID, int personID, string personLoginAccountName, DateTime createDate, DateTime? updateDate, string passwordHash, string passwordSalt, bool loginActive, DateTime? lastLoginDate, DateTime? lastLogoutDate, int loginCount, int failedLoginCount) : this()
        {
            this.PersonLoginAccountID = personLoginAccountID;
            this.PersonID = personID;
            this.PersonLoginAccountName = personLoginAccountName;
            this.CreateDate = createDate;
            this.UpdateDate = updateDate;
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
            this.LoginActive = loginActive;
            this.LastLoginDate = lastLoginDate;
            this.LastLogoutDate = lastLogoutDate;
            this.LoginCount = loginCount;
            this.FailedLoginCount = failedLoginCount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonLoginAccount(int personID, string personLoginAccountName, DateTime createDate, string passwordHash, string passwordSalt, bool loginActive, int loginCount, int failedLoginCount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonLoginAccountID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonID = personID;
            this.PersonLoginAccountName = personLoginAccountName;
            this.CreateDate = createDate;
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
            this.LoginActive = loginActive;
            this.LoginCount = loginCount;
            this.FailedLoginCount = failedLoginCount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PersonLoginAccount(Person person, string personLoginAccountName, DateTime createDate, string passwordHash, string passwordSalt, bool loginActive, int loginCount, int failedLoginCount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonLoginAccountID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonID = person.PersonID;
            this.Person = person;
            person.PersonLoginAccounts.Add(this);
            this.PersonLoginAccountName = personLoginAccountName;
            this.CreateDate = createDate;
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
            this.LoginActive = loginActive;
            this.LoginCount = loginCount;
            this.FailedLoginCount = failedLoginCount;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonLoginAccount CreateNewBlank(Person person)
        {
            return new PersonLoginAccount(person, default(string), default(DateTime), default(string), default(string), default(bool), default(int), default(int));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonLoginAccount).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPersonLoginAccounts.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int PersonLoginAccountID { get; set; }
        public int PersonID { get; set; }
        public int TenantID { get; set; }
        public string PersonLoginAccountName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool LoginActive { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastLogoutDate { get; set; }
        public int LoginCount { get; set; }
        public int FailedLoginCount { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonLoginAccountID; } set { PersonLoginAccountID = value; } }

        public virtual Person Person { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int PersonLoginAccountName = 128;
            public const int PasswordHash = 128;
            public const int PasswordSalt = 128;
        }
    }
}