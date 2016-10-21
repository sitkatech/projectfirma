//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProgramImage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProgramImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProgramImage>
    {
        public ProgramImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProgramImagePrimaryKey(ProgramImage programImage) : base(programImage){}

        public static implicit operator ProgramImagePrimaryKey(int primaryKeyValue)
        {
            return new ProgramImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProgramImagePrimaryKey(ProgramImage programImage)
        {
            return new ProgramImagePrimaryKey(programImage);
        }
    }
}