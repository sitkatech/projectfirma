using System.Linq;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Classification GetClassificationByClassificationeName(this IQueryable<Classification> classifications, string classificationName)
        {
            var classification = classifications.SingleOrDefault(x => x.ClassificationName == classificationName);
            Check.RequireNotNullThrowNotFound(classification, MultiTenantHelpers.GetClassificationDisplayName(), classificationName);
            return classification;
        }
    }
}