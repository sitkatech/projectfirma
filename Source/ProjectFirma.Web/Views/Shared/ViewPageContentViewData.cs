using System;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Shared
{
    public class ViewPageContentViewData
    {
        public readonly FirmaSession CurrentFirmaSession;
        public readonly HtmlString FirmaPageContentHtmlString;
        public readonly string FirmaPageDisplayName;
        public readonly bool ShowEditButton;
        public readonly bool HasPageContent;
        public readonly string EditPageContentUrl;

        public ViewPageContentViewData(ProjectFirmaModels.Models.FirmaPage firmaPage, bool showEditButton, FirmaSession currentFirmaSession)
        {
            CurrentFirmaSession = currentFirmaSession;
            FirmaPageContentHtmlString = firmaPage.GetFirmaPageContentHtmlString();
            FirmaPageDisplayName = firmaPage.GetFirmaPageDisplayName();
            ShowEditButton = showEditButton;
            HasPageContent = firmaPage.HasPageContent();
            EditPageContentUrl = SitkaRoute<FirmaPageController>.BuildUrlFromExpression(t => t.EditInDialog(firmaPage));
        }

        public ViewPageContentViewData(ProjectFirmaModels.Models.CustomPage customPage, bool showEditButton, FirmaSession currentFirmaSession)
        {
            CurrentFirmaSession = currentFirmaSession;
            FirmaPageContentHtmlString = customPage.GetFirmaPageContentHtmlString();
            FirmaPageDisplayName = customPage.GetFirmaPageDisplayName();
            ShowEditButton = showEditButton;
            HasPageContent = customPage.HasPageContent();
            EditPageContentUrl = SitkaRoute<CustomPageController>.BuildUrlFromExpression(t => t.EditInDialog(customPage));
        }

        public ViewPageContentViewData(GeospatialAreaType geospatialAreaType, FirmaSession currentFirmaSession)
        {
            CurrentFirmaSession = currentFirmaSession;
            FirmaPageContentHtmlString = geospatialAreaType.GetFirmaPageContentHtmlString();
            FirmaPageDisplayName = geospatialAreaType.GetFirmaPageDisplayName();
            ShowEditButton = new GeospatialAreaManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            HasPageContent = geospatialAreaType.HasPageContent();
            EditPageContentUrl = SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(t => t.EditInDialog(geospatialAreaType));
        }
        public ViewPageContentViewData(ProjectFirmaModels.Models.Organization organization, FirmaSession currentFirmaSession)
        {
            CurrentFirmaSession = currentFirmaSession;
            FirmaPageContentHtmlString = organization.GetFirmaPageContentHtmlString();
            FirmaPageDisplayName = organization.GetFirmaPageDisplayName();
            ShowEditButton = new OrganizationBackgroundEditFeature().HasPermission(currentFirmaSession, organization).HasPermission;
            HasPageContent = organization.HasPageContent();
            EditPageContentUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.EditDescriptionInDialog(organization));
        }

        public ViewPageContentViewData(ProjectFirmaModels.Models.GeospatialArea geospatialArea, FirmaSession currentFirmaSession)
        {
            CurrentFirmaSession = currentFirmaSession;
            FirmaPageContentHtmlString = geospatialArea.GetFirmaPageContentHtmlString();
            FirmaPageDisplayName = geospatialArea.GetFirmaPageDisplayName();
            ShowEditButton = new GeospatialAreaManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            HasPageContent = geospatialArea.HasPageContent();
            EditPageContentUrl = SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(t => t.EditDescriptionInDialog(geospatialArea));
        }

        public ViewPageContentViewData(ProjectFirmaModels.Models.FirmaPage firmaPage, FirmaSession currentFirmaSession)
            : this(firmaPage, new FirmaPageManageFeature().HasPermission(currentFirmaSession, firmaPage).HasPermission, currentFirmaSession)
        {
        }

        public int CopyrightCalendarYear
        {
            get { return DateTime.Now.Year; }
        }

        // ReSharper disable once InconsistentNaming
        public string OptionalSQLDatabaseBackupFromProductionDateString
        {
            get
            {
                // This string is not shown in Prod, only QA and Localhost.
                // (Prod is always assumed to be current and definitive, and not a backup of anything else.)
                if (FirmaWebConfiguration.FirmaEnvironment.FirmaEnvironmentType == FirmaEnvironmentType.Prod)
                {
                    return string.Empty;
                }

                // An obviously fake date is shown if there are issues with the session. This value isn't
                // so crucial that we'd want to blow up if something went wrong with retrieving it.
                DateTime lastProductionDatabaseLoadTime = new DateTime(1111,11,11);

                // If we do have a valid session, we retrieve the last Backup's finish date.
                if (CurrentFirmaSession?.LastSqlServerDatabaseBackupInfo != null)
                {
                    // ReSharper disable once PossibleInvalidOperationException
                    lastProductionDatabaseLoadTime = this.CurrentFirmaSession.LastSqlServerDatabaseBackupInfo.BackupFinishDate.Value;
                }

                string lastProductionDatabaseLoadTimeString = lastProductionDatabaseLoadTime.ToString("yyyy-MM-dd HH:mm:ss");

                return $"Data from Production environment as of {lastProductionDatabaseLoadTimeString}.";
            }
        }
    }
}
