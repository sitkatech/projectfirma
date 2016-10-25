using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public partial class FirmaPage
    {
        public bool HasFirmaPageContent
        {
            get { return !string.IsNullOrWhiteSpace(FirmaPageContent); }
        }

        public static FirmaPage GetFirmaPageByPageType(FirmaPageType firmaPageType)
        {
            var firmaPage = HttpRequestStorage.DatabaseEntities.FirmaPages.SingleOrDefault(x => x.FirmaPageTypeID == firmaPageType.FirmaPageTypeID);
            Check.RequireNotNull(firmaPage);
            return firmaPage;
        }
    }
}