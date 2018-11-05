SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonStewardOrganization](
	[PersonStewardOrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
 CONSTRAINT [PK_PersonStewardOrganization_PersonStewardOrganizationID] PRIMARY KEY CLUSTERED 
(
	[PersonStewardOrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PersonStewardOrganization_PersonStewardOrganizationID_TenantID] UNIQUE NONCLUSTERED 
(
	[PersonStewardOrganizationID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PersonStewardOrganization]  WITH CHECK ADD  CONSTRAINT [FK_PersonStewardOrganization_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[PersonStewardOrganization] CHECK CONSTRAINT [FK_PersonStewardOrganization_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[PersonStewardOrganization]  WITH CHECK ADD  CONSTRAINT [FK_PersonStewardOrganization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[PersonStewardOrganization] CHECK CONSTRAINT [FK_PersonStewardOrganization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[PersonStewardOrganization]  WITH CHECK ADD  CONSTRAINT [FK_PersonStewardOrganization_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonStewardOrganization] CHECK CONSTRAINT [FK_PersonStewardOrganization_Person_PersonID]
GO
ALTER TABLE [dbo].[PersonStewardOrganization]  WITH CHECK ADD  CONSTRAINT [FK_PersonStewardOrganization_Person_PersonID_TenantID] FOREIGN KEY([PersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[PersonStewardOrganization] CHECK CONSTRAINT [FK_PersonStewardOrganization_Person_PersonID_TenantID]
GO
ALTER TABLE [dbo].[PersonStewardOrganization]  WITH CHECK ADD  CONSTRAINT [FK_PersonStewardOrganization_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PersonStewardOrganization] CHECK CONSTRAINT [FK_PersonStewardOrganization_Tenant_TenantID]