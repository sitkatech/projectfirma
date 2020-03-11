-- add the table and constraint
ALTER TABLE dbo.TenantAttribute
ADD TenantFactSheetLogoFileResourceID int NULL
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_FileResource_TenantFactSheetLogoFileResourceID_FileResourceID] FOREIGN KEY([TenantFactSheetLogoFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_FileResource_TenantFactSheetLogoFileResourceID_FileResourceID]
GO

-- duplicate row in file resource 
if exists(select 1 from dbo.TenantAttribute where TenantID = 1 and TenantSquareLogoFileResourceID is not null)
begin
Insert into dbo.FileResource (TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate)
select fr.TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, fr.CreatePersonID, CURRENT_TIMESTAMP from dbo.TenantAttribute ta left join dbo.FileResource fr  on fr.FileResourceID = ta.TenantSquareLogoFileResourceID where ta.TenantID = 1
UPDATE dbo.TenantAttribute
set TenantFactSheetLogoFileResourceID = SCOPE_IDENTITY() where TenantID = 1
end

if exists(select 1 from dbo.TenantAttribute where TenantID = 2 and TenantSquareLogoFileResourceID is not null)
begin
Insert into dbo.FileResource (TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate)
select fr.TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, fr.CreatePersonID, CURRENT_TIMESTAMP from dbo.TenantAttribute ta left join dbo.FileResource fr  on fr.FileResourceID = ta.TenantSquareLogoFileResourceID where ta.TenantID = 2
UPDATE dbo.TenantAttribute
set TenantFactSheetLogoFileResourceID = SCOPE_IDENTITY() where TenantID = 2
end

if exists(select 1 from dbo.TenantAttribute where TenantID = 3 and TenantSquareLogoFileResourceID is not null)
begin
Insert into dbo.FileResource (TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate)
select fr.TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, fr.CreatePersonID, CURRENT_TIMESTAMP from dbo.TenantAttribute ta left join dbo.FileResource fr  on fr.FileResourceID = ta.TenantSquareLogoFileResourceID where ta.TenantID = 3
UPDATE dbo.TenantAttribute
set TenantFactSheetLogoFileResourceID = SCOPE_IDENTITY() where TenantID = 3
end

if exists(select 1 from dbo.TenantAttribute where TenantID = 4 and TenantSquareLogoFileResourceID is not null)
begin
Insert into dbo.FileResource (TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate)
select fr.TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, fr.CreatePersonID, CURRENT_TIMESTAMP from dbo.TenantAttribute ta left join dbo.FileResource fr  on fr.FileResourceID = ta.TenantSquareLogoFileResourceID where ta.TenantID = 4
UPDATE dbo.TenantAttribute
set TenantFactSheetLogoFileResourceID = SCOPE_IDENTITY() where TenantID = 4
end

if exists(select 1 from dbo.TenantAttribute where TenantID = 5 and TenantSquareLogoFileResourceID is not null)
begin
Insert into dbo.FileResource (TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate)
select fr.TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, fr.CreatePersonID, CURRENT_TIMESTAMP from dbo.TenantAttribute ta left join dbo.FileResource fr  on fr.FileResourceID = ta.TenantSquareLogoFileResourceID where ta.TenantID = 5
UPDATE dbo.TenantAttribute
set TenantFactSheetLogoFileResourceID = SCOPE_IDENTITY() where TenantID = 5
end

if exists(select 1 from dbo.TenantAttribute where TenantID = 6 and TenantSquareLogoFileResourceID is not null)
begin
Insert into dbo.FileResource (TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate)
select fr.TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, fr.CreatePersonID, CURRENT_TIMESTAMP from dbo.TenantAttribute ta left join dbo.FileResource fr  on fr.FileResourceID = ta.TenantSquareLogoFileResourceID where ta.TenantID = 6
UPDATE dbo.TenantAttribute
set TenantFactSheetLogoFileResourceID = SCOPE_IDENTITY() where TenantID = 6
end

if exists(select 1 from dbo.TenantAttribute where TenantID = 7 and TenantSquareLogoFileResourceID is not null)
begin
Insert into dbo.FileResource (TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate)
select fr.TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, fr.CreatePersonID, CURRENT_TIMESTAMP from dbo.TenantAttribute ta left join dbo.FileResource fr  on fr.FileResourceID = ta.TenantSquareLogoFileResourceID where ta.TenantID = 7
UPDATE dbo.TenantAttribute
set TenantFactSheetLogoFileResourceID = SCOPE_IDENTITY() where TenantID = 7
end

if exists(select 1 from dbo.TenantAttribute where TenantID = 8 and TenantSquareLogoFileResourceID is not null)
begin
Insert into dbo.FileResource (TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate)
select fr.TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, fr.CreatePersonID, CURRENT_TIMESTAMP from dbo.TenantAttribute ta left join dbo.FileResource fr  on fr.FileResourceID = ta.TenantSquareLogoFileResourceID where ta.TenantID = 8
UPDATE dbo.TenantAttribute
set TenantFactSheetLogoFileResourceID = SCOPE_IDENTITY() where TenantID = 8
end

if exists(select 1 from dbo.TenantAttribute where TenantID = 9 and TenantSquareLogoFileResourceID is not null)
begin
Insert into dbo.FileResource (TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate)
select fr.TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, fr.CreatePersonID, CURRENT_TIMESTAMP from dbo.TenantAttribute ta left join dbo.FileResource fr  on fr.FileResourceID = ta.TenantSquareLogoFileResourceID where ta.TenantID = 9
UPDATE dbo.TenantAttribute
set TenantFactSheetLogoFileResourceID = SCOPE_IDENTITY() where TenantID = 9
end

if exists(select 1 from dbo.TenantAttribute where TenantID = 11 and TenantSquareLogoFileResourceID is not null)
begin
Insert into dbo.FileResource (TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate)
select fr.TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, fr.CreatePersonID, CURRENT_TIMESTAMP from dbo.TenantAttribute ta left join dbo.FileResource fr  on fr.FileResourceID = ta.TenantSquareLogoFileResourceID where ta.TenantID = 11
UPDATE dbo.TenantAttribute
set TenantFactSheetLogoFileResourceID = SCOPE_IDENTITY() where TenantID = 11
end

if exists(select 1 from dbo.TenantAttribute where TenantID = 12 and TenantSquareLogoFileResourceID is not null)
begin
Insert into dbo.FileResource (TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate)
select fr.TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, fr.CreatePersonID, CURRENT_TIMESTAMP from dbo.TenantAttribute ta left join dbo.FileResource fr  on fr.FileResourceID = ta.TenantSquareLogoFileResourceID where ta.TenantID = 12
UPDATE dbo.TenantAttribute
set TenantFactSheetLogoFileResourceID = SCOPE_IDENTITY() where TenantID = 12
end

