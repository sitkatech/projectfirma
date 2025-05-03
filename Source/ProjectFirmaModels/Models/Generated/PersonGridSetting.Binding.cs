//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonGridSetting]
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
    // Table [dbo].[PersonGridSetting] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PersonGridSetting]")]
    public partial class PersonGridSetting : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonGridSetting()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonGridSetting(int personGridSettingID, int personID, string gridName, string filterState, string columnState) : this()
        {
            this.PersonGridSettingID = personGridSettingID;
            this.PersonID = personID;
            this.GridName = gridName;
            this.FilterState = filterState;
            this.ColumnState = columnState;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonGridSetting(int personID, string gridName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonGridSettingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonID = personID;
            this.GridName = gridName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PersonGridSetting(Person person, string gridName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonGridSettingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonID = person.PersonID;
            this.Person = person;
            person.PersonGridSettings.Add(this);
            this.GridName = gridName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonGridSetting CreateNewBlank(Person person)
        {
            return new PersonGridSetting(person, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonGridSetting).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPersonGridSettings.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int PersonGridSettingID { get; set; }
        public int TenantID { get; set; }
        public int PersonID { get; set; }
        public string GridName { get; set; }
        public string FilterState { get; set; }
        public string ColumnState { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonGridSettingID; } set { PersonGridSettingID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Person Person { get; set; }

        public static class FieldLengths
        {
            public const int GridName = 250;
        }
    }
}