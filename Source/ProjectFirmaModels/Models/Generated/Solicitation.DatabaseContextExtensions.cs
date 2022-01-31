//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Solicitation]
using System.Collections.Generic;
using System.Linq;
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

    }
}