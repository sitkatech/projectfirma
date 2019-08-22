

INSERT INTO dbo.ProjectAttachment (TenantID, ProjectID, AttachmentID, AttachmentRelationshipTypeID, DisplayName, [Description])  
SELECT 
		pd.TenantID,
		pd.ProjectID, 
		pd.FileResourceID as AttachmentID, 
		art.AttachmentRelationshipTypeID,
		pd.DisplayName,
		pd.[Description]
FROM 
	dbo.ProjectDocument as pd  
	cross join dbo.AttachmentRelationshipType as art  
WHERE 
	art.TenantID = pd.TenantID 
	and art.AttachmentRelationshipTypeName = 'Documents'




INSERT INTO dbo.ProjectAttachmentUpdate(TenantID, ProjectUpdateBatchID, AttachmentID, AttachmentRelationshipTypeID, DisplayName, [Description])  
SELECT 
		pdu.TenantID,
		pdu.ProjectUpdateBatchID, 
		pdu.FileResourceID as AttachmentID, 
		art.AttachmentRelationshipTypeID,
		pdu.DisplayName,
		pdu.[Description]
FROM 
	dbo.ProjectDocumentUpdate as pdu  
	cross join dbo.AttachmentRelationshipType as art  
WHERE 
	art.TenantID = pdu.TenantID 
	and art.AttachmentRelationshipTypeName = 'Documents'


