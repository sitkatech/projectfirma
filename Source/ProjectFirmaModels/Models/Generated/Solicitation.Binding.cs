//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Solicitation]
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
    // Table [dbo].[Solicitation] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[Solicitation]")]
    public partial class Solicitation : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Solicitation()
        {
            this.Projects = new HashSet<Project>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Solicitation(int solicitationID, string solicitationName, string instructions, bool isActive) : this()
        {
            this.SolicitationID = solicitationID;
            this.SolicitationName = solicitationName;
            this.Instructions = instructions;
            this.IsActive = isActive;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Solicitation(string solicitationName, bool isActive) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SolicitationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SolicitationName = solicitationName;
            this.IsActive = isActive;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Solicitation CreateNewBlank()
        {
            return new Solicitation(default(string), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Projects.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(Projects.Any())
            {
                dependentObjects.Add(typeof(Project).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Solicitation).Name, typeof(Project).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllSolicitations.Remove(this);
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

            foreach(var x in Projects.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int SolicitationID { get; set; }
        public int TenantID { get; set; }
        public string SolicitationName { get; set; }
        public string Instructions { get; set; }
        [NotMapped]
        public HtmlString InstructionsHtmlString
        { 
            get { return Instructions == null ? null : new HtmlString(Instructions); }
            set { Instructions = value?.ToString(); }
        }
        public bool IsActive { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return SolicitationID; } set { SolicitationID = value; } }

        public virtual ICollection<Project> Projects { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int SolicitationName = 200;
        }
    }
}