//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonStewardTaxonomyBranch]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[PersonStewardTaxonomyBranch] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PersonStewardTaxonomyBranch]")]
    public partial class PersonStewardTaxonomyBranch : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonStewardTaxonomyBranch()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonStewardTaxonomyBranch(int personStewardTaxonomyBranchID, int personID, int taxonomyBranchID) : this()
        {
            this.PersonStewardTaxonomyBranchID = personStewardTaxonomyBranchID;
            this.PersonID = personID;
            this.TaxonomyBranchID = taxonomyBranchID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonStewardTaxonomyBranch(int personID, int taxonomyBranchID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonStewardTaxonomyBranchID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonID = personID;
            this.TaxonomyBranchID = taxonomyBranchID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PersonStewardTaxonomyBranch(Person person, TaxonomyBranch taxonomyBranch) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonStewardTaxonomyBranchID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonID = person.PersonID;
            this.Person = person;
            person.PersonStewardTaxonomyBranches.Add(this);
            this.TaxonomyBranchID = taxonomyBranch.TaxonomyBranchID;
            this.TaxonomyBranch = taxonomyBranch;
            taxonomyBranch.PersonStewardTaxonomyBranches.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonStewardTaxonomyBranch CreateNewBlank(Person person, TaxonomyBranch taxonomyBranch)
        {
            return new PersonStewardTaxonomyBranch(person, taxonomyBranch);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonStewardTaxonomyBranch).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPersonStewardTaxonomyBranches.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int PersonStewardTaxonomyBranchID { get; set; }
        public int TenantID { get; set; }
        public int PersonID { get; set; }
        public int TaxonomyBranchID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonStewardTaxonomyBranchID; } set { PersonStewardTaxonomyBranchID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Person Person { get; set; }
        public virtual TaxonomyBranch TaxonomyBranch { get; set; }

        public static class FieldLengths
        {

        }
    }
}