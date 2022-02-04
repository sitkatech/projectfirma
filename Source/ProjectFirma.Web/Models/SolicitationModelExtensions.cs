using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class SolicitationModelExtensions
    {
        public static IEnumerable<Solicitation> GetActiveSolicitations(this IEnumerable<Solicitation> solicitations)
        {
            return solicitations.Where(x => x.IsActive);
        }
    }
}