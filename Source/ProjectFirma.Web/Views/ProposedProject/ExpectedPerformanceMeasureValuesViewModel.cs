using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class ExpectedPerformanceMeasureValuesViewModel : EditPerformanceMeasureExpectedViewModel, IValidatableObject
    {
        [StringLength(Models.ProposedProject.FieldLengths.IndicatorNotes)]
        public string IndicatorNotes { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpectedPerformanceMeasureValuesViewModel()
        {
        }

        public ExpectedPerformanceMeasureValuesViewModel(Models.ProposedProject proposedProject)
            : base(proposedProject.PerformanceMeasureExpectedProposeds.OrderBy(pam => pam.PerformanceMeasureID).Select(x => new PerformanceMeasureExpectedSimple(x)).ToList())
        {
            IndicatorNotes = proposedProject.IndicatorNotes;
        }

        public void UpdateModel(List<PerformanceMeasureExpectedProposed> currentPerformanceMeasureExpectedProposeds,
            IList<PerformanceMeasureExpectedProposed> allPerformanceMeasureExpectedProposeds,
            IList<PerformanceMeasureExpectedSubcategoryOptionProposed> allPerformanceMeasureExpectedSubcategoryOptionProposeds,
            Models.ProposedProject proposedProject)
        {
            //Save our note
            proposedProject.IndicatorNotes = IndicatorNotes;

            // Remove all existing associations
            currentPerformanceMeasureExpectedProposeds.ForEach(pmav =>
            {
                pmav.PerformanceMeasureExpectedSubcategoryOptionProposeds.ToList().ForEach(pmavso => allPerformanceMeasureExpectedSubcategoryOptionProposeds.Remove(pmavso));
                allPerformanceMeasureExpectedProposeds.Remove(pmav);
            });
            currentPerformanceMeasureExpectedProposeds.Clear();

            if (PerformanceMeasureExpecteds != null)
            {
                // Completely rebuild the list
                PerformanceMeasureExpecteds.ForEach(x =>
                {
                    var proposedProjectPerformanceMeasureExpected = new PerformanceMeasureExpectedProposed(x.ProjectID, x.PerformanceMeasureID) { ExpectedValue = x.ExpectedValue };
                    allPerformanceMeasureExpectedProposeds.Add(proposedProjectPerformanceMeasureExpected);
                    if (x.PerformanceMeasureExpectedSubcategoryOptions != null)
                    {
                        x.PerformanceMeasureExpectedSubcategoryOptions.Where(y => ModelObjectHelpers.IsRealPrimaryKeyValue(y.IndicatorSubcategoryOptionID))
                            .ToList()
                            .ForEach(
                                y =>
                                    allPerformanceMeasureExpectedSubcategoryOptionProposeds.Add(
                                        new PerformanceMeasureExpectedSubcategoryOptionProposed(proposedProjectPerformanceMeasureExpected.PerformanceMeasureExpectedProposedID,
                                            y.IndicatorSubcategoryOptionID,
                                            y.PerformanceMeasureID,
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

            if ((PerformanceMeasureExpecteds == null || !PerformanceMeasureExpecteds.Any()) && string.IsNullOrWhiteSpace(IndicatorNotes))
            {
                const string errorMessage = "You must provide one or more expected Performance Measures, or provide a brief note describing why the Performance Measures are not yet known for this proposal.";
                validationResults.Add(new SitkaValidationResult<ExpectedPerformanceMeasureValuesViewModel, string>(errorMessage, x => x.IndicatorNotes));
            }
            return validationResults;
        }
    }
}