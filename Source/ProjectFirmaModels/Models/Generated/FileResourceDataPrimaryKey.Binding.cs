//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FileResourceData
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FileResourceDataPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FileResourceData>
    {
        public FileResourceDataPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FileResourceDataPrimaryKey(FileResourceData fileResourceData) : base(fileResourceData){}

        public static implicit operator FileResourceDataPrimaryKey(int primaryKeyValue)
        {
            return new FileResourceDataPrimaryKey(primaryKeyValue);
        }

        public static implicit operator FileResourceDataPrimaryKey(FileResourceData fileResourceData)
        {
            return new FileResourceDataPrimaryKey(fileResourceData);
        }
    }
}