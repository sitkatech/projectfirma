namespace ProjectFirmaModels.Models
{
    public class ContactRelationshipTypeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ContactRelationshipTypeSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ContactRelationshipTypeSimple(int contactRelationshipTypeId, string contactRelationshipTypeName)
            : this()
        {
            ContactRelationshipTypeID = contactRelationshipTypeId;
            ContactRelationshipTypeName = contactRelationshipTypeName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ContactRelationshipTypeSimple(ContactRelationshipType contactRelationshipType)
            : this()
        {
            ContactRelationshipTypeID = contactRelationshipType.ContactRelationshipTypeID;
            ContactRelationshipTypeName = contactRelationshipType.ContactRelationshipTypeName;
            ContactRelationshipTypeCanOnlyBeRelatedOnceToAProject = contactRelationshipType.IsContactRelationshipTypeRequired;
            ContactRelationshipTypeDescription = contactRelationshipType.ContactRelationshipTypeDescription;
        }

        public int ContactRelationshipTypeID { get; set; }
        public string ContactRelationshipTypeName { get; set; }
        public bool ContactRelationshipTypeCanOnlyBeRelatedOnceToAProject { get; set; }
        public string ContactRelationshipTypeDescription { get; set; }
    }
}