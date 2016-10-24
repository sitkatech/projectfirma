using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class CustomNotificationViewModel : FormViewModel
    {
        [Required]
        public List<int> PersonIDList { get; set; }

        public string NotificationContent { get; set; }
        
        [Required]
        public string Subject { get; set; }

        public CustomNotificationViewModel()
        {
            PersonIDList = new List<int>();
        }
    
}
}
