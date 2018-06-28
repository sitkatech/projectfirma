using System.Collections.Generic;
using System.Web;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class EditProjectUpdateConfigurationViewData : FirmaViewData
    {
        public EditProjectUpdateConfigurationViewData(Person currentPerson, List<string> projectsForPreview) : base(currentPerson)
        {
            SampleProjectList = new HtmlString(string.Join("\r\n", projectsForPreview));
        }

        public HtmlString SampleProjectList { get; set; }
    }
}
