using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class EditPageContentViewData : FirmaViewData
    {
        public readonly string DisplayUrl;

        public EditPageContentViewData(Person currentPerson, FirmaPageType firmaPageType)
            : base(currentPerson, Models.FirmaPage.GetFirmaPageByPageType(firmaPageType))
        {
            PageTitle = firmaPageType.FirmaPageTypeDisplayName;
            DisplayUrl = firmaPageType.GetViewUrl();
        }        
    }
}