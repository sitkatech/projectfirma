SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactTypeContactRelationshipType](
	[ContactTypeContactRelationshipTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ContactTypeID] [int] NOT NULL,
	[ContactRelationshipTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ContactTypeContactRelationshipType_ContactTypeContactRelationshipTypeID] PRIMARY KEY CLUSTERED 
(
	[ContactTypeContactRelationshipTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ContactTypeContactRelationshipType_ContactTypeContactRelationshipTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[ContactTypeContactRelationshipTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ContactTypeContactRelationshipType_ContactTypeID_ContactRelationshipTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[ContactTypeID] ASC,
	[ContactRelationshipTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ContactTypeContactRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactRelationshipType_ContactRelationshipTypeID] FOREIGN KEY([ContactRelationshipTypeID])
REFERENCES [dbo].[ContactRelationshipType] ([ContactRelationshipTypeID])
GO
ALTER TABLE [dbo].[ContactTypeContactRelationshipType] CHECK CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactRelationshipType_ContactRelationshipTypeID]
GO
ALTER TABLE [dbo].[ContactTypeContactRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactRelationshipType_ContactRelationshipTypeID_TenantID] FOREIGN KEY([ContactRelationshipTypeID], [TenantID])
REFERENCES [dbo].[ContactRelationshipType] ([ContactRelationshipTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ContactTypeContactRelationshipType] CHECK CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactRelationshipType_ContactRelationshipTypeID_TenantID]
GO
ALTER TABLE [dbo].[ContactTypeContactRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactType_ContactTypeID] FOREIGN KEY([ContactTypeID])
REFERENCES [dbo].[ContactType] ([ContactTypeID])
GO
ALTER TABLE [dbo].[ContactTypeContactRelationshipType] CHECK CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactType_ContactTypeID]
GO
ALTER TABLE [dbo].[ContactTypeContactRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactType_ContactTypeID_TenantID] FOREIGN KEY([ContactTypeID], [TenantID])
REFERENCES [dbo].[ContactType] ([ContactTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ContactTypeContactRelationshipType] CHECK CONSTRAINT [FK_ContactTypeContactRelationshipType_ContactType_ContactTypeID_TenantID]
GO
ALTER TABLE [dbo].[ContactTypeContactRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_ContactTypeContactRelationshipType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ContactTypeContactRelationshipType] CHECK CONSTRAINT [FK_ContactTypeContactRelationshipType_Tenant_TenantID]