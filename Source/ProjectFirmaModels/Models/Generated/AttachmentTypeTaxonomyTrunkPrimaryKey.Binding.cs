//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AttachmentTypeTaxonomyTrunk
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AttachmentTypeTaxonomyTrunkPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AttachmentTypeTaxonomyTrunk>
    {
        public AttachmentTypeTaxonomyTrunkPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AttachmentTypeTaxonomyTrunkPrimaryKey(AttachmentTypeTaxonomyTrunk attachmentTypeTaxonomyTrunk) : base(attachmentTypeTaxonomyTrunk){}

        public static implicit operator AttachmentTypeTaxonomyTrunkPrimaryKey(int primaryKeyValue)
        {
            return new AttachmentTypeTaxonomyTrunkPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AttachmentTypeTaxonomyTrunkPrimaryKey(AttachmentTypeTaxonomyTrunk attachmentTypeTaxonomyTrunk)
        {
            return new AttachmentTypeTaxonomyTrunkPrimaryKey(attachmentTypeTaxonomyTrunk);
        }
    }
}