using System.Linq;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class FirmaPageModelExtensions
    {
        public static FirmaPageType ToType(this FirmaPageTypeEnum psInfoPageTypeEnum)
        {
            return ToType((int)psInfoPageTypeEnum);
        }

        public static FirmaPageType ToType(int fieldDefinitionID)
        {
            return HttpRequestStorage.DatabaseEntities.FirmaPageTypes.SingleOrDefault(x => x.FirmaPageTypeID == fieldDefinitionID);
        }

        public static FirmaPage GetFirmaPage(this FirmaPageType firmaPageType)
        {
            return firmaPageType.FirmaPages.SingleOrDefault(x => x.TenantID == HttpRequestStorage.Tenant.TenantID);
        }
        public static FirmaPage GetFirmaPage(this FirmaPageTypeEnum firmaPageTypeEnum)
        {
            return  GetFirmaPage(firmaPageTypeEnum.ToType());
        }
    }
}