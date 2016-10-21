namespace ProjectFirma.Web.Models
{
    public class FocusAreaForReporting
    {
        public int FocusAreaID
        {
            get { return _focusArea.FocusAreaID; }
        }
        public string DisplayName
        {
            get { return _focusArea.DisplayName; }
        }
        private readonly FocusArea _focusArea;

        public FocusAreaForReporting(FocusArea focusArea)
        {
            _focusArea = focusArea;
        }
    }
}