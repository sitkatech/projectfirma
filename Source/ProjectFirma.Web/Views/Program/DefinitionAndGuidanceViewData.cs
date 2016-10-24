using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Program
{
    public class DefinitionAndGuidanceViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.Program Program;

        public DefinitionAndGuidanceViewData(Models.Program program)
        {
            Program = program;
        }
    }
}