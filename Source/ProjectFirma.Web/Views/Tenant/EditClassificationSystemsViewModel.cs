using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Tenant
{
    public class EditClassificationSystemsViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int? TenantID { get; set; }

        [Required]
        public List<ClassificationSystemSimple> ClassificationSystemSimples { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditClassificationSystemsViewModel()
        {
        }

        public EditClassificationSystemsViewModel(ProjectFirmaModels.Models.Tenant tenant)
        {
            TenantID = tenant.TenantID;
            ClassificationSystemSimples = MultiTenantHelpers.GetClassificationSystems().Select(x => new ClassificationSystemSimple(x)).ToList();

            if (ClassificationSystemSimples.Count < 2)
            {
                ClassificationSystemSimples.Add(new ClassificationSystemSimple(tenant.TenantID));
            }
        }

        public void UpdateModel(FirmaSession currentFirmaSession, List<ProjectFirmaModels.Models.ClassificationSystem> currentClassificationSystems, ObservableCollection<ProjectFirmaModels.Models.ClassificationSystem> allClassificationSystems)
        {
            var updatedClassificationSystems = ClassificationSystemSimples.Where(x => !string.IsNullOrEmpty(x.ClassificationSystemName)).Select(x => new ProjectFirmaModels.Models.ClassificationSystem(x.ClassificationSystemID ?? ModelObjectHelpers.NotYetAssignedID, 
                x.ClassificationSystemName, 
                x.ClassificationSystemDefinition?.ToString(), 
                null)).ToList();
            currentClassificationSystems.Merge(updatedClassificationSystems, allClassificationSystems, (x, y) => x.ClassificationSystemID == y.ClassificationSystemID, (x, y) =>
            {
                x.ClassificationSystemName = y.ClassificationSystemName;
                x.ClassificationSystemDefinition = y.ClassificationSystemDefinition;
            }, HttpRequestStorage.DatabaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (ClassificationSystemSimples.Count(x => string.IsNullOrEmpty(x.ClassificationSystemName)) > 1)
            {
                errors.Add(new ValidationResult("Each Tenant must have at least one Classification System."));
            }

            if (ClassificationSystemSimples.Count(x => !string.IsNullOrEmpty(x.ClassificationSystemName)) > 2)
            {
                errors.Add(new ValidationResult("Each Tenant can only have up to two Classification Systems."));
            }

            if (ClassificationSystemSimples.Any(x => !x.CanDelete && string.IsNullOrEmpty(x.ClassificationSystemName)))
            {
                errors.Add(new ValidationResult("You cannot remove a Classification System that has Classifications and Projects associated with it."));
            }

            if (ClassificationSystemSimples.Select(x => x.ClassificationSystemName).Distinct().Count() < ClassificationSystemSimples.Count(x => !string.IsNullOrEmpty(x.ClassificationSystemName)))
            {
                errors.Add(new ValidationResult("Each Classification System Name must be unique."));
            }

            return errors;
        }
    }
}