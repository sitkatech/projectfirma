//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ActionPriorityImage]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[ActionPriorityImage]")]
    public partial class ActionPriorityImage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ActionPriorityImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ActionPriorityImage(int actionPriorityImageID, int actionPriorityID, int fileResourceID) : this()
        {
            this.ActionPriorityImageID = actionPriorityImageID;
            this.ActionPriorityID = actionPriorityID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ActionPriorityImage(int actionPriorityID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ActionPriorityImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ActionPriorityID = actionPriorityID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ActionPriorityImage(ActionPriority actionPriority, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ActionPriorityImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ActionPriorityID = actionPriority.ActionPriorityID;
            this.ActionPriority = actionPriority;
            actionPriority.ActionPriorityImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ActionPriorityImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ActionPriorityImage CreateNewBlank(ActionPriority actionPriority, FileResource fileResource)
        {
            return new ActionPriorityImage(actionPriority, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ActionPriorityImage).Name};

        [Key]
        public int ActionPriorityImageID { get; set; }
        public int ActionPriorityID { get; set; }
        public int FileResourceID { get; set; }
        public int PrimaryKey { get { return ActionPriorityImageID; } set { ActionPriorityImageID = value; } }

        public virtual ActionPriority ActionPriority { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}