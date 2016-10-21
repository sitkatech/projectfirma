//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Program
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProgramPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Program>
    {
        public ProgramPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProgramPrimaryKey(Program program) : base(program){}

        public static implicit operator ProgramPrimaryKey(int primaryKeyValue)
        {
            return new ProgramPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProgramPrimaryKey(Program program)
        {
            return new ProgramPrimaryKey(program);
        }
    }
}