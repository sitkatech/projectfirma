namespace ProjectFirmaModels.Models
{
    public class ProjectContactSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectContactSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectContactSimple(ProjectOrganization projectOrganization)
            : this()
        {
            OrganizationID = projectOrganization.OrganizationID;
            OrganizationName = projectOrganization.Organization.OrganizationName;
            OrganizationRelationshipTypeID = projectOrganization.OrganizationRelationshipTypeID;
        }

        public ProjectContactSimple(ProjectOrganizationUpdate projectOrganization)
        {
            OrganizationID = projectOrganization.OrganizationID;
            OrganizationName = projectOrganization.Organization.OrganizationName;
            OrganizationRelationshipTypeID = projectOrganization.OrganizationRelationshipTypeID;
        }

        public ProjectContactSimple(int organizationID, int organizationRelationshipTypeId)
        {
            OrganizationID = organizationID;
            OrganizationRelationshipTypeID = organizationRelationshipTypeId;
        }

        public int OrganizationID { get; set; }
        public int OrganizationRelationshipTypeID { get; set; }
        public string OrganizationName { get; private set; }

        public ProjectContactUpdate ToProjectContactUpdate(ProjectUpdateBatch projectUpdateBatch)
        {
            return new ProjectContactUpdate(projectUpdateBatch.ProjectUpdateBatchID, OrganizationID, OrganizationRelationshipTypeID);
        }
    }
}