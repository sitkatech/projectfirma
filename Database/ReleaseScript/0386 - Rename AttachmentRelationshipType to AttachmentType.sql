EXEC sp_rename 'dbo.AttachmentRelationshipType', 'AttachmentType';
EXEC sp_rename 'dbo.AttachmentRelationshipTypeFileResourceMimeType', 'AttachmentTypeFileResourceMimeType';
EXEC sp_rename 'dbo.AttachmentRelationshipTypeTaxonomyTrunk', 'AttachmentTypeTaxonomyTrunk';

EXEC sp_rename 'dbo.AttachmentType.AttachmentRelationshipTypeID', 'AttachmentTypeID', 'COLUMN';
EXEC sp_rename 'dbo.AttachmentType.AttachmentRelationshipTypeName', 'AttachmentTypeName', 'COLUMN';
EXEC sp_rename 'dbo.AttachmentType.AttachmentRelationshipTypeDescription', 'AttachmentTypeDescription', 'COLUMN';

EXEC sp_rename 'dbo.AK_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID', 'AK_AttachmentType_AttachmentTypeID_TenantID', 'OBJECT';
EXEC sp_rename 'dbo.AK_AttachmentRelationshipType_AttachmentRelationshipTypeName_TenantID', 'AK_AttachmentType_AttachmentTypeName_TenantID', 'OBJECT';
EXEC sp_rename 'dbo.AttachmentType.PK_AttachmentRelationshipType_AttachmentRelationshipTypeID', 'PK_AttachmentType_AttachmentTypeID', 'INDEX';

EXEC sp_rename 'dbo.ProjectAttachment.AttachmentRelationshipTypeID', 'AttachmentTypeID', 'COLUMN';
EXEC sp_rename 'dbo.ProjectAttachmentUpdate.AttachmentRelationshipTypeID', 'AttachmentTypeID', 'COLUMN';

EXEC sp_rename 'dbo.AttachmentTypeFileResourceMimeType.AttachmentRelationshipTypeFileResourceMimeTypeID', 'AttachmentTypeFileResourceMimeTypeID', 'COLUMN';
EXEC sp_rename 'dbo.AttachmentTypeFileResourceMimeType.AttachmentRelationshipTypeID', 'AttachmentTypeID', 'COLUMN';

EXEC sp_rename 'dbo.AttachmentTypeFileResourceMimeType.PK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipTypeFileResourceMimeTypeID', 'PK_AttachmentTypeFileResourceMimeType_AttachmentTypeFileResourceMimeTypeID', 'INDEX';

EXEC sp_rename 'dbo.AttachmentTypeTaxonomyTrunk.AttachmentRelationshipTypeTaxonomyTrunkID', 'AttachmentTypeTaxonomyTrunkID', 'COLUMN';
EXEC sp_rename 'dbo.AttachmentTypeTaxonomyTrunk.AttachmentRelationshipTypeID', 'AttachmentTypeID', 'COLUMN';

EXEC sp_rename 'dbo.AttachmentTypeTaxonomyTrunk.PK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipTypeTaxonomyTrunkID', 'PK_AttachmentTypeTaxonomyTrunk_AttachmentTypeTaxonomyTrunkID', 'INDEX';
