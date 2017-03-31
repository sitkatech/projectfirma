using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Tenant
{
    public class IndexViewData : FirmaViewData
    {
        public IndexViewData(Person currentPerson) : base(currentPerson)
        {
        }
    }
}