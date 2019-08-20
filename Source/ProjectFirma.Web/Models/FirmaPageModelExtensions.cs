using System.Linq;
using ProjectFirma.Web.Common;
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
            var firmaPage = firmaPageType.FirmaPages.SingleOrDefault(x => x.TenantID == HttpRequestStorage.Tenant.TenantID) ??
                            MakePlaceholderFirmaPageForDisplay(firmaPageType);
            return firmaPage;
        }

        /// <summary>
        /// If there is no FirmaPage defined where we expect one, we return a placeholder that indicates one needs to be created, instead of just crashing.
        /// </summary>
        /// <param name="firmaPageType"></param>
        /// <returns></returns>
        private static FirmaPage MakePlaceholderFirmaPageForDisplay(FirmaPageType firmaPageType)
        {
            var firmaPage = new FirmaPage(firmaPageType.FirmaPageTypeID);
            firmaPage.FirmaPageType = HttpRequestStorage.DatabaseEntities.FirmaPageTypes.GetFirmaPageType(firmaPageType.FirmaPageTypeID);
            firmaPage.FirmaPageContent = $"[No FirmaPage defined yet for FirmaPageType {firmaPageType.FirmaPageTypeDisplayName} for Tenant {HttpRequestStorage.Tenant.TenantName} (TenantID: {HttpRequestStorage.Tenant.TenantID})]";
            return firmaPage;
        }

        public static FirmaPage GetFirmaPage(this FirmaPageTypeEnum firmaPageTypeEnum)
        {
            return GetFirmaPage(firmaPageTypeEnum.ToType());
        }
    }
}