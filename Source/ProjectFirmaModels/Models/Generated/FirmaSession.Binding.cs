//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaSession]
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
    // Table [dbo].[FirmaSession] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FirmaSession]")]
    public partial class FirmaSession : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FirmaSession()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaSession(int firmaSessionID, Guid firmaSessionGuid, int? personID, int? originalPersonID, DateTime createDate) : this()
        {
            this.FirmaSessionID = firmaSessionID;
            this.FirmaSessionGuid = firmaSessionGuid;
            this.PersonID = personID;
            this.OriginalPersonID = originalPersonID;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FirmaSession(Guid firmaSessionGuid, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FirmaSessionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FirmaSessionGuid = firmaSessionGuid;
            this.CreateDate = createDate;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FirmaSession CreateNewBlank()
        {
            return new FirmaSession(default(Guid), default(DateTime));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FirmaSession).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFirmaSessions.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int FirmaSessionID { get; set; }
        public int TenantID { get; set; }
        public Guid FirmaSessionGuid { get; set; }
        public int? PersonID { get; set; }
        public int? OriginalPersonID { get; set; }
        public DateTime CreateDate { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FirmaSessionID; } set { FirmaSessionID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Person OriginalPerson { get; set; }
        public virtual Person Person { get; set; }

        public static class FieldLengths
        {

        }
    }
}