SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationType](
	[OrganizationTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationTypeName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[OrganizationTypeAbbreviation] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LegendColor] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ShowOnProjectMaps] [bit] NOT NULL,
	[IsDefaultOrganizationType] [bit] NOT NULL,
 CONSTRAINT [PK_OrganizationType_OrganizationTypeID] PRIMARY KEY CLUSTERED 
(
	[OrganizationTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_OrganizationType_OrganizationTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[OrganizationTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_OrganizationType_OrganizationTypeName_TenantID] UNIQUE NONCLUSTERED 
(
	[OrganizationTypeName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[OrganizationType]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[OrganizationType] CHECK CONSTRAINT [FK_OrganizationType_Tenant_TenantID]