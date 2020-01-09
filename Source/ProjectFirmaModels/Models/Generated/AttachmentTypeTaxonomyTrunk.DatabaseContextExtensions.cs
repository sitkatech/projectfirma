//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentRelationshipTypeTaxonomyTrunk]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AttachmentRelationshipTypeTaxonomyTrunk GetAttachmentRelationshipTypeTaxonomyTrunk(this IQueryable<AttachmentRelationshipTypeTaxonomyTrunk> attachmentRelationshipTypeTaxonomyTrunks, int attachmentRelationshipTypeTaxonomyTrunkID)
        {
            var attachmentRelationshipTypeTaxonomyTrunk = attachmentRelationshipTypeTaxonomyTrunks.SingleOrDefault(x => x.AttachmentRelationshipTypeTaxonomyTrunkID == attachmentRelationshipTypeTaxonomyTrunkID);
            Check.RequireNotNullThrowNotFound(attachmentRelationshipTypeTaxonomyTrunk, "AttachmentRelationshipTypeTaxonomyTrunk", attachmentRelationshipTypeTaxonomyTrunkID);
            return attachmentRelationshipTypeTaxonomyTrunk;
        }

    }
}