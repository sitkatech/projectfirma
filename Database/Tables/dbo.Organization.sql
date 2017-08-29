SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[OrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationGuid] [uniqueidentifier] NULL,
	[OrganizationName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[OrganizationShortName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrimaryContactPersonID] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[OrganizationUrl] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LogoFileResourceID] [int] NULL,
	[OrganizationTypeID] [int] NULL,
	[OrganizationBoundary] [geometry] NULL,
 CONSTRAINT [PK_Organization_OrganizationID] PRIMARY KEY CLUSTERED 
(
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Organization_OrganizationID_TenantID] UNIQUE NONCLUSTERED 
(
	[OrganizationID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Organization_OrganizationName_TenantID] UNIQUE NONCLUSTERED 
(
	[OrganizationName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
CREATE UNIQUE NONCLUSTERED INDEX [AK_Organization_OrganizationGuid_TenantID] ON [dbo].[Organization]
(
	[OrganizationGuid] ASC,
	[TenantID] ASC
)
WHERE ([OrganizationGuid] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_FileResource_LogoFileResourceID_FileResourceID] FOREIGN KEY([LogoFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_FileResource_LogoFileResourceID_FileResourceID]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_FileResource_LogoFileResourceID_TenantID_FileResourceID_TenantID] FOREIGN KEY([LogoFileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_FileResource_LogoFileResourceID_TenantID_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_OrganizationType_OrganizationTypeID] FOREIGN KEY([OrganizationTypeID])
REFERENCES [dbo].[OrganizationType] ([OrganizationTypeID])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_OrganizationType_OrganizationTypeID]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_OrganizationType_OrganizationTypeID_TenantID] FOREIGN KEY([OrganizationTypeID], [TenantID])
REFERENCES [dbo].[OrganizationType] ([OrganizationTypeID], [TenantID])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_OrganizationType_OrganizationTypeID_TenantID]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_Person_PrimaryContactPersonID_PersonID] FOREIGN KEY([PrimaryContactPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_Person_PrimaryContactPersonID_PersonID]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_Person_PrimaryContactPersonID_TenantID_PersonID_TenantID] FOREIGN KEY([PrimaryContactPersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_Person_PrimaryContactPersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_Tenant_TenantID]