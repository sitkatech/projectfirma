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

        public bool IsContactCurrentlyRequiredAtGivenProjectStage(ProjectStage currentProjectStage)
        {
            bool hasMinimumProjectStageSet = this.IsContactRelationshipRequiredMinimumProjectStage != null;

            if (this.IsContactRelationshipTypeRequired == false)
            {
                // Never required
                return false;
            }

            if (this.IsContactRelationshipTypeRequired && !hasMinimumProjectStageSet)
            {
                // It's required, with no minimum stage set
                return true;
            }

            if (this.IsContactRelationshipTypeRequired && hasMinimumProjectStageSet)
            {
                bool isCurrentlyRequired =  currentProjectStage.SortOrder >= this.IsContactRelationshipRequiredMinimumProjectStage.SortOrder;
                return isCurrentlyRequired;
            }

            throw new Exception("Unhandled branch; not expected!");
        }
    }
}