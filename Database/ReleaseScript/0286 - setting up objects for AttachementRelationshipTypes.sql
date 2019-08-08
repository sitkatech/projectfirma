--create AttachmentRelationshipType table
CREATE TABLE [dbo].[AttachmentRelationshipType](
	[AttachmentRelationshipTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[AttachmentRelationshipTypeName] [varchar](200) NOT NULL,
	[AttachmentRelationshipTypeDescription] [varchar](360) NULL,
	MaxFileSize int not null,
	NumberOfAllowedAttachments int null
 CONSTRAINT [PK_AttachmentRelationshipType_AttachmentRelationshipTypeID] PRIMARY KEY CLUSTERED 
(
	[AttachmentRelationshipTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[AttachmentRelationshipTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AttachmentRelationshipType_AttachmentRelationshipTypeName_TenantID] UNIQUE NONCLUSTERED 
(
	[AttachmentRelationshipTypeName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AttachmentRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentRelationshipType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[AttachmentRelationshipType] CHECK CONSTRAINT [FK_AttachmentRelationshipType_Tenant_TenantID]
GO


create table dbo.AttachmentRelationshipTypeFileResourceMimeType (
	AttachmentRelationshipTypeFileResourceMimeTypeID int identity(1, 1) not null constraint PK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipTypeFileResourceMimeTypeID primary key,
	TenantID int not null constraint FK_AttachmentRelationshipTypeFileResourceMimeType_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	AttachmentRelationshipTypeID int not null constraint FK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipType_AttachmentRelationshipTypeID foreign key references dbo.AttachmentRelationshipType(AttachmentRelationshipTypeID),
	FileResourceMimeTypeID int not null constraint FK_AttachmentRelationshipTypeFileResourceMimeType_FileResourceMimeType_FileResourceMimeTypeID foreign key references dbo.FileResourceMimeType(FileResourceMimeTypeID)
)

alter table dbo.AttachmentRelationshipTypeFileResourceMimeType add constraint FK_AttachmentRelationshipTypeFileResourceMimeType_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID foreign key (AttachmentRelationshipTypeID, TenantID) references dbo.AttachmentRelationshipType(AttachmentRelationshipTypeID, TenantID)
--alter table dbo.AttachmentRelationshipTypeFileResourceMimeType add constraint FK_AttachmentRelationshipTypeFileResourceMimeType_FileResourceMimeType_FileResourceMimeTypeID_TenantID foreign key (FileResourceMimeTypeID, TenantID) references dbo.FileResourceMimeType(FileResourceMimeTypeID, TenantID)

-- Create Taxonomy Trunk link table 
create table dbo.AttachmentRelationshipTypeTaxonomyTrunk (
	AttachmentRelationshipTypeTaxonomyTrunkID int identity(1, 1) not null constraint PK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipTypeTaxonomyTrunkID primary key,
	TenantID int not null constraint FK_AttachmentRelationshipTypeTaxonomyTrunk_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	AttachmentRelationshipTypeID int not null constraint FK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipType_AttachmentRelationshipTypeID foreign key references dbo.AttachmentRelationshipType(AttachmentRelationshipTypeID),
	TaxonomyTrunkID int not null constraint FK_AttachmentRelationshipTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID foreign key references dbo.TaxonomyTrunk(TaxonomyTrunkID)
)

alter table dbo.AttachmentRelationshipTypeTaxonomyTrunk add constraint FK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID foreign key (AttachmentRelationshipTypeID, TenantID) references dbo.AttachmentRelationshipType(AttachmentRelationshipTypeID, TenantID)
alter table dbo.AttachmentRelationshipTypeTaxonomyTrunk add constraint FK_AttachmentRelationshipTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID_TenantID foreign key (TaxonomyTrunkID, TenantID) references dbo.TaxonomyTrunk(TaxonomyTrunkID, TenantID)

--ProjectAttachment table
CREATE TABLE [dbo].[ProjectAttachment](
	[ProjectAttachmentID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[AttachmentID] [int] NOT NULL,
	[AttachmentRelationshipTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectAttachment_ProjectAttachmentID] PRIMARY KEY CLUSTERED 
(
	[ProjectAttachmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectAttachment_ProjectAttachmentID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectAttachmentID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_FileResource_AttachmentID_FileResourceID] FOREIGN KEY([AttachmentID])
REFERENCES [dbo].[FileResource] (FileResourceID)
GO

ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_FileResource_AttachmentID_FileResourceID]
GO

ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_FileResource_AttachmentID_TenantID_FileResourceID_TenantID] FOREIGN KEY([AttachmentID], [TenantID])
REFERENCES [dbo].FileResource (FileResourceID, [TenantID])
GO

ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_FileResource_AttachmentID_TenantID_FileResourceID_TenantID]
GO

ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_AttachmentRelationshipType_AttachmentRelationshipTypeID] FOREIGN KEY([AttachmentRelationshipTypeID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID])
GO

ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_AttachmentRelationshipType_AttachmentRelationshipTypeID]
GO

ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID] FOREIGN KEY([AttachmentRelationshipTypeID], [TenantID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID]
GO

ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO

ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_Project_ProjectID]
GO

ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_Project_ProjectID_TenantID]
GO

ALTER TABLE [dbo].[ProjectAttachment]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachment_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[ProjectAttachment] CHECK CONSTRAINT [FK_ProjectAttachment_Tenant_TenantID]
GO



--ProjectAttachmentUpdate table
CREATE TABLE [dbo].[ProjectAttachmentUpdate](
	[ProjectAttachmentUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[AttachmentID] [int] NOT NULL,
	[AttachmentRelationshipTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectAttachmentUpdate_ProjectAttachmentUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectAttachmentUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectAttachmentUpdate_ProjectAttachmentUpdateID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectAttachmentUpdateID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_FileResource_AttachmentID_FileResourceID] FOREIGN KEY([AttachmentID])
REFERENCES [dbo].FileResource (FileResourceID)
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_FileResource_AttachmentID_FileResourceID]
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_FileResource_AttachmentID_TenantID_FileResourceID_TenantID] FOREIGN KEY([AttachmentID], [TenantID])
REFERENCES [dbo].FileResource (FileResourceID, [TenantID])
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_FileResource_AttachmentID_TenantID_FileResourceID_TenantID]
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_AttachmentRelationshipType_AttachmentRelationshipTypeID] FOREIGN KEY([AttachmentRelationshipTypeID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID])
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_AttachmentRelationshipType_AttachmentRelationshipTypeID]
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID] FOREIGN KEY([AttachmentRelationshipTypeID], [TenantID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID]
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAttachmentUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[ProjectAttachmentUpdate] CHECK CONSTRAINT [FK_ProjectAttachmentUpdate_Tenant_TenantID]
GO




--add comment field to ProjectUpdateBatch
--alter table dbo.ProjectUpdateBatch
--add AttachmentsComment varchar(1000) null