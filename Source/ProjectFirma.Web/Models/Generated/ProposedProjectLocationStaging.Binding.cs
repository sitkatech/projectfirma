//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectLocationStaging]
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
    [Table("[dbo].[ProposedProjectLocationStaging]")]
    public partial class ProposedProjectLocationStaging : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProposedProjectLocationStaging()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectLocationStaging(int proposedProjectLocationStagingID, int proposedProjectID, int personID, string featureClassName, string geoJson, string selectedProperty, bool shouldImport) : this()
        {
            this.ProposedProjectLocationStagingID = proposedProjectLocationStagingID;
            this.ProposedProjectID = proposedProjectID;
            this.PersonID = personID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
            this.SelectedProperty = selectedProperty;
            this.ShouldImport = shouldImport;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectLocationStaging(int proposedProjectID, int personID, string featureClassName, string geoJson, bool shouldImport) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProposedProjectLocationStagingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProposedProjectID = proposedProjectID;
            this.PersonID = personID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
            this.ShouldImport = shouldImport;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProposedProjectLocationStaging(ProposedProject proposedProject, int personID, string featureClassName, string geoJson, bool shouldImport) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectLocationStagingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.ProposedProjectLocationStagings.Add(this);
            this.PersonID = personID;
            this.FeatureClassName = featureClassName;
            this.GeoJson = geoJson;
            this.ShouldImport = shouldImport;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProposedProjectLocationStaging CreateNewBlank(ProposedProject proposedProject)
        {
            return new ProposedProjectLocationStaging(proposedProject, default(int), default(string), default(string), default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProposedProjectLocationStaging).Name};

        [Key]
        public int ProposedProjectLocationStagingID { get; set; }
        public int ProposedProjectID { get; set; }
        public int PersonID { get; set; }
        public string FeatureClassName { get; set; }
        public string GeoJson { get; set; }
        public string SelectedProperty { get; set; }
        public bool ShouldImport { get; set; }
        public int PrimaryKey { get { return ProposedProjectLocationStagingID; } set { ProposedProjectLocationStagingID = value; } }

        public virtual ProposedProject ProposedProject { get; set; }

        public static class FieldLengths
        {
            public const int FeatureClassName = 255;
            public const int SelectedProperty = 255;
        }
    }
}