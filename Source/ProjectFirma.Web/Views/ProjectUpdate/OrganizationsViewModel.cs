using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.ProjectOrganization;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class OrganizationsViewModel : EditOrganizationsViewModel
    {
        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.OrganizationsComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Required by the ModelBinder
        /// </summary>
        public OrganizationsViewModel()
        {
        }

        public OrganizationsViewModel(ProjectUpdateBatch projectUpdateBatch)
        {
            ProjectOrganizationSimples = projectUpdateBatch.ProjectOrganizationUpdates.Any()
                ? projectUpdateBatch.ProjectOrganizationUpdates
                    .Select(x => new ProjectOrganizationSimple(x)).ToList()
                : new List<ProjectOrganizationSimple>();
            PrimaryContactPersonID = projectUpdateBatch.ProjectUpdate.PrimaryContactPersonID;
            Comments = projectUpdateBatch.OrganizationsComment;
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch,
            List<ProjectOrganizationUpdate> currentProjectOrganizationUpdates,
            IList<ProjectOrganizationUpdate> allProjectOrganizationUpdates)
        {
            projectUpdateBatch.ProjectUpdate.PrimaryContactPersonID = PrimaryContactPersonID;

            var projectOrganizationUpdatesUpdated = new List<ProjectOrganizationUpdate>();

            if (ProjectOrganizationSimples != null)
            {
                // Completely rebuild the list
                projectOrganizationUpdatesUpdated = ProjectOrganizationSimples.Where(x => ModelObjectHelpers.IsRealPrimaryKeyValue(x.OrganizationID)).Select(x => x.ToProjectOrganizationUpdate(projectUpdateBatch)).ToList();
            }

            currentProjectOrganizationUpdates.Merge(projectOrganizationUpdatesUpdated,
                allProjectOrganizationUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.OrganizationID == y.OrganizationID && x.OrganizationRelationshipTypeID == y.OrganizationRelationshipTypeID, HttpRequestStorage.DatabaseEntities);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProjectOrganizationSimples == null)
            {
                ProjectOrganizationSimples = new List<ProjectOrganizationSimple>();
            }

            return new List<ValidationResult>();
        }
    }
}