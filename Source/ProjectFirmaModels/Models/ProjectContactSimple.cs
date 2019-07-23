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
        public ProjectContactSimple(ProjectContact projectContact)
            : this()
        {
            ContactID = projectContact.ContactID;
            ContactName = projectContact.Contact.GetFullNameFirstLast();
            ContactRelationshipTypeID = projectContact.ContactRelationshipTypeID;
        }

        public ProjectContactSimple(ProjectContactUpdate projectContactUpdate)
        {
            ContactID = projectContactUpdate.ContactID;
            ContactName = projectContactUpdate.Contact.GetFullNameFirstLast();
            ContactRelationshipTypeID = projectContactUpdate.ContactRelationshipTypeID;
        }

        public ProjectContactSimple(int contactId, int contactRelationshipTypeId)
        {
            ContactID = contactId;
            ContactRelationshipTypeID = contactRelationshipTypeId;
        }

        public int ContactID { get; set; }
        public int ContactRelationshipTypeID { get; set; }
        public string ContactName { get; private set; }

        public ProjectContactUpdate ToProjectContactUpdate(ProjectUpdateBatch projectUpdateBatch)
        {
            return new ProjectContactUpdate(projectUpdateBatch.ProjectUpdateBatchID, ContactID, ContactRelationshipTypeID);
        }
    }
}