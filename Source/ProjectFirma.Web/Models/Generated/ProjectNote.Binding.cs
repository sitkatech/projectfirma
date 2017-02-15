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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
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
        public ProjectNote(int projectNoteID, int projectID, string note, int? createPersonID, DateTime createDate, int? updatePersonID, DateTime? updateDate) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.ProjectNoteID = projectNoteID;
            this.ProjectID = projectID;
            this.Note = note;
            this.CreatePersonID = createPersonID;
            this.CreateDate = createDate;
            this.UpdatePersonID = updatePersonID;
            this.UpdateDate = updateDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectNote(int projectID, string note, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectNoteID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
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
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
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
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectNote).Name};

        [Key]
        public int ProjectNoteID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public string Note { get; set; }
        public int? CreatePersonID { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdatePersonID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int PrimaryKey { get { return ProjectNoteID; } set { ProjectNoteID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Person CreatePerson { get; set; }
        public virtual Person UpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int Note = 8000;
        }
    }
}