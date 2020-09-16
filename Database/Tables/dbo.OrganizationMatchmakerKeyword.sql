SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationMatchmakerKeyword](
	[OrganizationMatchmakerKeywordID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[MatchmakerKeywordID] [int] NOT NULL,
 CONSTRAINT [PK_OrganizationMatchmakerKeyword_OrganizationMatchmakerKeywordID] PRIMARY KEY CLUSTERED 
(
	[OrganizationMatchmakerKeywordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_OrganizationMatchmakerKeyword_OrganizationID_MatchmakerKeywordID] UNIQUE NONCLUSTERED 
(
	[OrganizationID] ASC,
	[MatchmakerKeywordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[OrganizationMatchmakerKeyword]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationMatchmakerKeyword_MatchmakerKeyword_MatchmakerKeywordID] FOREIGN KEY([MatchmakerKeywordID])
REFERENCES [dbo].[MatchmakerKeyword] ([MatchmakerKeywordID])
GO
ALTER TABLE [dbo].[OrganizationMatchmakerKeyword] CHECK CONSTRAINT [FK_OrganizationMatchmakerKeyword_MatchmakerKeyword_MatchmakerKeywordID]
GO
ALTER TABLE [dbo].[OrganizationMatchmakerKeyword]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationMatchmakerKeyword_MatchmakerKeyword_MatchmakerKeywordID_TenantID] FOREIGN KEY([MatchmakerKeywordID], [TenantID])
REFERENCES [dbo].[MatchmakerKeyword] ([MatchmakerKeywordID], [TenantID])
GO
ALTER TABLE [dbo].[OrganizationMatchmakerKeyword] CHECK CONSTRAINT [FK_OrganizationMatchmakerKeyword_MatchmakerKeyword_MatchmakerKeywordID_TenantID]
GO
ALTER TABLE [dbo].[OrganizationMatchmakerKeyword]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationMatchmakerKeyword_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[OrganizationMatchmakerKeyword] CHECK CONSTRAINT [FK_OrganizationMatchmakerKeyword_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[OrganizationMatchmakerKeyword]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationMatchmakerKeyword_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[OrganizationMatchmakerKeyword] CHECK CONSTRAINT [FK_OrganizationMatchmakerKeyword_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[OrganizationMatchmakerKeyword]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationMatchmakerKeyword_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[OrganizationMatchmakerKeyword] CHECK CONSTRAINT [FK_OrganizationMatchmakerKeyword_Tenant_TenantID]