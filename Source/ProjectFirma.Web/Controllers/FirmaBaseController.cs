using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using log4net;
using LtInfo.Common;

namespace ProjectFirma.Web.Controllers
{
    [ValidateInput(false)]
    public abstract class FirmaBaseController : SitkaController
    {
        public static ControllerContext ControllerContextStatic = null;

        protected ILog Logger = LogManager.GetLogger(typeof(FirmaBaseController));

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!IsCurrentUserAnonymous())
            {
                CurrentPerson.LastActivityDate = DateTime.Now;
                HttpRequestStorage.DatabaseEntities.ChangeTracker.DetectChanges();
                HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing();
            }
            base.OnAuthorization(filterContext);
        }

        protected FirmaBaseController()
        {
            if (ControllerContextStatic == null)
                ControllerContextStatic = ControllerContext;
        }

        public static ReadOnlyCollection<MethodInfo> AllControllerActionMethods
        {
            get { return AllControllerActionMethodsProtected; }
        }

        static FirmaBaseController()
        {
            AllControllerActionMethodsProtected = new ReadOnlyCollection<MethodInfo>(GetAllControllerActionMethods(typeof(FirmaBaseController)));
        }

        protected override bool IsCurrentUserAnonymous()
        {
            return CurrentPerson == null || CurrentPerson.IsAnonymousUser;
        }

        protected override string LoginUrl
        {
            get { return FirmaHelpers.GenerateLogInUrlWithReturnUrl(); }
        }

        protected override ISitkaDbContext SitkaDbContext
        {
            get { return HttpRequestStorage.DatabaseEntities; }
        }

        protected Person CurrentPerson
        {
            get { return HttpRequestStorage.Person; }
        }

        protected Tenant CurrentTenant
        {
            get { return HttpRequestStorage.Tenant; }
        }
    }
}