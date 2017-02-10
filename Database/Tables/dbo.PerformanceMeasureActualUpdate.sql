SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureActualUpdate](
	[PerformanceMeasureActualUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[ActualValue] [float] NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureActualUpdate_PerformanceMeasureActualUpdateID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureActualUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureActualUpdate_PerformanceMeasureActualUpdateID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureActualUpdateID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureActualUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualUpdate_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualUpdate_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualUpdate_Tenant_TenantID]