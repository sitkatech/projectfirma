using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ApprovalUtilities.Utilities;
using LtInfo.Common.Models;
using Newtonsoft.Json;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Keyword
{
    public class MatchmakerKeywordsModalViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [DisplayName("MatchmakerKeywordsJson")]
        public string MatchmakerKeywordsJson { get; set; }

        public MatchmakerKeywordsModalViewModel()
        {
        }

        public MatchmakerKeywordsModalViewModel(ProjectFirmaModels.Models.Organization organization)
        {
            SetMatchmakerKeywordsJson(organization);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            return validationResults;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Organization organization, 
                                DatabaseEntities databaseEntities,
                                FirmaSession currentFirmaSession)
        {
            // Keyword strings coming off the form
            List<String> matchmakerKeywordStringsFromForm = GetKeywordStringsFromJsonFormVariable();

            // Find MatchmakerKeywords that aren't already saved, across all Organizations for this Tenant
            List<string> matchmakerKeywordStringsThatAreNotAlreadySavedInTable
                = matchmakerKeywordStringsFromForm.Where(ks => !databaseEntities.MatchmakerKeywords.Any(dmk => dmk.MatchmakerKeywordName == ks)).ToList();

            // Make sure we save these all-new MatchmakerKeywords
            var previouslyUnknownMatchmakerKeywordsForThisTenant = matchmakerKeywordStringsThatAreNotAlreadySavedInTable
                .Select(ks => new MatchmakerKeyword(ks)).ToList();
            databaseEntities.AllMatchmakerKeywords.AddRange(previouslyUnknownMatchmakerKeywordsForThisTenant);

            // Delete ALL OrganizationMatchmakerKeywords for this particular Organization
            organization.OrganizationMatchmakerKeywords.ToList().ForEach(omk => omk.Delete(databaseEntities));

            // Get the MatchmakerKeywords for all the incoming form variables. Some of these may be existing, some may be newly created.

            // First, the existing
            var matchMakerKeywordsWeNeedToAssociateToThisOrg = databaseEntities.MatchmakerKeywords.Where(mk => matchmakerKeywordStringsFromForm.Contains(mk.MatchmakerKeywordName)).ToList();
            // Next, the new
            matchMakerKeywordsWeNeedToAssociateToThisOrg.AddRange(previouslyUnknownMatchmakerKeywordsForThisTenant);

            // Make new OrganizationMatchmakerKeywords
            organization.OrganizationMatchmakerKeywords = matchMakerKeywordsWeNeedToAssociateToThisOrg.OrderBy(mk => mk.MatchmakerKeywordName).Select(mk => new OrganizationMatchmakerKeyword(organization, mk)).ToList();
        }

        private List<String> GetKeywordStringsFromJsonFormVariable()
        {
            List<string> matchmakerKeywordStrings = JsonConvert.DeserializeObject<List<string>>(this.MatchmakerKeywordsJson);
            // Deliberately trim, then de-dupe. Found issues with extra trailing spaces in testing.
            matchmakerKeywordStrings = matchmakerKeywordStrings.Select(s => s.Trim().ToLower()).Distinct().ToList();
            return matchmakerKeywordStrings;
        }

        private void SetMatchmakerKeywordsJson(ProjectFirmaModels.Models.Organization organization)
        {
            List<string> matchmakerKeywordStrings = organization.OrganizationMatchmakerKeywords.Select(mmk => mmk.MatchmakerKeyword.MatchmakerKeywordName).ToList();
            string matchmakerKeywordStringsAsJson = JsonConvert.SerializeObject(matchmakerKeywordStrings);
            this.MatchmakerKeywordsJson = matchmakerKeywordStringsAsJson;
        }

    }
}



