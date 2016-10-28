using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class Program : IAuditableEntity
    {
        public string DisplayNumber
        {
            get { return GetDisplayNumberString(FocusArea.DisplayNumber, ProgramNumber); }
        }

        private static string GetDisplayNumberString(string displayNumber, byte programNumber)
        {
            return String.Format("{0}.{1:00}", displayNumber, programNumber);
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<ProgramController>.BuildUrlFromExpression(c => c.DeleteProgram(ProgramID)); }
        }

        public ICollection<Project> Projects
        {
            get { return ActionPriorities.SelectMany(x => x.Projects).ToList(); }
        }

        public string DisplayName
        {
            get { return String.Format("{0} - {1}", DisplayNumber, ProgramName); }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName); }
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<ProgramController>.BuildUrlFromExpression(x => x.Summary(ProgramID)); }
        }

        public string CustomizedMapUrl
        {
            get { return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.Program, ProgramID.ToString(), ProjectColorByType.ProjectStage); }
        }


        public string DefinitionAndGuidanceUrl
        {
            get { return SitkaRoute<ProgramController>.BuildUrlFromExpression(x => x.DefinitionAndGuidance(this)); }
        }

        public static byte GetNextProgramNumberForFocusArea(IQueryable<Program> existingPrograms, int focusAreaID)
        {
            var programsForFocusArea = existingPrograms.Where(x => x.FocusAreaID == focusAreaID).ToList();
            byte nextProgramNumber = 1;
            if (programsForFocusArea.Any())
            {
                nextProgramNumber += programsForFocusArea.Max(x => x.ProgramNumber);
            }
            return nextProgramNumber;
        }

        public static bool IsProgramNameUnique(IEnumerable<Program> programs, string programName, int currentProgramID)
        {
            var program = programs.SingleOrDefault(x => x.ProgramID != currentProgramID && String.Equals(x.ProgramName, programName, StringComparison.InvariantCultureIgnoreCase));
            return program == null;
        }

        public string AuditDescriptionString
        {
            get { return ProgramName; }
        }

        public List<PerformanceMeasure> GetPerformanceMeasures()
        {
            var primaryPerformanceMeasures = ProgramPerformanceMeasures.Where(x => x.IsPrimaryProgram).OrderBy(x => x.PerformanceMeasureID).Select(x => x.PerformanceMeasure).ToList();

            var secondaryPerformanceMeasures =
                new List<PerformanceMeasure>(
                    HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Where(
                        x =>
                            x.PerformanceMeasureTypeID == PerformanceMeasureType.PerformanceMeasure33.PerformanceMeasureTypeID ||
                            x.PerformanceMeasureTypeID == PerformanceMeasureType.PerformanceMeasure34.PerformanceMeasureTypeID).ToList());

            var performanceMeasures = new List<PerformanceMeasure>();
            performanceMeasures.AddRange(primaryPerformanceMeasures);
            performanceMeasures.AddRange(secondaryPerformanceMeasures);
            return performanceMeasures;
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(string.Format("{0} - {1}", DisplayNumber, UrlTemplate.MakeHrefString(SummaryUrl, ProgramName)), FocusAreaID.ToString(), false)
            {
                ThemeColor = FocusArea.FocusAreaColor,
                MapUrl = CustomizedMapUrl,
                Children = ActionPriorities.Select(x => x.ToFancyTreeNode()).ToList()
            };
            return fancyTreeNode;
        }
    }
}