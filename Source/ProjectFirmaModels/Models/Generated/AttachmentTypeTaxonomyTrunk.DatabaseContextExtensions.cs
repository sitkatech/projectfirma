//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentTypeTaxonomyTrunk]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AttachmentTypeTaxonomyTrunk GetAttachmentTypeTaxonomyTrunk(this IQueryable<AttachmentTypeTaxonomyTrunk> attachmentTypeTaxonomyTrunks, int attachmentTypeTaxonomyTrunkID)
        {
            var attachmentTypeTaxonomyTrunk = attachmentTypeTaxonomyTrunks.SingleOrDefault(x => x.AttachmentTypeTaxonomyTrunkID == attachmentTypeTaxonomyTrunkID);
            Check.RequireNotNullThrowNotFound(attachmentTypeTaxonomyTrunk, "AttachmentTypeTaxonomyTrunk", attachmentTypeTaxonomyTrunkID);
            return attachmentTypeTaxonomyTrunk;
        }

    }
}