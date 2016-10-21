//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProjectImage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProjectImage>
    {
        public ProposedProjectImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectImagePrimaryKey(ProposedProjectImage proposedProjectImage) : base(proposedProjectImage){}

        public static implicit operator ProposedProjectImagePrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectImagePrimaryKey(ProposedProjectImage proposedProjectImage)
        {
            return new ProposedProjectImagePrimaryKey(proposedProjectImage);
        }
    }
}