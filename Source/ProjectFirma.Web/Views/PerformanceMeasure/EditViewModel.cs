using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int PerformanceMeasureID { get; set; }

        [Required]
        [StringLength(Models.PerformanceMeasure.FieldLengths.PerformanceMeasureDisplayName)]
        public string PerformanceMeasureDisplayName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.MeasurementUnit)]
        public int MeasurementUnitTypeID { get; set; }

        [Required]
        public string PerformanceMeasureDefinition { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PerformanceMeasureType)]
        public int? PerformanceMeasureTypeID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            PerformanceMeasureDisplayName = performanceMeasure.PerformanceMeasureDisplayName;
            PerformanceMeasureTypeID = performanceMeasure.PerformanceMeasureTypeID;
            MeasurementUnitTypeID = performanceMeasure.MeasurementUnitTypeID;
            PerformanceMeasureDefinition = performanceMeasure.PerformanceMeasureDefinition;
        }

        public void UpdateModel(Models.PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            performanceMeasure.PerformanceMeasureDisplayName = PerformanceMeasureDisplayName;
            performanceMeasure.PerformanceMeasureTypeID = PerformanceMeasureTypeID.Value;
            performanceMeasure.MeasurementUnitTypeID = MeasurementUnitTypeID;
            performanceMeasure.PerformanceMeasureDefinition = PerformanceMeasureDefinition;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var performanceMeasures = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.ToList();
            if (!PerformanceMeasureModelExtensions.IsPerformanceMeasureDisplayNameUnique(performanceMeasures, PerformanceMeasureDisplayName, PerformanceMeasureID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>(FirmaValidationMessages.PerformanceMeasureNameUnique, x => x.PerformanceMeasureDisplayName));
            }
            return errors;
        }
    }
}