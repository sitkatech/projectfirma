SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectImplementingOrganization](
	[ProjectImplementingOrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[IsLeadOrganization] [bit] NOT NULL,
 CONSTRAINT [PK_ProjectImplementingOrganization_ProjectImplementingOrganizationID] PRIMARY KEY CLUSTERED 
(
	[ProjectImplementingOrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectImplementingOrganization_ProjectID_OrganizationID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectImplementingOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImplementingOrganization_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[ProjectImplementingOrganization] CHECK CONSTRAINT [FK_ProjectImplementingOrganization_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[ProjectImplementingOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImplementingOrganization_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectImplementingOrganization] CHECK CONSTRAINT [FK_ProjectImplementingOrganization_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[ProjectImplementingOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImplementingOrganization_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectImplementingOrganization] CHECK CONSTRAINT [FK_ProjectImplementingOrganization_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectImplementingOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImplementingOrganization_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectImplementingOrganization] CHECK CONSTRAINT [FK_ProjectImplementingOrganization_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectImplementingOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImplementingOrganization_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectImplementingOrganization] CHECK CONSTRAINT [FK_ProjectImplementingOrganization_Tenant_TenantID]