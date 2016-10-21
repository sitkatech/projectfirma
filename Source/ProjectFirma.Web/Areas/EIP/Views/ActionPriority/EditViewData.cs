using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.ActionPriority
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> Programs;
        public readonly string ProgramDisplayName;
        public readonly bool HasProjects;

        public EditViewData(IEnumerable<SelectListItem> programs, string programDisplayName, bool hasProjects)
        {
            Programs = programs;
            ProgramDisplayName = programDisplayName;
            HasProjects = hasProjects;
        }
    }
}