//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProjectNote
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProjectNote>
    {
        public ProposedProjectNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectNotePrimaryKey(ProposedProjectNote proposedProjectNote) : base(proposedProjectNote){}

        public static implicit operator ProposedProjectNotePrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectNotePrimaryKey(ProposedProjectNote proposedProjectNote)
        {
            return new ProposedProjectNotePrimaryKey(proposedProjectNote);
        }
    }
}