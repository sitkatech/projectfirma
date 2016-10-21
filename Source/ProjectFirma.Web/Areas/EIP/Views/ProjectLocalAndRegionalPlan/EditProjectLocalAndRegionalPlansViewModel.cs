using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectLocalAndRegionalPlan
{
    public class EditProjectLocalAndRegionalPlansViewModel : FormViewModel, IValidatableObject
    {
        public List<ProjectLocalAndRegionalPlanSimple> ProjectLocalAndRegionalPlans { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectLocalAndRegionalPlansViewModel()
        {
        }

        public EditProjectLocalAndRegionalPlansViewModel(List<ProjectLocalAndRegionalPlanSimple> projectLocalAndRegionalPlans)
        {
            ProjectLocalAndRegionalPlans = projectLocalAndRegionalPlans;
        }

        public void UpdateModel(List<Models.ProjectLocalAndRegionalPlan> currentProjectLocalAndRegionalPlans, IList<Models.ProjectLocalAndRegionalPlan> allProjectLocalAndRegionalPlans)
        {
            var projectLocalAndRegionalPlansUpdated = new List<Models.ProjectLocalAndRegionalPlan>();
            if (ProjectLocalAndRegionalPlans != null)
            {
                // Completely rebuild the list
                projectLocalAndRegionalPlansUpdated = ProjectLocalAndRegionalPlans.Select(x => new Models.ProjectLocalAndRegionalPlan(x.ProjectID, x.LocalAndRegionalPlanID)).ToList();
            }
            currentProjectLocalAndRegionalPlans.Merge(projectLocalAndRegionalPlansUpdated,
                allProjectLocalAndRegionalPlans,
                (x, y) => x.ProjectID == y.ProjectID && x.LocalAndRegionalPlanID == y.LocalAndRegionalPlanID);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            
            if (ProjectLocalAndRegionalPlans != null)
            {
                foreach (var projectLocalAndRegionalPlanSimple in ProjectLocalAndRegionalPlans)
                {
                    var project = HttpRequestStorage.DatabaseEntities.Projects.SingleOrDefault(x => x.ProjectID == projectLocalAndRegionalPlanSimple.ProjectID);
                    var larp = HttpRequestStorage.DatabaseEntities.LocalAndRegionalPlans.SingleOrDefault(x => x.LocalAndRegionalPlanID == projectLocalAndRegionalPlanSimple.LocalAndRegionalPlanID);

                    var error = ValidateImpl(project, larp);
                    if (error != null) errors.Add(error);
                }
            }
            return errors;
        }

        public static SitkaValidationResult<EditProjectLocalAndRegionalPlansViewModel, List<ProjectLocalAndRegionalPlanSimple>> ValidateImpl(Models.Project project, Models.LocalAndRegionalPlan larp)
        {
            if (project == null || larp == null || project.IsTransportationProject || !larp.IsTransportationPlan)
            {
                return null;
            }

            var errorMessage = string.Format("A non-Transportation project ({0}) cannot be associated with a Transportation Plan ({1})", project.ProjectNumberString, larp.LocalAndRegionalPlanName);
            return new SitkaValidationResult<EditProjectLocalAndRegionalPlansViewModel, List<ProjectLocalAndRegionalPlanSimple>>(errorMessage, x => x.ProjectLocalAndRegionalPlans);
        }
    }
}