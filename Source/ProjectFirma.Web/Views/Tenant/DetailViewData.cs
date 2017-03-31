using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Tenant
{
    public class DetailViewData : FirmaViewData {
        public DetailViewData(Person currentPerson, Models.Tenant tenant) : base(currentPerson)
        {
        }
    }
}