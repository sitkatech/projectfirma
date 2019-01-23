using System.Net.Mail;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static class NotificationModelExtensions
    {
        public static MailAddress DoNotReplyMailAddress()
        {
            return new MailAddress(FirmaWebConfiguration.DoNotReplyEmail, MultiTenantHelpers.GetToolDisplayName());
        }
    }
}