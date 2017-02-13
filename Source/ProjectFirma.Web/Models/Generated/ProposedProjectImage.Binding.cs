//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectImage]
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
    [Table("[dbo].[ProposedProjectImage]")]
    public partial class ProposedProjectImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProposedProjectImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectImage(int proposedProjectImageID, int fileResourceID, int proposedProjectID, string caption, string credit) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.ProposedProjectImageID = proposedProjectImageID;
            this.FileResourceID = fileResourceID;
            this.ProposedProjectID = proposedProjectID;
            this.Caption = caption;
            this.Credit = credit;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectImage(int fileResourceID, int proposedProjectID, string caption, string credit) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.FileResourceID = fileResourceID;
            this.ProposedProjectID = proposedProjectID;
            this.Caption = caption;
            this.Credit = credit;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProposedProjectImage(FileResource fileResource, ProposedProject proposedProject, string caption, string credit) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ProposedProjectImages.Add(this);
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.ProposedProjectImages.Add(this);
            this.Caption = caption;
            this.Credit = credit;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProposedProjectImage CreateNewBlank(FileResource fileResource, ProposedProject proposedProject)
        {
            return new ProposedProjectImage(fileResource, proposedProject, default(string), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProposedProjectImage).Name};

        [Key]
        public int ProposedProjectImageID { get; set; }
        public int FileResourceID { get; set; }
        public int ProposedProjectID { get; set; }
        public string Caption { get; set; }
        public string Credit { get; set; }
        public int TenantID { get; private set; }
        public int PrimaryKey { get { return ProposedProjectImageID; } set { ProposedProjectImageID = value; } }

        public virtual FileResource FileResource { get; set; }
        public virtual ProposedProject ProposedProject { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int Caption = 200;
            public const int Credit = 200;
        }
    }
}