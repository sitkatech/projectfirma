SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EIPPerformanceMeasureActualUpdate](
	[EIPPerformanceMeasureActualUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[EIPPerformanceMeasureID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[ActualValue] [float] NULL,
 CONSTRAINT [PK_EIPPerformanceMeasureActualUpdate_EIPPerformanceMeasureActualUpdateID] PRIMARY KEY CLUSTERED 
(
	[EIPPerformanceMeasureActualUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_EIPPerformanceMeasureActualUpdate_EIPPerformanceMeasureActualUpdateID_EIPPerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[EIPPerformanceMeasureActualUpdateID] ASC,
	[EIPPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualUpdate]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualUpdate_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualUpdate] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualUpdate_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualUpdate]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualUpdate] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]