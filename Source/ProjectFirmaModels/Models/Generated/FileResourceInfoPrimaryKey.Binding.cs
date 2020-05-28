//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FileResourceInfo
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FileResourceInfoPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FileResourceInfo>
    {
        public FileResourceInfoPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FileResourceInfoPrimaryKey(FileResourceInfo fileResourceInfo) : base(fileResourceInfo){}

        public static implicit operator FileResourceInfoPrimaryKey(int primaryKeyValue)
        {
            return new FileResourceInfoPrimaryKey(primaryKeyValue);
        }

        public static implicit operator FileResourceInfoPrimaryKey(FileResourceInfo fileResourceInfo)
        {
            return new FileResourceInfoPrimaryKey(fileResourceInfo);
        }
    }
}