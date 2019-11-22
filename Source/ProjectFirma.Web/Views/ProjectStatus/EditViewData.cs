using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectStatus
{
    public class EditViewData : FirmaViewData
    {
        public EditViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
           
        }
    }
}
