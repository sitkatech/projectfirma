//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AttachmentRelationshipTypeTaxonomyTrunk
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AttachmentRelationshipTypeTaxonomyTrunkPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AttachmentRelationshipTypeTaxonomyTrunk>
    {
        public AttachmentRelationshipTypeTaxonomyTrunkPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AttachmentRelationshipTypeTaxonomyTrunkPrimaryKey(AttachmentRelationshipTypeTaxonomyTrunk attachmentRelationshipTypeTaxonomyTrunk) : base(attachmentRelationshipTypeTaxonomyTrunk){}

        public static implicit operator AttachmentRelationshipTypeTaxonomyTrunkPrimaryKey(int primaryKeyValue)
        {
            return new AttachmentRelationshipTypeTaxonomyTrunkPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AttachmentRelationshipTypeTaxonomyTrunkPrimaryKey(AttachmentRelationshipTypeTaxonomyTrunk attachmentRelationshipTypeTaxonomyTrunk)
        {
            return new AttachmentRelationshipTypeTaxonomyTrunkPrimaryKey(attachmentRelationshipTypeTaxonomyTrunk);
        }
    }
}