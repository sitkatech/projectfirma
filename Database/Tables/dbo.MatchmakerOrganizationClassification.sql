SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchmakerOrganizationClassification](
	[MatchmakerOrganizationClassificationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[ClassificationID] [int] NOT NULL,
 CONSTRAINT [PK_MatchmakerOrganizationClassification_MatchmakerOrganizationClassificationID] PRIMARY KEY CLUSTERED 
(
	[MatchmakerOrganizationClassificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MatchmakerOrganizationClassification_MatchmakerOrganizationClassificationID_TenantID] UNIQUE NONCLUSTERED 
(
	[MatchmakerOrganizationClassificationID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MatchmakerOrganizationClassification_MatchmakerOrganizationClassificationID_TenantID_ClassificationID] UNIQUE NONCLUSTERED 
(
	[MatchmakerOrganizationClassificationID] ASC,
	[TenantID] ASC,
	[ClassificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MatchmakerOrganizationClassification]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationClassification_Classification_ClassificationID] FOREIGN KEY([ClassificationID])
REFERENCES [dbo].[Classification] ([ClassificationID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationClassification] CHECK CONSTRAINT [FK_MatchmakerOrganizationClassification_Classification_ClassificationID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationClassification]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationClassification_Classification_ClassificationID_TenantID] FOREIGN KEY([ClassificationID], [TenantID])
REFERENCES [dbo].[Classification] ([ClassificationID], [TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationClassification] CHECK CONSTRAINT [FK_MatchmakerOrganizationClassification_Classification_ClassificationID_TenantID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationClassification]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationClassification_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationClassification] CHECK CONSTRAINT [FK_MatchmakerOrganizationClassification_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationClassification]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationClassification_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationClassification] CHECK CONSTRAINT [FK_MatchmakerOrganizationClassification_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationClassification]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationClassification_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationClassification] CHECK CONSTRAINT [FK_MatchmakerOrganizationClassification_Tenant_TenantID]