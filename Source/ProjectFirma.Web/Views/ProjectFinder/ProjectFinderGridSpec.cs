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
        public ProjectFinderGridSpec(FirmaSession currentFirmaSession)
        {
            SkinRowHeight = 30;
            InitWidthsByPercentage = true;

            Add(FieldDefinitionEnum.MatchScore.ToType().ToGridHeaderString(), x => x.GetMatchMakerScoreWithPopover(FieldDefinitionEnum.Project), 7, DhtmlxGridColumnFilterType.Numeric);
            Add(FieldDefinitionEnum.Project.ToType().ToGridHeaderString(), x => x.Project.GetDisplayNameAsUrl(), 15, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.Project.ProjectStage.ProjectStageDisplayName, 10, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Lead Implementer", x => x.Project.GetPrimaryContactOrganization().GetDisplayNameAsUrl(), 10, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.AreaOfInterest.ToType().GetFieldDefinitionLabel(), x => x.ScoreInsightDictionary[MatchmakerSubScoreTypeEnum.AreaOfInterest].Matched.ToCheckboxImageOrEmptyForGrid(), 10, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(FieldDefinitionEnum.MatchmakerKeyword.ToType().GetFieldDefinitionLabelPluralized(), x => x.ScoreInsightDictionary[MatchmakerSubScoreTypeEnum.MatchmakerKeyword].Matched.ToCheckboxImageOrEmptyForGrid(), 10, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(MultiTenantHelpers.GetTenantFieldDefinitionEnumForMatchmakerTaxonomy().ToType().GetFieldDefinitionLabelPluralized(), x => x.ScoreInsightDictionary[MatchmakerSubScoreTypeEnum.TaxonomySystem].Matched.ToCheckboxImageOrEmptyForGrid(), 10, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add(MultiTenantHelpers.GetTenantNameForClassificationForMatchmaker(true), x => x.ScoreInsightDictionary[MatchmakerSubScoreTypeEnum.Classification].Matched.ToCheckboxImageOrEmptyForGrid(), 10, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            if (MultiTenantHelpers.TrackAccomplishments())
            {
                Add(FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabelPluralized(), x => x.ScoreInsightDictionary[MatchmakerSubScoreTypeEnum.PerformanceMeasure].Matched.ToCheckboxImageOrEmptyForGrid(), 10, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            }
            Add("Map", x => GetMapButtonForProject(x.Project, currentFirmaSession), 8, DhtmlxGridColumnFilterType.None);
        }

        public static HtmlString GetMapButtonForProject(ProjectFirmaModels.Models.Project project, FirmaSession currentFirmaSession)
        {
            if (project.HasProjectLocationPoint(false))
            {
                return new HtmlString($"<form onsubmit=\"return false;\"data-id=\"{project.ProjectID}\"><button title=\"Zoom to this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} on the map\" class=\"grid-map-marker grid-map-marker-enabled\" type=\"submit\"><span class=\"glyphicon glyphicon-map-marker\"></span></button></form>");

            }
            return new HtmlString($"<button class=\"grid-map-marker grid-map-marker-disabled\" type=\"button\"><span onmouseover=\"ProjectFirma.Views.Methods.addTooltipPopup(this, 'No {FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is available. You can click the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} name for more information.')\" class=\"glyphicon glyphicon-map-marker\"></span></button>");
        }
    }
}