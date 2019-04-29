SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureExpectedUpdate](
	[PerformanceMeasureExpectedUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[ExpectedValue] [float] NULL,
 CONSTRAINT [PK_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureExpectedUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureExpectedUpdateID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureExpectedUpdate_PerformanceMeasureExpectedUpdateID_TenantID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureExpectedUpdateID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedUpdate_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedUpdate_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedUpdate_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedUpdate_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedUpdate_Tenant_TenantID]