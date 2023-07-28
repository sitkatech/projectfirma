//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TrainingVideoRole]
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
    // Table [dbo].[TrainingVideoRole] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[TrainingVideoRole]")]
    public partial class TrainingVideoRole : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TrainingVideoRole()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TrainingVideoRole(int trainingVideoRoleID, int trainingVideoID, int? roleID) : this()
        {
            this.TrainingVideoRoleID = trainingVideoRoleID;
            this.TrainingVideoID = trainingVideoID;
            this.RoleID = roleID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TrainingVideoRole(int trainingVideoID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TrainingVideoRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TrainingVideoID = trainingVideoID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TrainingVideoRole(TrainingVideo trainingVideo) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TrainingVideoRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TrainingVideoID = trainingVideo.TrainingVideoID;
            this.TrainingVideo = trainingVideo;
            trainingVideo.TrainingVideoRoles.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TrainingVideoRole CreateNewBlank(TrainingVideo trainingVideo)
        {
            return new TrainingVideoRole(trainingVideo);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TrainingVideoRole).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllTrainingVideoRoles.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int TrainingVideoRoleID { get; set; }
        public int TenantID { get; set; }
        public int TrainingVideoID { get; set; }
        public int? RoleID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TrainingVideoRoleID; } set { TrainingVideoRoleID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual TrainingVideo TrainingVideo { get; set; }
        public Role Role { get { return RoleID.HasValue ? Role.AllLookupDictionary[RoleID.Value] : null; } }

        public static class FieldLengths
        {

        }
    }
}