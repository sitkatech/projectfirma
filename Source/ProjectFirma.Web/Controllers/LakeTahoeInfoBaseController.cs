using System;
using System.Collections.Generic;
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
    public abstract class LakeTahoeInfoBaseController : SitkaController
    {
        private static readonly List<int> PersonIDsToIgnore = new List<int> { 1170, 1171 };

        public static ControllerContext ControllerContextStatic = null;

        protected ILog Logger = LogManager.GetLogger(typeof(LakeTahoeInfoBaseController));

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!IsCurrentUserAnonymous())
            {
                if (!PersonIDsToIgnore.Contains(CurrentPerson.PersonID)) // TODO: temporary hack to ignore the temps usings the same logins
                {
                    CurrentPerson.LastActivityDate = DateTime.Now;
                    SitkaDbContext.GetDbContext().ChangeTracker.DetectChanges();
                    SitkaDbContext.GetDbContext().SaveChanges();
                }
            }
            base.OnAuthorization(filterContext);
        }

        protected LakeTahoeInfoBaseController()
        {
            if (ControllerContextStatic == null)
                ControllerContextStatic = ControllerContext;
        }

        public static ReadOnlyCollection<MethodInfo> AllControllerActionMethods
        {
            get { return AllControllerActionMethodsProtected; }
        }

        static LakeTahoeInfoBaseController()
        {
            AllControllerActionMethodsProtected = new ReadOnlyCollection<MethodInfo>(GetAllControllerActionMethods(typeof(LakeTahoeInfoBaseController)));
        }

        protected override bool IsCurrentUserAnonymous()
        {
            return CurrentPerson == null || CurrentPerson.IsAnonymousUser;
        }

        protected override string LoginUrl
        {
            get { return ProjectFirmaHelpers.GenerateLogInUrlWithReturnUrl(); }
        }

        protected override ISitkaDbContext SitkaDbContext
        {
            get { return HttpRequestStorage.DatabaseEntities; }
        }

        protected Person CurrentPerson
        {
            get { return HttpRequestStorage.Person; }
        }
    }
}