SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
ALTER TABLE [dbo].[ProjectContact]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContact_Person_ContactID_PersonID_TenantID] FOREIGN KEY([ContactID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectContact] CHECK CONSTRAINT [FK_ProjectContact_Person_ContactID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[ProjectContact]  WITH CHECK ADD  CONSTRAINT [FK_ProjectContact_PersonID_ContactID_PersonID] FOREIGN KEY([ContactID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProjectContact] CHECK CONSTRAINT [FK_ProjectContact_PersonID_ContactID_PersonID]
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