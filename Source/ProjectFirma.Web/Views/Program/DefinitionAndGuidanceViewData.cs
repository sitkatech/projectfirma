namespace ProjectFirma.Web.Views.Program
{
    public class DefinitionAndGuidanceViewData : FirmaUserControlViewData
    {
        public readonly Models.Program Program;

        public DefinitionAndGuidanceViewData(Models.Program program)
        {
            Program = program;
        }
    }
}