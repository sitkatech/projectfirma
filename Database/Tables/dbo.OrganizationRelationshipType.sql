SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationRelationshipType](
	[OrganizationRelationshipTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationRelationshipTypeName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CanStewardProjects] [bit] NOT NULL,
	[IsPrimaryContact] [bit] NOT NULL,
	[CanOnlyBeRelatedOnceToAProject] [bit] NOT NULL,
	[OrganizationRelationshipTypeDescription] [varchar](360) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ReportInAccomplishmentsDashboard] [bit] NOT NULL,
	[ShowOnFactSheet] [bit] NOT NULL,
 CONSTRAINT [PK_OrganizationRelationshipType_OrganizationRelationshipTypeID] PRIMARY KEY CLUSTERED 
(
	[OrganizationRelationshipTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_OrganizationRelationshipType_OrganizationRelationshipTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[OrganizationRelationshipTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_OrganizationRelationshipType_OrganizationRelationshipTypeName_TenantID] UNIQUE NONCLUSTERED 
(
	[OrganizationRelationshipTypeName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE UNIQUE NONCLUSTERED INDEX [CK_RelationshipType_CanStewardProjects_OneTruePerTenant] ON [dbo].[OrganizationRelationshipType]
(
	[TenantID] ASC,
	[CanStewardProjects] ASC
)
WHERE ([CanStewardProjects]=(1))
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [CK_RelationshipType_IsPrimaryContact_OneTruePerTenant] ON [dbo].[OrganizationRelationshipType]
(
	[TenantID] ASC,
	[IsPrimaryContact] ASC
)
WHERE ([IsPrimaryContact]=(1))
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrganizationRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationRelationshipType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[OrganizationRelationshipType] CHECK CONSTRAINT [FK_OrganizationRelationshipType_Tenant_TenantID]