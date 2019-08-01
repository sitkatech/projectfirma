SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactRelationshipType](
	[ContactRelationshipTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ContactRelationshipTypeName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CanOnlyBeRelatedOnceToAProject] [bit] NOT NULL,
	[ContactRelationshipTypeDescription] [varchar](360) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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