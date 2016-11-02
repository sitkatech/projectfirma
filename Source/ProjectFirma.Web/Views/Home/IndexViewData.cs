using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Home
{
    public class IndexViewData : FirmaViewData
    {
        public IndexViewData(Person currentPerson,
            Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = "Clackamas Partnership Project Tracker";
        }
    }
}