using System;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Shared
{
    public class CustomFooterViewData
    {
        public FirmaSession CurrentFirmaSession { get; }

        public ViewPageContentViewData ViewPageContentViewData {get;}

        public CustomFooterViewData(ProjectFirmaModels.Models.FirmaPage firmaPage, bool showEditButton, FirmaSession currentFirmaSession)
        {
            CurrentFirmaSession = currentFirmaSession;
            ViewPageContentViewData = new ViewPageContentViewData(firmaPage, showEditButton);
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
