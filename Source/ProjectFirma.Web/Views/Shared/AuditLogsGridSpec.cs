using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Shared
{
    public class AuditLogsGridSpec : GridSpec<AuditLog>
    {
        public AuditLogsGridSpec()
        {
            Add("Date", a => a.AuditLogDate, 120);
            Add("User", a => a.Person.GetFullNameFirstLastAndOrgAsUrl(), 300);
            Add("Section", a => a.TableName.ToProperCase(), 200, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Description", a => a.AuditDescriptionDisplay, 400);
        }
    }
}