SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectExternalLink](
	[ProjectExternalLinkID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[ExternalLinkLabel] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ExternalLinkUrl] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectExternalLink_ProjectExternalLinkID] PRIMARY KEY CLUSTERED 
(
	[ProjectExternalLinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectExternalLink]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExternalLink_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectExternalLink] CHECK CONSTRAINT [FK_ProjectExternalLink_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectExternalLink]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExternalLink_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectExternalLink] CHECK CONSTRAINT [FK_ProjectExternalLink_Tenant_TenantID]