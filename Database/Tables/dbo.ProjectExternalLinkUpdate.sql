SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectExternalLinkUpdate](
	[ProjectExternalLinkUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[ExternalLinkLabel] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ExternalLinkUrl] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectExternalLinkUpdate_ProjectExternalLinkUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectExternalLinkUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectExternalLinkUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExternalLinkUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectExternalLinkUpdate] CHECK CONSTRAINT [FK_ProjectExternalLinkUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectExternalLinkUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExternalLinkUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectExternalLinkUpdate] CHECK CONSTRAINT [FK_ProjectExternalLinkUpdate_Tenant_TenantID]