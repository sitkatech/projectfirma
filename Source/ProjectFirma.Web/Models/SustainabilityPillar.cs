namespace ProjectFirma.Web.Models
{
    public partial class SustainabilityPillar
    {
        private static string _imageRoot = "/Areas/Sustainability/Content/";
        public string GetKeyImageFullPath()
        {
            return string.Format("{0}{1}", _imageRoot, KeyImageFileName);
        }

        public string GetAdditionalDisplayHtml()
        {
            if (SustainabilityPillarName != "Economy")
            {
                return string.Empty;
            }

            return string.Format(@"
<div class=""block-item no-hover"">
    <div class=""item-wrap"">
        <div class=""thumb-overlay""></div>
        <div class=""text-overlay"">
            <div class=""text"">
                <div>
                    <span class=""subhead"">Brought to you by</span>
                </div>
                <h3>Tahoe Regional Planning Agency</h3>
            </div>
        </div>
        <img alt="""" src=""{0}brought_to_you_by_trpa.jpg"">
    </div>
</div>", _imageRoot);
        }
    }
}