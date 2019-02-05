//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FileResource
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FileResourcePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FileResource>
    {
        public FileResourcePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FileResourcePrimaryKey(FileResource fileResource) : base(fileResource){}

        public static implicit operator FileResourcePrimaryKey(int primaryKeyValue)
        {
            return new FileResourcePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FileResourcePrimaryKey(FileResource fileResource)
        {
            return new FileResourcePrimaryKey(fileResource);
        }
    }
}