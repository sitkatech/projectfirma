//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Tag
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TagPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Tag>
    {
        public TagPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TagPrimaryKey(Tag tag) : base(tag){}

        public static implicit operator TagPrimaryKey(int primaryKeyValue)
        {
            return new TagPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TagPrimaryKey(Tag tag)
        {
            return new TagPrimaryKey(tag);
        }
    }
}