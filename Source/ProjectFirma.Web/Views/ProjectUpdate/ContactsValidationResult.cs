using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ContactsValidationResult
    {
        private readonly List<string> _warningMessages;

        public ContactsValidationResult()
        {
            _warningMessages = new List<string>();
        }


        public ContactsValidationResult(List<ProjectContactSimple> projectContactSimples)
        {
            _warningMessages = new List<string>();

            if (projectContactSimples.GroupBy(x => new { RelationshipTypeID = x.ContactRelationshipTypeID, x.ContactID }).Any(x => x.Count() > 1))
            {
                _warningMessages.Add($"Cannot have the same contact relationship type listed for the same Contact multiple times.");
            }

            var relationshipTypeThatMustBeRelatedOnceToAProject = HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.Where(x => x.CanOnlyBeRelatedOnceToAProject).ToList();

            var projectContactsGroupedByContactRelationshipTypeID =
                projectContactSimples.GroupBy(x => x.ContactRelationshipTypeID).ToList();

            _warningMessages.AddRange(relationshipTypeThatMustBeRelatedOnceToAProject
                .Where(rt => projectContactsGroupedByContactRelationshipTypeID.Count(po => po.Key == rt.ContactRelationshipTypeID) > 1)
                .Select(relationshipType => 
                    $"Cannot have more than one Contact with a {FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.ContactRelationshipTypeName}\"."));

            _warningMessages.AddRange(relationshipTypeThatMustBeRelatedOnceToAProject
                .Where(rt => projectContactsGroupedByContactRelationshipTypeID.Count(po => po.Key == rt.ContactRelationshipTypeID) == 0)
                .Select(relationshipType => 
                    $"Must have one Contact with a {FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.ContactRelationshipTypeName}\"."));
        }

        public List<string> GetWarningMessages()
        {
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}