insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) 
	values (23, 'application/vnd.google-earth.kmz', 'KMZ', 'KMZ', null, null)

insert into dbo.FileResourceMimeType (FileResourceMimeTypeID, FileResourceMimeTypeContentTypeName, FileResourceMimeTypeName, FileResourceMimeTypeDisplayName, FileResourceMimeTypeIconSmallFilename,  FileResourceMimeTypeIconNormalFilename) 
	values (24, 'application/vnd.google-earth.kml+xml', 'KML', 'KML', null, null)

--insert allowed file types(KMZ and KML) for all 'Documents' attachment relationship types
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
	and ( frmt.FileResourceMimeTypeDisplayName like '%KMZ%' or frmt.FileResourceMimeTypeDisplayName like '%KML%')