using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.LocalAndRegionalPlan
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int LocalAndRegionalPlanID { get; set; }

        [Required]
        [StringLength(Models.LocalAndRegionalPlan.FieldLengths.LocalAndRegionalPlanName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.LocalAndRegionalPlanName)]
        public string LocalAndRegionalPlanName { get; set; }

        [StringLength(Models.LocalAndRegionalPlan.FieldLengths.PlanDocumentUrl)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.LocalAndRegionalPlanDocumentUrl)]
        [Url]
        public string LocalAndRegionalPlanDocumentUrl { get; set; }

        [StringLength(Models.LocalAndRegionalPlan.FieldLengths.PlanDocumentLinkText)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.LocalAndRegionalPlanDocumentLinkText)]
        public string LocalAndRegionalPlanDocumentLinkText { get; set; }

        [Required]
        public bool IsPlan { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.LocalAndRegionalPlan localAndRegionalPlan)
        {
            LocalAndRegionalPlanID = localAndRegionalPlan.LocalAndRegionalPlanID;
            LocalAndRegionalPlanName = localAndRegionalPlan.LocalAndRegionalPlanName;
            LocalAndRegionalPlanDocumentUrl = localAndRegionalPlan.PlanDocumentUrl;
            LocalAndRegionalPlanDocumentLinkText = localAndRegionalPlan.PlanDocumentLinkText;
        }

        public void UpdateModel(Models.LocalAndRegionalPlan localAndRegionalPlan, Person currentPerson)
        {
            localAndRegionalPlan.LocalAndRegionalPlanName = LocalAndRegionalPlanName;
            localAndRegionalPlan.PlanDocumentUrl = LocalAndRegionalPlanDocumentUrl;
            localAndRegionalPlan.PlanDocumentLinkText = LocalAndRegionalPlanDocumentLinkText;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingLocalAndRegionalPlans = HttpRequestStorage.DatabaseEntities.LocalAndRegionalPlans.ToList();
            if (!Models.LocalAndRegionalPlan.IsLocalAndRegionalPlanNameUnique(existingLocalAndRegionalPlans, LocalAndRegionalPlanName, LocalAndRegionalPlanID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Local and Regional Plan Name already exists", x => x.LocalAndRegionalPlanName));
            }
            return errors;
        }
    }
}