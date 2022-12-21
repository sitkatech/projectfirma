SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUpdateBatchClassificationSystem](
	[ProjectUpdateBatchClassificationSystemID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[ClassificationSystemID] [int] NOT NULL,
	[ProjectClassificationsDiffLog] [dbo].[html] NULL,
	[ProjectClassificationsComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ProjectUpdateBatchClassificationSystem_ProjectUpdateBatchClassificationSystemID] PRIMARY KEY CLUSTERED 
(
	[ProjectUpdateBatchClassificationSystemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_ProjectUpdateBatchClassificationSystem_ProjectUpdateBatchClassificationSystemID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchClassificationSystemID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectUpdateBatchClassificationSystem]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatchClassificationSystem_ClassificationSystem_ClassificationSystemID] FOREIGN KEY([ClassificationSystemID])
REFERENCES [dbo].[ClassificationSystem] ([ClassificationSystemID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatchClassificationSystem] CHECK CONSTRAINT [FK_ProjectUpdateBatchClassificationSystem_ClassificationSystem_ClassificationSystemID]
GO
ALTER TABLE [dbo].[ProjectUpdateBatchClassificationSystem]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatchClassificationSystem_ClassificationSystem_ClassificationSystemID_TenantID] FOREIGN KEY([ClassificationSystemID], [TenantID])
REFERENCES [dbo].[ClassificationSystem] ([ClassificationSystemID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatchClassificationSystem] CHECK CONSTRAINT [FK_ProjectUpdateBatchClassificationSystem_ClassificationSystem_ClassificationSystemID_TenantID]
GO
ALTER TABLE [dbo].[ProjectUpdateBatchClassificationSystem]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatchClassificationSystem_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatchClassificationSystem] CHECK CONSTRAINT [FK_ProjectUpdateBatchClassificationSystem_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectUpdateBatchClassificationSystem]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatchClassificationSystem_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatchClassificationSystem] CHECK CONSTRAINT [FK_ProjectUpdateBatchClassificationSystem_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectUpdateBatchClassificationSystem]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatchClassificationSystem_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatchClassificationSystem] CHECK CONSTRAINT [FK_ProjectUpdateBatchClassificationSystem_Tenant_TenantID]