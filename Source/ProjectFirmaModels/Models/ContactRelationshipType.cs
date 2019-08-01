using System;
using System.Linq;
using LtInfo.Common;

namespace ProjectFirmaModels.Models
{
    public partial class ContactRelationshipType : IAuditableEntity
    {
        public bool CanDelete()
        {
            return !ProjectContacts.Any();
        }

        public string GetAuditDescriptionString() => ContactRelationshipTypeName;

        //public bool IsAssociatedWithContactType(ContactType contactType)
        //{
        //    return ContactTypeContactRelationshipTypes.Select(x => x.ContactType).Contains(contactType);
        //}
    }
}