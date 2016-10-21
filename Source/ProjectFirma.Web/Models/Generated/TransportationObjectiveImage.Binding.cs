//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationObjectiveImage]
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
    [Table("[dbo].[TransportationObjectiveImage]")]
    public partial class TransportationObjectiveImage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TransportationObjectiveImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationObjectiveImage(int transportationObjectiveImageID, int transportationObjectiveID, int fileResourceID) : this()
        {
            this.TransportationObjectiveImageID = transportationObjectiveImageID;
            this.TransportationObjectiveID = transportationObjectiveID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationObjectiveImage(int transportationObjectiveID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TransportationObjectiveImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TransportationObjectiveID = transportationObjectiveID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TransportationObjectiveImage(TransportationObjective transportationObjective, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TransportationObjectiveImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TransportationObjectiveID = transportationObjective.TransportationObjectiveID;
            this.TransportationObjective = transportationObjective;
            transportationObjective.TransportationObjectiveImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.TransportationObjectiveImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TransportationObjectiveImage CreateNewBlank(TransportationObjective transportationObjective, FileResource fileResource)
        {
            return new TransportationObjectiveImage(transportationObjective, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TransportationObjectiveImage).Name};

        [Key]
        public int TransportationObjectiveImageID { get; set; }
        public int TransportationObjectiveID { get; set; }
        public int FileResourceID { get; set; }
        public int PrimaryKey { get { return TransportationObjectiveImageID; } set { TransportationObjectiveImageID = value; } }

        public virtual TransportationObjective TransportationObjective { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}