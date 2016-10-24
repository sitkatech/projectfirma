using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Views.Shared.EIPPerformanceMeasureControls;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class ExpectedEipPerformanceMeasureValuesViewModel : EditEIPPerformanceMeasureExpectedViewModel, IValidatableObject
    {
        [StringLength(Models.ProposedProject.FieldLengths.IndicatorNotes)]
        public string IndicatorNotes { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpectedEipPerformanceMeasureValuesViewModel()
        {
        }

        public ExpectedEipPerformanceMeasureValuesViewModel(Models.ProposedProject proposedProject)
            : base(proposedProject.EIPPerformanceMeasureExpectedProposeds.OrderBy(pam => pam.EIPPerformanceMeasureID).Select(x => new EIPPerformanceMeasureExpectedSimple(x)).ToList())
        {
            IndicatorNotes = proposedProject.IndicatorNotes;
        }

        public void UpdateModel(List<EIPPerformanceMeasureExpectedProposed> currentEIPPerformanceMeasureExpectedProposeds,
            IList<EIPPerformanceMeasureExpectedProposed> allEIPPerformanceMeasureExpectedProposeds,
            IList<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> allEIPPerformanceMeasureExpectedSubcategoryOptionProposeds,
            Models.ProposedProject proposedProject)
        {
            //Save our note
            proposedProject.IndicatorNotes = IndicatorNotes;

            // Remove all existing associations
            currentEIPPerformanceMeasureExpectedProposeds.ForEach(pmav =>
            {
                pmav.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.ToList().ForEach(pmavso => allEIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Remove(pmavso));
                allEIPPerformanceMeasureExpectedProposeds.Remove(pmav);
            });
            currentEIPPerformanceMeasureExpectedProposeds.Clear();

            if (EIPPerformanceMeasureExpecteds != null)
            {
                // Completely rebuild the list
                EIPPerformanceMeasureExpecteds.ForEach(x =>
                {
                    var proposedProjectEIPPerformanceMeasureExpected = new EIPPerformanceMeasureExpectedProposed(x.ProjectID, x.EIPPerformanceMeasureID) { ExpectedValue = x.ExpectedValue };
                    allEIPPerformanceMeasureExpectedProposeds.Add(proposedProjectEIPPerformanceMeasureExpected);
                    if (x.EIPPerformanceMeasureExpectedSubcategoryOptions != null)
                    {
                        x.EIPPerformanceMeasureExpectedSubcategoryOptions.Where(y => ModelObjectHelpers.IsRealPrimaryKeyValue(y.IndicatorSubcategoryOptionID))
                            .ToList()
                            .ForEach(
                                y =>
                                    allEIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Add(
                                        new EIPPerformanceMeasureExpectedSubcategoryOptionProposed(proposedProjectEIPPerformanceMeasureExpected.EIPPerformanceMeasureExpectedProposedID,
                                            y.IndicatorSubcategoryOptionID,
                                            y.EIPPerformanceMeasureID,
                                            y.IndicatorSubcategoryID)));
                    }
                });
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var validationResults = new List<ValidationResult>();

            if ((EIPPerformanceMeasureExpecteds == null || !EIPPerformanceMeasureExpecteds.Any()) && string.IsNullOrWhiteSpace(IndicatorNotes))
            {
                const string errorMessage = "You must provide one or more expected Performance Measures, or provide a brief note describing why the Performance Measures are not yet known for this proposal.";
                validationResults.Add(new SitkaValidationResult<ExpectedEipPerformanceMeasureValuesViewModel, string>(errorMessage, x => x.IndicatorNotes));
            }
            return validationResults;
        }
    }
}