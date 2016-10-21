using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationStrategy
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TransportationStrategyID { get; set; }

        [Required]
        [StringLength(Models.TransportationStrategy.FieldLengths.TransportationStrategyName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TransportationStrategyName)]
        public string TransportationStrategyName { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.TransportationStrategy transportationStrategy)
        {
            TransportationStrategyID = transportationStrategy.TransportationStrategyID;
            TransportationStrategyName = transportationStrategy.TransportationStrategyName;
        }

        public void UpdateModel(Models.TransportationStrategy transportationStrategy, Person currentPerson)
        {
            transportationStrategy.TransportationStrategyName = TransportationStrategyName;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var existingTransportationStrategies = HttpRequestStorage.DatabaseEntities.TransportationStrategies.ToList();
            if (!Models.TransportationStrategy.IsTransportationStrategyNameUnique(existingTransportationStrategies, TransportationStrategyName, TransportationStrategyID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.TransportationStrategyName));
            }
            return errors;
        }
    }
}