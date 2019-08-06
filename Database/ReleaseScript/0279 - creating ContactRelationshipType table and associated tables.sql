--create ContactRelationshipType table
CREATE TABLE [dbo].[ContactRelationshipType](
	[ContactRelationshipTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ContactRelationshipTypeName] [varchar](200) NOT NULL,
	[CanOnlyBeRelatedOnceToAProject] [bit] NOT NULL,
	[ContactRelationshipTypeDescription] [varchar](360) NULL,
 CONSTRAINT [PK_ContactRelationshipType_ContactRelationshipTypeID] PRIMARY KEY CLUSTERED 
(
	[ContactRelationshipTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ContactRelationshipType_ContactRelationshipTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[ContactRelationshipTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ContactRelationshipType_ContactRelationshipTypeName_TenantID] UNIQUE NONCLUSTERED 
(
	[ContactRelationshipTypeName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ContactRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_ContactRelationshipType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[ContactRelationshipType] CHECK CONSTRAINT [FK_ContactRelationshipType_Tenant_TenantID]
GO



--Create ContactType table
--CREATE TABLE [dbo].[ContactType](
--	[ContactTypeID] [int] IDENTITY(1,1) NOT NULL,
--	[TenantID] [int] NOT NULL,
--	[ContactTypeName] [varchar](200) NOT NULL,
--	[ContactTypeAbbreviation] [varchar](100) NOT NULL,
--	[IsDefaultContactType] [bit] NOT NULL,
-- CONSTRAINT [PK_ContactType_ContactTypeID] PRIMARY KEY CLUSTERED 
--(
--	[ContactTypeID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
-- CONSTRAINT [AK_ContactType_ContactTypeID_TenantID] UNIQUE NONCLUSTERED 
--(
--	[ContactTypeID] ASC,
--	[TenantID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
-- CONSTRAINT [AK_ContactType_ContactTypeName_TenantID] UNIQUE NONCLUSTERED 
--(
--	[ContactTypeName] ASC,
--	[TenantID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO

--ALTER TABLE [dbo].[ContactType]  WITH CHECK ADD  CONSTRAINT [FK_ContactType_Tenant_TenantID] FOREIGN KEY([TenantID])
--REFERENCES [dbo].[Tenant] ([TenantID])
--GO

--ALTER TABLE [dbo].[ContactType] CHECK CONSTRAINT [FK_ContactType_Tenant_TenantID]
--GO



--create joining table ContactTypeContactRelationshipType
--CREATE TABLE [dbo].[ContactTypeContactRelationshipType](
--	[ContactTypeContactRelationshipTypeID] [int] IDENTITY(1,1) NOT NULL,
--	[TenantID] [int] NOT NULL,
--	[ContactTypeID] [int] NOT NULL,
--	[ContactRelationshipTypeID] [int] NOT NULL,
-- CONSTRAINT [PK_ContactTypeContactRelationshipType_ContactTypeContactRelationshipTypeID] PRIMARY KEY CLUSTERED 
--(
--	[ContactTypeContactRelationshipTypeID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
-- CONSTRAINT [AK_ContactTypeContactRelationshipType_ContactTypeID_ContactRelationshipTypeID_TenantID] UNIQUE NONCLUSTERED 
--(
--	[ContactTypeID] ASC,
--	[ContactRelationshipTypeID] ASC,
--	[TenantID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
-- CONSTRAINT [AK_ContactTypeContactRelationshipType_ContactTypeContactRelationshipTypeID_TenantID] UNIQUE NONCLUSTERED 
--(
--	[ContactTypeContactRelationshipTypeID] ASC,
--	[TenantID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO

--ALTER TABLE [dbo].[ContactTypeContactRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactRelationshipType_ContactRelationshipTypeID] FOREIGN KEY([ContactRelationshipTypeID])
--REFERENCES [dbo].[ContactRelationshipType] ([ContactRelationshipTypeID])
--GO

--ALTER TABLE [dbo].[ContactTypeContactRelationshipType] CHECK CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactRelationshipType_ContactRelationshipTypeID]
--GO

--ALTER TABLE [dbo].[ContactTypeContactRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactRelationshipType_ContactRelationshipTypeID_TenantID] FOREIGN KEY([ContactRelationshipTypeID], [TenantID])
--REFERENCES [dbo].[ContactRelationshipType] ([ContactRelationshipTypeID], [TenantID])
--GO

--ALTER TABLE [dbo].[ContactTypeContactRelationshipType] CHECK CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactRelationshipType_ContactRelationshipTypeID_TenantID]
--GO

--ALTER TABLE [dbo].[ContactTypeContactRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactType_ContactTypeID] FOREIGN KEY([ContactTypeID])
--REFERENCES [dbo].[ContactType] ([ContactTypeID])
--GO

--ALTER TABLE [dbo].[ContactTypeContactRelationshipType] CHECK CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactType_ContactTypeID]
--GO

--ALTER TABLE [dbo].[ContactTypeContactRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactType_ContactTypeID_TenantID] FOREIGN KEY([ContactTypeID], [TenantID])
--REFERENCES [dbo].[ContactType] ([ContactTypeID], [TenantID])
--GO

--ALTER TABLE [dbo].[ContactTypeContactRelationshipType] CHECK CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactType_ContactTypeID_TenantID]
--GO

--ALTER TABLE [dbo].[ContactTypeContactRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_ContactTypeContactRelationshipType_Tenant_TenantID] FOREIGN KEY([TenantID])
--REFERENCES [dbo].[Tenant] ([TenantID])
--GO

--ALTER TABLE [dbo].[ContactTypeContactRelationshipType] CHECK CONSTRAINT [FK_ContactTypeContactRelationshipType_Tenant_TenantID]
--GO



--ProjectContact table
CREATE TABLE [dbo].[ProjectContact](
	[ProjectContactID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[ContactID] [int] NOT NULL,
	[ContactRelationshipTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectContact_ProjectContactID] PRIMARY KEY CLUSTERED 
(
	[ProjectContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectContact_ProjectContactID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectContactID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProjectContact]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContact_PersonID_ContactID_PersonID] FOREIGN KEY([ContactID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].[ProjectContact] CHECK CONSTRAINT [FK_ProjectContact_PersonID_ContactID_PersonID]
GO

ALTER TABLE [dbo].[ProjectContact]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContact_Person_ContactID_PersonID_TenantID] FOREIGN KEY([ContactID], [TenantID])
REFERENCES [dbo].Person (PersonID, [TenantID])
GO

ALTER TABLE [dbo].[ProjectContact] CHECK CONSTRAINT [FK_ProjectContact_Person_ContactID_PersonID_TenantID]
GO

ALTER TABLE [dbo].[ProjectContact]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContact_ContactRelationshipType_ContactRelationshipTypeID] FOREIGN KEY([ContactRelationshipTypeID])
REFERENCES [dbo].[ContactRelationshipType] ([ContactRelationshipTypeID])
GO

ALTER TABLE [dbo].[ProjectContact] CHECK CONSTRAINT [FK_ProjectContact_ContactRelationshipType_ContactRelationshipTypeID]
GO

ALTER TABLE [dbo].[ProjectContact]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContact_ContactRelationshipType_ContactRelationshipTypeID_TenantID] FOREIGN KEY([ContactRelationshipTypeID], [TenantID])
REFERENCES [dbo].[ContactRelationshipType] ([ContactRelationshipTypeID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectContact] CHECK CONSTRAINT [FK_ProjectContact_ContactRelationshipType_ContactRelationshipTypeID_TenantID]
GO

ALTER TABLE [dbo].[ProjectContact]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContact_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO

ALTER TABLE [dbo].[ProjectContact] CHECK CONSTRAINT [FK_ProjectContact_Project_ProjectID]
GO

ALTER TABLE [dbo].[ProjectContact]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContact_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectContact] CHECK CONSTRAINT [FK_ProjectContact_Project_ProjectID_TenantID]
GO

ALTER TABLE [dbo].[ProjectContact]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContact_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[ProjectContact] CHECK CONSTRAINT [FK_ProjectContact_Tenant_TenantID]
GO



--ProjectContactUpdate table

CREATE TABLE [dbo].[ProjectContactUpdate](
	[ProjectContactUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[ContactID] [int] NOT NULL,
	[ContactRelationshipTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectContactUpdate_ProjectContactUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectContactUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectContactUpdate_ProjectContactUpdateID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectContactUpdateID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProjectContactUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContactUpdate_Person_ContactID_PersonID] FOREIGN KEY([ContactID])
REFERENCES [dbo].Person (PersonID)
GO

ALTER TABLE [dbo].[ProjectContactUpdate] CHECK CONSTRAINT [FK_ProjectContactUpdate_Person_ContactID_PersonID]
GO

ALTER TABLE [dbo].[ProjectContactUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContactUpdate_Person_ContactID_PersonID_TenantID] FOREIGN KEY([ContactID], [TenantID])
REFERENCES [dbo].Person (PersonID, [TenantID])
GO

ALTER TABLE [dbo].[ProjectContactUpdate] CHECK CONSTRAINT [FK_ProjectContactUpdate_Person_ContactID_PersonID_TenantID]
GO

ALTER TABLE [dbo].[ProjectContactUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContactUpdate_ContactRelationshipType_ContactRelationshipTypeID] FOREIGN KEY([ContactRelationshipTypeID])
REFERENCES [dbo].[ContactRelationshipType] ([ContactRelationshipTypeID])
GO

ALTER TABLE [dbo].[ProjectContactUpdate] CHECK CONSTRAINT [FK_ProjectContactUpdate_ContactRelationshipType_ContactRelationshipTypeID]
GO

ALTER TABLE [dbo].[ProjectContactUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContactUpdate_ContactRelationshipType_ContactRelationshipTypeID_TenantID] FOREIGN KEY([ContactRelationshipTypeID], [TenantID])
REFERENCES [dbo].[ContactRelationshipType] ([ContactRelationshipTypeID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectContactUpdate] CHECK CONSTRAINT [FK_ProjectContactUpdate_ContactRelationshipType_ContactRelationshipTypeID_TenantID]
GO

ALTER TABLE [dbo].[ProjectContactUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContactUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO

ALTER TABLE [dbo].[ProjectContactUpdate] CHECK CONSTRAINT [FK_ProjectContactUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO

ALTER TABLE [dbo].[ProjectContactUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContactUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO

ALTER TABLE [dbo].[ProjectContactUpdate] CHECK CONSTRAINT [FK_ProjectContactUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO

ALTER TABLE [dbo].[ProjectContactUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContactUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[ProjectContactUpdate] CHECK CONSTRAINT [FK_ProjectContactUpdate_Tenant_TenantID]
GO



----add reference to ContactType on Person table
--alter table dbo.Person
--add ContactTypeID int null constraint FK_Person_ContactType_ContactTypeID foreign key references dbo.ContactType(ContactTypeID);

--add comment field to ProjectUpdateBatch
alter table dbo.ProjectUpdateBatch
add ContactsComment varchar(1000) null