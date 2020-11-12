using System.Data.Entity.Infrastructure.Pluralization;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.PartnerFinder;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectFinder
{
    public class ProjectFinderGridSpec : GridSpec<PartnerOrganizationMatchMakerScore>
    {
        public ProjectFinderGridSpec()
        {
            SkinRowHeight = 30;
            InitWidthsByPercentage = true;

            Add(FieldDefinitionEnum.MatchScore.ToType().GetFieldDefinitionLabelPluralized(), x => (decimal) x.PartnerOrganizationFitnessScoreNumber, 5);
            Add(FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized(), x => x.Project.GetDisplayNameAsUrl(), 20, DhtmlxGridColumnFilterType.Html);
            Add("Lead Implementer", x => x.Project.GetPrimaryContactOrganization().GetDisplayNameAsUrl(), 15, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.MatchmakerKeyword.ToType().GetFieldDefinitionLabelPluralized(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.MatchmakerKeyword].Matched.ToCheckboxImageOrEmptyForGrid(), 10, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.AreaOfInterest.ToType().GetFieldDefinitionLabelPluralized(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.AreaOfInterest].Matched.ToCheckboxImageOrEmptyForGrid(), 10, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(MultiTenantHelpers.GetTenantFieldDefinitionEnumForMatchmakerTaxonomy().ToType().GetFieldDefinitionLabelPluralized(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.TaxonomySystem].Matched.ToCheckboxImageOrEmptyForGrid(), 10, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(MultiTenantHelpers.GetTenantNameForClassificationForMatchmaker(true), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.Classification].Matched.ToCheckboxImageOrEmptyForGrid(), 10, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabelPluralized(), x => x.ScoreInsightDictionary[MatchMakerScoreSubScoreInsight.MatchmakerSubScoreType.PerformanceMeasure].Matched.ToCheckboxImageOrEmptyForGrid(), 10, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Map", x => GetMapButtonForProject(x.Project), 10, DhtmlxGridColumnFilterType.None);
        }

        public static HtmlString GetMapButtonForProject(ProjectFirmaModels.Models.Project project)
        {
            if (project.HasProjectLocationPoint)
            {
                return new HtmlString($"<form onsubmit=\"return false;\"data-id=\"{project.ProjectID}\"><button title=\"Zoom to this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} on the map\" class=\"grid-map-marker grid-map-marker-enabled\" type=\"submit\"><span class=\"glyphicon glyphicon-map-marker\"></span></button></form>");

            }
            return new HtmlString($"<button class=\"grid-map-marker grid-map-marker-disabled\" type=\"button\"><span onmouseover=\"ProjectFirma.Views.Methods.addTooltipPopup(this, 'No {FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is available. You can click the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} name for more information.')\" class=\"glyphicon glyphicon-map-marker\"></span></button>");
        }
    }
}