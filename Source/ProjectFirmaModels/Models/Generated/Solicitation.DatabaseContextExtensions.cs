//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Solicitation]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Solicitation GetSolicitation(this IQueryable<Solicitation> solicitations, int solicitationID)
        {
            var solicitation = solicitations.SingleOrDefault(x => x.SolicitationID == solicitationID);
            Check.RequireNotNullThrowNotFound(solicitation, "Solicitation", solicitationID);
            return solicitation;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteSolicitation(this IQueryable<Solicitation> solicitations, List<int> solicitationIDList)
        {
            if(solicitationIDList.Any())
            {
                solicitations.Where(x => solicitationIDList.Contains(x.SolicitationID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteSolicitation(this IQueryable<Solicitation> solicitations, ICollection<Solicitation> solicitationsToDelete)
        {
            if(solicitationsToDelete.Any())
            {
                var solicitationIDList = solicitationsToDelete.Select(x => x.SolicitationID).ToList();
                solicitations.Where(x => solicitationIDList.Contains(x.SolicitationID)).Delete();
            }
        }

        public static void DeleteSolicitation(this IQueryable<Solicitation> solicitations, int solicitationID)
        {
            DeleteSolicitation(solicitations, new List<int> { solicitationID });
        }

        public static void DeleteSolicitation(this IQueryable<Solicitation> solicitations, Solicitation solicitationToDelete)
        {
            DeleteSolicitation(solicitations, new List<Solicitation> { solicitationToDelete });
        }
    }
}