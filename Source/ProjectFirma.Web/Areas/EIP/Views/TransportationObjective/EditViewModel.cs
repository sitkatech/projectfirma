using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationObjective
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int TransportationObjectiveID { get; set; }

        [Required]
        [StringLength(Models.TransportationObjective.FieldLengths.TransportationObjectiveName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TransportationObjectiveName)]
        public string TransportationObjectiveName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TransportationStrategy)]
        public int TransportationStrategyID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
        public int FundingTypeID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.TransportationObjective transportationObjective)
        {
            TransportationObjectiveID = transportationObjective.TransportationObjectiveID;
            TransportationObjectiveName = transportationObjective.TransportationObjectiveName;
            TransportationStrategyID = transportationObjective.TransportationStrategyID;
            FundingTypeID = transportationObjective.FundingTypeID;
        }

        public void UpdateModel(Models.TransportationObjective transportationObjective, Person currentPerson)
        {
            transportationObjective.TransportationObjectiveName = TransportationObjectiveName;
            transportationObjective.TransportationStrategyID = TransportationStrategyID;
            transportationObjective.FundingTypeID = FundingTypeID;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var existingTransportationObjectives = HttpRequestStorage.DatabaseEntities.TransportationObjectives.ToList();
            if (!Models.TransportationObjective.IsTransportationObjectiveNameUnique(existingTransportationObjectives, TransportationObjectiveName, TransportationObjectiveID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("Name already exists", x => x.TransportationObjectiveName));
            }

            return errors;
        }
    }
}