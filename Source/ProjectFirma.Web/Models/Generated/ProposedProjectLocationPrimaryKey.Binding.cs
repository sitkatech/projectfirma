//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProjectLocation
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectLocationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProjectLocation>
    {
        public ProposedProjectLocationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectLocationPrimaryKey(ProposedProjectLocation proposedProjectLocation) : base(proposedProjectLocation){}

        public static implicit operator ProposedProjectLocationPrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectLocationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectLocationPrimaryKey(ProposedProjectLocation proposedProjectLocation)
        {
            return new ProposedProjectLocationPrimaryKey(proposedProjectLocation);
        }
    }
}