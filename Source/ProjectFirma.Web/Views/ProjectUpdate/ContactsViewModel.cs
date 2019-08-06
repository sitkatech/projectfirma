using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.ProjectContact;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ContactsViewModel : EditContactsViewModel
    {
        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ContactsComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Required by the ModelBinder
        /// </summary>
        public ContactsViewModel()
        {
        }

        public ContactsViewModel(ProjectUpdateBatch projectUpdateBatch)
        {
            ProjectContactSimples = projectUpdateBatch.ProjectContactUpdates.Any()
                ? projectUpdateBatch.ProjectContactUpdates
                    .Select(x => new ProjectContactSimple(x)).ToList()
                : new List<ProjectContactSimple>();
            PrimaryContactPersonID = projectUpdateBatch.ProjectUpdate.PrimaryContactPersonID;
            Comments = projectUpdateBatch.ContactsComment;
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch,
            List<ProjectContactUpdate> currentProjectContactUpdates,
            IList<ProjectContactUpdate> allProjectContactUpdates)
        {
            projectUpdateBatch.ProjectUpdate.PrimaryContactPersonID = PrimaryContactPersonID;

            var projectContactUpdatesUpdated = new List<ProjectContactUpdate>();

            if (ProjectContactSimples != null)
            {
                // Completely rebuild the list
                projectContactUpdatesUpdated = ProjectContactSimples.Where(x => ModelObjectHelpers.IsRealPrimaryKeyValue(x.ContactID)).Select(x => x.ToProjectContactUpdate(projectUpdateBatch)).ToList();
            }

            currentProjectContactUpdates.Merge(projectContactUpdatesUpdated,
                allProjectContactUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.ContactID == y.ContactID && x.ContactRelationshipTypeID == y.ContactRelationshipTypeID, HttpRequestStorage.DatabaseEntities);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProjectContactSimples == null)
            {
                ProjectContactSimples = new List<ProjectContactSimple>();
            }

            return new List<ValidationResult>();
        }
    }
}