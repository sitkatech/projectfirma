using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Indicator
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int IndicatorID { get; set; }

        [Required]
        [StringLength(Models.Indicator.FieldLengths.IndicatorDisplayName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.IndicatorDisplayName)]
        public string IndicatorDisplayName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.MeasurementUnit)]
        public int MeasurementUnitTypeID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.IndicatorDefinition)]
        public string IndicationDefinition { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.IndicatorType)]
        public int? IndicatorTypeID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.Indicator indicator)
        {
            IndicatorID = indicator.IndicatorID;
            IndicatorDisplayName = indicator.IndicatorDisplayName;
            IndicatorTypeID = indicator.IndicatorTypeID;
            MeasurementUnitTypeID = indicator.MeasurementUnitTypeID;
            IndicationDefinition = indicator.IndicatorDefinition;
        }

        public void UpdateModel(Models.Indicator indicator, Person currentPerson)
        {
            indicator.IndicatorDisplayName = IndicatorDisplayName;
            indicator.IndicatorTypeID = IndicatorTypeID.Value;
            indicator.MeasurementUnitTypeID = MeasurementUnitTypeID;
            indicator.IndicatorDefinition = IndicationDefinition;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var indicators = HttpRequestStorage.DatabaseEntities.Indicators.ToList();
            if (!IndicatorModelExtensions.IsIndicatorNameUnique(indicators, IndicatorDisplayName, IndicatorID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>(FirmaValidationMessages.IndicatorNameUnique, x => x.IndicatorDisplayName));
            }
            return errors;
        }
    }
}