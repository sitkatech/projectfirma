//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.DocumentLibrary
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class DocumentLibraryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<DocumentLibrary>
    {
        public DocumentLibraryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public DocumentLibraryPrimaryKey(DocumentLibrary documentLibrary) : base(documentLibrary){}

        public static implicit operator DocumentLibraryPrimaryKey(int primaryKeyValue)
        {
            return new DocumentLibraryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator DocumentLibraryPrimaryKey(DocumentLibrary documentLibrary)
        {
            return new DocumentLibraryPrimaryKey(documentLibrary);
        }
    }
}