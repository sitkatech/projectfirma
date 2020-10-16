SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchmakerOrganizationPerformanceMeasure](
	[MatchmakerOrganizationPerformanceMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
 CONSTRAINT [PK_MatchmakerOrganizationPerformanceMeasure_MatchmakerOrganizationPerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[MatchmakerOrganizationPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MatchmakerOrganizationPerformanceMeasure_MatchmakerOrganizationPerformanceMeasureID_TenantID] UNIQUE NONCLUSTERED 
(
	[MatchmakerOrganizationPerformanceMeasureID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MatchmakerOrganizationPerformanceMeasure_MatchmakerOrganizationPerformanceMeasureID_TenantID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[MatchmakerOrganizationPerformanceMeasureID] ASC,
	[TenantID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MatchmakerOrganizationPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationPerformanceMeasure_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationPerformanceMeasure] CHECK CONSTRAINT [FK_MatchmakerOrganizationPerformanceMeasure_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationPerformanceMeasure_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationPerformanceMeasure] CHECK CONSTRAINT [FK_MatchmakerOrganizationPerformanceMeasure_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationPerformanceMeasure] CHECK CONSTRAINT [FK_MatchmakerOrganizationPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationPerformanceMeasure] CHECK CONSTRAINT [FK_MatchmakerOrganizationPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationPerformanceMeasure_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationPerformanceMeasure] CHECK CONSTRAINT [FK_MatchmakerOrganizationPerformanceMeasure_Tenant_TenantID]