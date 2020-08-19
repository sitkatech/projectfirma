//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PersonSettingGridColumnSettingFilter]
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
    // Table [dbo].[PersonSettingGridColumnSettingFilter] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PersonSettingGridColumnSettingFilter]")]
    public partial class PersonSettingGridColumnSettingFilter : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PersonSettingGridColumnSettingFilter()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonSettingGridColumnSettingFilter(int personSettingGridColumnSettingFilterID, int personSettingGridColumnSettingID, string filterText) : this()
        {
            this.PersonSettingGridColumnSettingFilterID = personSettingGridColumnSettingFilterID;
            this.PersonSettingGridColumnSettingID = personSettingGridColumnSettingID;
            this.FilterText = filterText;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PersonSettingGridColumnSettingFilter(int personSettingGridColumnSettingID, string filterText) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonSettingGridColumnSettingFilterID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PersonSettingGridColumnSettingID = personSettingGridColumnSettingID;
            this.FilterText = filterText;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PersonSettingGridColumnSettingFilter(PersonSettingGridColumnSetting personSettingGridColumnSetting, string filterText) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PersonSettingGridColumnSettingFilterID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PersonSettingGridColumnSettingID = personSettingGridColumnSetting.PersonSettingGridColumnSettingID;
            this.PersonSettingGridColumnSetting = personSettingGridColumnSetting;
            personSettingGridColumnSetting.PersonSettingGridColumnSettingFilters.Add(this);
            this.FilterText = filterText;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PersonSettingGridColumnSettingFilter CreateNewBlank(PersonSettingGridColumnSetting personSettingGridColumnSetting)
        {
            return new PersonSettingGridColumnSettingFilter(personSettingGridColumnSetting, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PersonSettingGridColumnSettingFilter).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPersonSettingGridColumnSettingFilters.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int PersonSettingGridColumnSettingFilterID { get; set; }
        public int TenantID { get; set; }
        public int PersonSettingGridColumnSettingID { get; set; }
        public string FilterText { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PersonSettingGridColumnSettingFilterID; } set { PersonSettingGridColumnSettingFilterID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual PersonSettingGridColumnSetting PersonSettingGridColumnSetting { get; set; }

        public static class FieldLengths
        {
            public const int FilterText = 256;
        }
    }
}