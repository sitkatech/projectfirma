SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocationStagingUpdate](
	[ProjectLocationStagingUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[FeatureClassName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GeoJson] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SelectedProperty] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShouldImport] [bit] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectLocationStagingUpdate_ProjectLocationStagingUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationStagingUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocationStagingUpdate_ProjectUpdateBatchID_PersonID_FeatureClassName] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[PersonID] ASC,
	[FeatureClassName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectLocationStagingUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationStagingUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectLocationStagingUpdate] CHECK CONSTRAINT [FK_ProjectLocationStagingUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectLocationStagingUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationStagingUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectLocationStagingUpdate] CHECK CONSTRAINT [FK_ProjectLocationStagingUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectLocationStagingUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationStagingUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectLocationStagingUpdate] CHECK CONSTRAINT [FK_ProjectLocationStagingUpdate_Tenant_TenantID]