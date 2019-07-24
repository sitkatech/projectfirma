using System.Collections.Generic;

namespace ProjectFirmaModels.Models
{
    public class OrganizationRelationshipTypeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public OrganizationRelationshipTypeSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationRelationshipTypeSimple(int organizationRelationshipTypeId, string organizationRelationshipTypeName)
            : this()
        {
            OrganizationRelationshipTypeID = organizationRelationshipTypeId;
            OrganizationRelationshipTypeName = organizationRelationshipTypeName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public OrganizationRelationshipTypeSimple(OrganizationRelationshipType organizationRelationshipType)
            : this()
        {
            OrganizationRelationshipTypeID = organizationRelationshipType.OrganizationRelationshipTypeID;
            OrganizationRelationshipTypeName = organizationRelationshipType.OrganizationRelationshipTypeName;
            OrganizationRelationshipTypeCanOnlyBeRelatedOnceToAProject = organizationRelationshipType.CanOnlyBeRelatedOnceToAProject;
            OrganizationRelationshipTypeHasOrganizationsWithSpatialBoundary = organizationRelationshipType.HasOrganizationsWithSpatialBoundary();
            OrganizationRelationshipTypeDescription = organizationRelationshipType.OrganizationRelationshipTypeDescription;
            OrganizationRelationshipTypeIsPrimaryContact = organizationRelationshipType.IsPrimaryContact;
        }

        public int OrganizationRelationshipTypeID { get; set; }
        public string OrganizationRelationshipTypeName { get; set; }
        public bool OrganizationRelationshipTypeIsPrimaryContact { get; set; }
        public bool OrganizationRelationshipTypeCanOnlyBeRelatedOnceToAProject { get; set; }
        public bool OrganizationRelationshipTypeHasOrganizationsWithSpatialBoundary { get; set; }
        public string OrganizationRelationshipTypeDescription { get; set; }
    }
}