using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public class RelationshipTypeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public RelationshipTypeSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public RelationshipTypeSimple(int relationshipTypeID, string relationshipTypeName)
            : this()
        {
            RelationshipTypeID = relationshipTypeID;
            RelationshipTypeName = relationshipTypeName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public RelationshipTypeSimple(RelationshipType relationshipType)
            : this()
        {
            RelationshipTypeID = relationshipType.RelationshipTypeID;
            RelationshipTypeName = relationshipType.RelationshipTypeName;
            RelationshipTypeCanOnlyBeRelatedOnceToAProject = relationshipType.CanOnlyBeRelatedOnceToAProject;
        }

        public int RelationshipTypeID { get; set; }
        public string RelationshipTypeName { get; set; }
        public bool RelationshipTypeCanOnlyBeRelatedOnceToAProject { get; set; }
        public string RelationshipTypeDescription { get; set; }
    }
}