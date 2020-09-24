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
            organization.OrganizationMatchmakerKeywords.Select(omk => omk.MatchmakerKeyword).ForEach(mmk => mmk.Delete(databaseEntities));
            organization.OrganizationMatchmakerKeywords.ToList().ForEach(omk => omk.Delete(databaseEntities));
            var matchmakerKeywords = GetMatchmakerKeywordsFromJson();
            organization.OrganizationMatchmakerKeywords = matchmakerKeywords.OrderBy(mk => mk.MatchmakerKeywordName).Select(mk => new OrganizationMatchmakerKeyword(organization, mk)).ToList();
        }

        private List<MatchmakerKeyword> GetMatchmakerKeywordsFromJson()
        {
            List<string> matchmakerKeywordStrings = JsonConvert.DeserializeObject<List<string>>(this.MatchmakerKeywordsJson);
            List<MatchmakerKeyword> matchmakerKeywords = matchmakerKeywordStrings.Select(mks => new MatchmakerKeyword(mks)).ToList();
            return matchmakerKeywords;
        }

        private void SetMatchmakerKeywordsJson(ProjectFirmaModels.Models.Organization organization)
        {
            List<string> matchmakerKeywordStrings = organization.OrganizationMatchmakerKeywords.Select(mmk => mmk.MatchmakerKeyword.MatchmakerKeywordName).ToList();
            string matchmakerKeywordStringsAsJson = JsonConvert.SerializeObject(matchmakerKeywordStrings);
            this.MatchmakerKeywordsJson = matchmakerKeywordStringsAsJson;
        }

    }
}



