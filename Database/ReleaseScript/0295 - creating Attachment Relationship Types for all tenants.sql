
--insert 'Document' attachment relationship type for all tenants
insert into dbo.AttachmentRelationshipType (TenantID, AttachmentRelationshipTypeName, AttachmentRelationshipTypeDescription, MaxFileSize)
	select TenantID as TenantID,
		   'Documents' as AttachmentRelationshipTypeName,
		   'Documents of any type that are related to your project' as AttachmentRelationshipTypeDescription,
		   51200000 as MaxFileSize
		from dbo.Tenant

--insert 'Data Set' attachment relationship type for all tenants except PSP
insert into dbo.AttachmentRelationshipType (TenantID, AttachmentRelationshipTypeName, AttachmentRelationshipTypeDescription, MaxFileSize)
	select TenantID as TenantID,
		   'Data Sets' as AttachmentRelationshipTypeName,
		   'Data Sets in an Excel format that are related to your project' as AttachmentRelationshipTypeDescription,
		   51200000 as MaxFileSize
		from dbo.Tenant
		where TenantID != 11


--insert allowed file types(ALL) for all 'Documents' attachment relationship types
insert into dbo.AttachmentRelationshipTypeFileResourceMimeType(TenantID, AttachmentRelationshipTypeID, FileResourceMimeTypeID)
select 
		art.TenantID as TenantID,
		art.AttachmentRelationshipTypeID as AttachmentRelationshipTypeID,
		frmt.FileResourceMimeTypeID as FileResourceMimeTypeID
from
	dbo.AttachmentRelationshipType as art
	cross join dbo.FileResourceMimeType as frmt
where 
	art.AttachmentRelationshipTypeName = 'Documents'


-- insert allowed files types(all excel files) for 'Data Sets' attachment relationship types
insert into dbo.AttachmentRelationshipTypeFileResourceMimeType(TenantID, AttachmentRelationshipTypeID, FileResourceMimeTypeID)
select 
		art.TenantID as TenantID,
		art.AttachmentRelationshipTypeID as AttachmentRelationshipTypeID,
		frmt.FileResourceMimeTypeID as FileResourceMimeTypeID
from
	dbo.AttachmentRelationshipType as art
	cross join dbo.FileResourceMimeType as frmt
where 
	art.AttachmentRelationshipTypeName = 'Data Sets' and
	frmt.FileResourceMimeTypeName like '%XLS%' --this will get all three excel types in the FileResouceMimeType table



--insert allowed taxonomy trunks(ALL) for all attachment relationship types
insert into dbo.AttachmentRelationshipTypeTaxonomyTrunk(TenantID, AttachmentRelationshipTypeID, TaxonomyTrunkID)
select 
		art.TenantID as TenantID,
		art.AttachmentRelationshipTypeID as AttachmentRelationshipTypeID,
		tt.TaxonomyTrunkID as TaxonomyTrunkID
from
	dbo.AttachmentRelationshipType as art
	cross join dbo.TaxonomyTrunk as tt
where
	art.TenantID = tt.TenantID


--select * from dbo.AttachmentRelationshipType
--select * from dbo.AttachmentRelationshipTypeFileResourceMimeType
--select * from dbo.AttachmentRelationshipTypeTaxonomyTrunk