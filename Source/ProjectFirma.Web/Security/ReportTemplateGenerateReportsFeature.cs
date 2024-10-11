using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Can generate reports on Projects using existing report templates")]
    public class ReportTemplateGenerateReportsFeature : FirmaFeature
    {
        public ReportTemplateGenerateReportsFeature() : base(
            MultiTenantHelpers.GetTenantAttributeFromCache().AreReportsPublic
                ? new List<Role>()
                : new List<Role> { Role.ESAAdmin, Role.Admin, Role.ProjectSteward }) { }
    }
}