//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumnSetting]
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
    // Table [dbo].[PersonSettingGridColumnSetting] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PersonSettingGridColumnSetting]")]
    public partial class PersonSettingGridColumnSetting : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonSettingGridColumnSetting()
        {
            this.PersonSettingGridColumnSettingFilters = new HashSet<PersonSettingGridColumnSettingFilter>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonSettingGridColumnSetting(int personSettingGridColumnSettingID, int personID, int personSettingGridColumnID) : this()
        {
            this.PersonSettingGridColumnSettingID = personSettingGridColumnSettingID;
            this.PersonID = personID;
            this.PersonSettingGridColumnID = personSettingGridColumnID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonSettingGridColumnSetting(int personID, int personSettingGridColumnID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonSettingGridColumnSettingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonID = personID;
            this.PersonSettingGridColumnID = personSettingGridColumnID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PersonSettingGridColumnSetting(Person person, PersonSettingGridColumn personSettingGridColumn) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonSettingGridColumnSettingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonID = person.PersonID;
            this.Person = person;
            person.PersonSettingGridColumnSettings.Add(this);
            this.PersonSettingGridColumnID = personSettingGridColumn.PersonSettingGridColumnID;
            this.PersonSettingGridColumn = personSettingGridColumn;
            personSettingGridColumn.PersonSettingGridColumnSettings.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonSettingGridColumnSetting CreateNewBlank(Person person, PersonSettingGridColumn personSettingGridColumn)
        {
            return new PersonSettingGridColumnSetting(person, personSettingGridColumn);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PersonSettingGridColumnSettingFilters.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(PersonSettingGridColumnSettingFilters.Any())
            {
                dependentObjects.Add(typeof(PersonSettingGridColumnSettingFilter).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonSettingGridColumnSetting).Name, typeof(PersonSettingGridColumnSettingFilter).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPersonSettingGridColumnSettings.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in PersonSettingGridColumnSettingFilters.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int PersonSettingGridColumnSettingID { get; set; }
        public int TenantID { get; set; }
        public int PersonID { get; set; }
        public int PersonSettingGridColumnID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonSettingGridColumnSettingID; } set { PersonSettingGridColumnSettingID = value; } }

        public virtual ICollection<PersonSettingGridColumnSettingFilter> PersonSettingGridColumnSettingFilters { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Person Person { get; set; }
        public virtual PersonSettingGridColumn PersonSettingGridColumn { get; set; }

        public static class FieldLengths
        {

        }
    }
}