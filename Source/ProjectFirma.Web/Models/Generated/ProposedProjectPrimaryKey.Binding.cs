//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProject
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProject>
    {
        public ProposedProjectPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectPrimaryKey(ProposedProject proposedProject) : base(proposedProject){}

        public static implicit operator ProposedProjectPrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectPrimaryKey(ProposedProject proposedProject)
        {
            return new ProposedProjectPrimaryKey(proposedProject);
        }
    }
}