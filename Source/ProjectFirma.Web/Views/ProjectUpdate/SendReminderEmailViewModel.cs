using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class SendReminderEmailViewModel : FormViewModel
    {
        public ReminderMessageTypeEnum ReminderMessageTypeEnum { get; set; }
    }
}