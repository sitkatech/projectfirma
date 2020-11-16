using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectClassificationsUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectClassificationUpdates = project.ProjectClassifications.Select(x => new ProjectClassificationUpdate(projectUpdateBatch, x.Classification){ProjectClassificationUpdateNotes = x.ProjectClassificationNotes}).ToList();
        }

    }
}