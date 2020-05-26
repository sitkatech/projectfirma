if exists (select * from dbo.sysobjects where id = object_id('dbo.vProjectAttachment'))
	drop view dbo.vProjectAttachment
go

create view dbo.vProjectAttachment
as
SELECT 
    pa.[ProjectAttachmentID] AS [ProjectAttachmentID], 
    pa.[ProjectAttachmentID] AS PrimaryKey, 
    pa.[TenantID] AS [TenantID], 
    pa.[ProjectID] AS [ProjectID], 
    pa.[AttachmentID] AS [AttachmentID], 
    pa.[AttachmentTypeID] AS [AttachmentTypeID], 
    pa.[DisplayName] AS [ProjectAttachmentDisplayName], 
    pa.[Description] AS [ProjectAttachmentDescription], 
    [Extent2].[FileResourceInfoID] AS [FileResourceInfoID], 
    [Extent2].[FileResourceMimeTypeID] AS [FileResourceMimeTypeID], 
    [Extent2].[OriginalBaseFilename] AS [FileResourceOriginalBaseFilename], 
    [Extent2].[OriginalFileExtension] AS [FileResourceOriginalFileExtension], 
    [Extent2].[FileResourceGUID] AS [FileResourceGUID], 
    [Extent2].[CreatePersonID] AS [FileResourceCreatePersonID], 
    [Extent2].[CreateDate] AS [FileResourceCreateDate], 
    [Extent3].[ProjectName] AS [ProjectName],
    att.AttachmentTypeDescription,
    att.AttachmentTypeName

    FROM   [dbo].[ProjectAttachment] AS pa
    JOIN [dbo].[FileResourceInfo] AS [Extent2] ON pa.[AttachmentID] = [Extent2].[FileResourceInfoID]
    JOIN [dbo].[Project] AS [Extent3] ON pa.[ProjectID] = [Extent3].[ProjectID]
    join dbo.AttachmentType att on pa.AttachmentTypeID = att.AttachmentTypeID
