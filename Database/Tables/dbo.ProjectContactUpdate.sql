SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
ALTER TABLE [dbo].[ProjectContactUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContactUpdate_Person_ContactID_PersonID] FOREIGN KEY([ContactID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProjectContactUpdate] CHECK CONSTRAINT [FK_ProjectContactUpdate_Person_ContactID_PersonID]
GO
ALTER TABLE [dbo].[ProjectContactUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContactUpdate_Person_ContactID_TenantID_PersonID_TenantID] FOREIGN KEY([ContactID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectContactUpdate] CHECK CONSTRAINT [FK_ProjectContactUpdate_Person_ContactID_TenantID_PersonID_TenantID]
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