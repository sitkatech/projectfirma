//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectNote]
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
    // Table [dbo].[ProjectNote] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectNote]")]
    public partial class ProjectNote : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectNote()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectNote(int projectNoteID, int projectID, string note, int? createPersonID, DateTime createDate, int? updatePersonID, DateTime? updateDate, string createPersonFullName, string updatePersonFullName) : this()
        {
            this.ProjectNoteID = projectNoteID;
            this.ProjectID = projectID;
            this.Note = note;
            this.CreatePersonID = createPersonID;
            this.CreateDate = createDate;
            this.UpdatePersonID = updatePersonID;
            this.UpdateDate = updateDate;
            this.CreatePersonFullName = createPersonFullName;
            this.UpdatePersonFullName = updatePersonFullName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectNote(int projectID, string note, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectNoteID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.Note = note;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectNote(Project project, string note, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectNoteID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectNotes.Add(this);
            this.Note = note;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectNote CreateNewBlank(Project project)
        {
            return new ProjectNote(project, default(string), default(DateTime));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectNote).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectNotes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectNoteID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public string Note { get; set; }
        public int? CreatePersonID { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdatePersonID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatePersonFullName { get; set; }
        public string UpdatePersonFullName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectNoteID; } set { ProjectNoteID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Person CreatePerson { get; set; }
        public virtual Person UpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int Note = 8000;
            public const int CreatePersonFullName = 201;
            public const int UpdatePersonFullName = 201;
        }
    }
}