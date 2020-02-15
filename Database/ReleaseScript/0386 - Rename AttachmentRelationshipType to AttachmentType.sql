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

exec sp_rename 'FK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipType_AttachmentRelationshipTypeID', 'FK_AttachmentTypeFileResourceMimeType_AttachmentType_AttachmentTypeID', 'OBJECT'
exec sp_rename 'FK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID', 'FK_AttachmentTypeFileResourceMimeType_AttachmentType_AttachmentTypeID_TenantID', 'OBJECT'
exec sp_rename 'FK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipType_AttachmentRelationshipTypeID', 'FK_AttachmentTypeTaxonomyTrunk_AttachmentType_AttachmentTypeID', 'OBJECT'
exec sp_rename 'FK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID', 'FK_AttachmentTypeTaxonomyTrunk_AttachmentType_AttachmentTypeID_TenantID', 'OBJECT'
exec sp_rename 'FK_ProjectAttachment_AttachmentRelationshipType_AttachmentRelationshipTypeID', 'FK_ProjectAttachment_AttachmentType_AttachmentTypeID', 'OBJECT'
exec sp_rename 'FK_ProjectAttachment_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID', 'FK_ProjectAttachment_AttachmentType_AttachmentTypeID_TenantID', 'OBJECT'
exec sp_rename 'FK_ProjectAttachmentUpdate_AttachmentRelationshipType_AttachmentRelationshipTypeID', 'FK_ProjectAttachmentUpdate_AttachmentType_AttachmentTypeID', 'OBJECT'
exec sp_rename 'FK_ProjectAttachmentUpdate_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID', 'FK_ProjectAttachmentUpdate_AttachmentType_AttachmentTypeID_TenantID', 'OBJECT'
exec sp_rename 'FK_AttachmentRelationshipTypeFileResourceMimeType_FileResourceMimeType_FileResourceMimeTypeID', 'FK_AttachmentTypeFileResourceMimeType_FileResourceMimeType_FileResourceMimeTypeID', 'OBJECT'
exec sp_rename 'FK_AttachmentRelationshipTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID', 'FK_AttachmentTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID', 'OBJECT'
exec sp_rename 'FK_AttachmentRelationshipTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID_TenantID', 'FK_AttachmentTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID_TenantID', 'OBJECT'
exec sp_rename 'FK_AttachmentRelationshipType_Tenant_TenantID', 'FK_AttachmentType_Tenant_TenantID', 'OBJECT'
exec sp_rename 'FK_AttachmentRelationshipTypeFileResourceMimeType_Tenant_TenantID', 'FK_AttachmentTypeFileResourceMimeType_Tenant_TenantID', 'OBJECT'
exec sp_rename 'FK_AttachmentRelationshipTypeTaxonomyTrunk_Tenant_TenantID', 'FK_AttachmentTypeTaxonomyTrunk_Tenant_TenantID', 'OBJECT'

