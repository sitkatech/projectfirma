using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ClassificationsValidationResult
    {
        private readonly List<string> _warningMessages;

        public ClassificationsValidationResult()
        {
            _warningMessages = new List<string>();
        }


        public ClassificationsValidationResult(List<ProjectClassificationSimple> projectClassificationSimple)
        {
            _warningMessages = new List<string>();

            //if (projectClassificationSimple.GroupBy(x => new { ClassificationID = x.ContactRelationshipTypeID, x.ContactID }).Any(x => x.Count() > 1))
            //{
            //    _warningMessages.Add($"Cannot have the same contact relationship type listed for the same Contact multiple times.");
            //}

            //var relationshipTypeThatMustBeRelatedOnceToAProject = HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.Where(x => x.IsContactRelationshipTypeRequired).ToList();

            //var projectContactsGroupedByContactRelationshipTypeID =
            //    projectClassificationSimple.GroupBy(x => x.ContactRelationshipTypeID).ToList();

            //_warningMessages.AddRange(relationshipTypeThatMustBeRelatedOnceToAProject
            //    .Where(rt => projectContactsGroupedByContactRelationshipTypeID.Count(po => po.Key == rt.ContactRelationshipTypeID) > 1)
            //    .Select(relationshipType =>
            //        $"Cannot have more than one Contact with a {FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.ContactRelationshipTypeName}\"."));

            //_warningMessages.AddRange(relationshipTypeThatMustBeRelatedOnceToAProject
            //    .Where(rt => projectContactsGroupedByContactRelationshipTypeID.Count(po => po.Key == rt.ContactRelationshipTypeID) == 0)
            //    .Select(relationshipType =>
            //        $"Must have one Contact with a {FieldDefinitionEnum.ProjectContactRelationshipType.ToType().GetFieldDefinitionLabel()} set to \"{relationshipType.ContactRelationshipTypeName}\"."));
        }

        public List<string> GetWarningMessages()
        {
            return _warningMessages;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}